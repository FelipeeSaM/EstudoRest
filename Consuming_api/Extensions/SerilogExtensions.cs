using Serilog;

namespace Consuming_api.Extensions {
    public static class SerilogExtensions {
        public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder, IConfiguration config, string app_name) {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

            builder.Logging.ClearProviders();
            builder.Host.UseSerilog(Log.Logger, true);

            return builder;
        }
    }
}
