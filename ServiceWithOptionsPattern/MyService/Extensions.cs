using Microsoft.Extensions.DependencyInjection;

namespace ServiceWithOptionsPattern.MyService;

public static class Extensions
{
    /// <summary>
    /// Extension method to add MyService service to the host application builder.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="options">The options action.</param>
    public static void AddMyService(this IServiceCollection services, Action<MyOptions>? options = null)
    {
        if (options != null)
        {
            services.Configure(options);
        }

        // Line above can be written as:
        // MyOptions myOptions = new();
        // options?.Invoke(myOptions);
        // IOptions<MyOptions> o = Options.Create(myOptions);
        // services.AddSingleton(o);

        services.AddTransient<IMyService, MyService>();
    }
}
