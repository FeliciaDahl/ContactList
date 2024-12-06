using Business.Interfaces;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.ConsoleApp.Interfaces;
using Presentation.ConsoleApp.Services;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {                                      //Här kan du ändra sökväg. Om ingen finns=fileService//
        services.AddSingleton<IFileService>(new FileService(@"c:\Projects", "testlist"));
        services.AddSingleton<IUserService, UserService>();
        services.AddSingleton<IMenuService, MenuService>();

    })
    .Build();

using var scope = host.Services.CreateScope();
var mainMenu = scope.ServiceProvider.GetRequiredService<IMenuService>();
mainMenu.Run();
