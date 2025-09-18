using System.Linq.Expressions;

namespace Tawla._360.Infrastructure.Extensions;

public static class ExpressionExtensions
{
    public static string AsPath(this LambdaExpression expression)
    {
        if (expression == null) return null;

        var exp = expression.Body;
        return TryParsePath(exp, out var path) ? path : null;
    }

    private static bool TryParsePath(Expression expression, out string path)
    {
        path = null;
        expression = RemoveConvert(expression);

        switch (expression)
        {
            case MemberExpression member:
                var thisPart = member.Member.Name;
                if (!TryParsePath(member.Expression, out var parentPart))
                    return false;
                path = string.IsNullOrEmpty(parentPart) ? thisPart : parentPart + "." + thisPart;
                return true;

            case MethodCallExpression call:
                if (IsLinqMethod(call.Method.Name))
                {
                    // Drill down into the first argument (e.g., blog.Posts in blog.Posts.Where(...))
                    if (call.Arguments.Count > 0 && TryParsePath(call.Arguments[0], out var innerPath))
                    {
                        path = innerPath;
                        return true;
                    }
                }

                // Support Select with sub-lambda
                if (call.Method.Name == "Select" && call.Arguments.Count == 2 &&
                    call.Arguments[1] is LambdaExpression sub && TryParsePath(sub.Body, out var subPath))
                {
                    if (TryParsePath(call.Arguments[0], out var outerPath))
                    {
                        path = outerPath + "." + subPath;
                        return true;
                    }
                }

                break;
        }

        return true;
    }

    private static bool IsLinqMethod(string methodName)
    {
        return methodName is "Where" or "OrderBy" or "OrderByDescending" or "ThenBy" or "ThenByDescending" or "Take" or "Skip";
    }


    private static Expression RemoveConvert(Expression expression)
    {
        while (expression.NodeType == ExpressionType.Convert || expression.NodeType == ExpressionType.ConvertChecked)
        {
            expression = ((UnaryExpression)expression).Operand;
        }
        return expression;
    }
}