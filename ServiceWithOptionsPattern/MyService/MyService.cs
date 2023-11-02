using Microsoft.Extensions.Options;

namespace ServiceWithOptionsPattern.MyService;

public class MyService : IMyService
{
    readonly MyOptions options;

    /// <summary>
    /// Initializes new instance of the <see cref="MyService"/> class.
    /// </summary>
    /// <param name="options"></param>
    public MyService(IOptions<MyOptions> options)
    {
        this.options = options.Value;
    }

    /// <inheritdoc/>
    public string? GetServerName()
    {
        return options.ServerName;
    }
}
