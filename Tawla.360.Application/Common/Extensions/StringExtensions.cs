using System;

namespace Tawla._360.Application.Common.Extensions;

public static class StringExtensions
{
    public static string ToPascalCase(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;

        // split on underscores or spaces
        var words = input.Split(new[] { '_', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        return string.Concat(words.Select(w => char.ToUpperInvariant(w[0]) + w.Substring(1)));
    }
}
