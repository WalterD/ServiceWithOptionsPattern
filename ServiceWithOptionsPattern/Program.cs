using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using ServiceWithOptionsPattern.MyService;

var builder = Host.CreateApplicationBuilder();

// Add service with options.
builder.Services.AddMyService(options =>
{
    options.PortNumber = 123;
    options.ServerName = "My Server";
    options.BaseUrl = "http://somewhere.com";
});

var host = builder.Build();

// Test: check if MyOptions is available.
var myOptions = host.Services.GetRequiredService<IOptions<MyOptions>>();
Console.WriteLine($"Server Name: {myOptions.Value.ServerName}");

// Test: check if MyOptions is provided to MyService service.
var myService = host.Services.GetRequiredService<IMyService>();
Console.WriteLine($"ServerName: {myService.GetServerName()}");
