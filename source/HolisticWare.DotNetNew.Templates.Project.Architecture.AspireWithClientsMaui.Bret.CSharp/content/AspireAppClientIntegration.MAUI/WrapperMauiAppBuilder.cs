using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Diagnostics.Metrics;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace AspireAppClientIntegration.MAUI
{
    public class WrapperMauiAppBuilder : IHostApplicationBuilder
    {
        readonly MauiAppBuilder _appBuilder;

        public WrapperMauiAppBuilder(MauiAppBuilder appBuilder)
        {
            _appBuilder = appBuilder;
        }

        public IConfigurationManager Configuration => _appBuilder.Configuration;

        public IHostEnvironment Environment => new MauiHostEnvironment();

        public ILoggingBuilder Logging => _appBuilder.Logging;

        public IMetricsBuilder Metrics => null;

        public IDictionary<object, object> Properties => throw new NotImplementedException();

        public IServiceCollection Services => _appBuilder.Services;

        public void ConfigureContainer<TContainerBuilder>(IServiceProviderFactory<TContainerBuilder> factory, Action<TContainerBuilder>? configure = null) where TContainerBuilder : notnull
        {
            _appBuilder.ConfigureContainer<TContainerBuilder>(factory, configure);
        }

        public MauiApp Build()
        {
            return _appBuilder.Build();
        }
    }

    internal class MauiHostEnvironment : IHostEnvironment
    {
        public string ApplicationName { get; set; } = typeof(MauiHostEnvironment).Assembly.GetName().Name;

        public IFileProvider ContentRootFileProvider { get; set; } = new PhysicalFileProvider(AppContext.BaseDirectory);

        public string ContentRootPath { get; set; } = AppContext.BaseDirectory;

        public string EnvironmentName { get; set; } = "Development"; // TODO: Get the correct EnvironmentName
    }
}
