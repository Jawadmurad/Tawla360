using System.Data;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.PostgreSQL;

namespace Tawla._360.Logging;

public static class SerilogConfiguration
{
    public static IHostBuilder UseLogging(this IHostBuilder host, string connectionString)
    {
        return host.UseSerilog((context, services, configureLogger) =>
{
    var configuration = context.Configuration;
    configureLogger
        .ReadFrom.Configuration(configuration)
        .Enrich.FromLogContext()
        .Enrich.WithEnvironmentName()
        .Enrich.WithThreadId()
        .WriteTo.Console()
        .WriteTo.PostgreSQL(
            connectionString,
            "Logs",
            needAutoCreateTable: true,
            columnOptions: new Dictionary<string, ColumnWriterBase>
                    {
                        {"Message", new RenderedMessageColumnWriter() },
                        {"MessageTemplate", new MessageTemplateColumnWriter() },
                        {"Level", new LevelColumnWriter() },
                        {"TimeStamp", new TimestampColumnWriter() },
                        {"Exception", new ExceptionColumnWriter() },
                        {"LogEvent", new LogEventSerializedColumnWriter() },
                        {"CorrelationId", new SinglePropertyColumnWriter("CorrelationId", dbType: NpgsqlTypes.NpgsqlDbType.Uuid,writeMethod:PropertyWriteMethod.Raw,format:null,columnLength:null)}
                    }
        );
});

    }
}
