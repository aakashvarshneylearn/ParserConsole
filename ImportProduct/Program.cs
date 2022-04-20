using Microsoft.Extensions.DependencyInjection;
using ParserLib;
using ParserLib.Implementation;


string dirPath = Environment.GetCommandLineArgs()[1];
var sp = Initialize();
try
{
    var parse = sp.GetService<IProcessParsing>();
    Console.WriteLine("Process Started");
    parse.Process(dirPath);
    Console.WriteLine("Process Completed");
}
catch (Exception e)
{
    Console.WriteLine(e);
}

ServiceProvider Initialize()
{
    var serviceProvider = new ServiceCollection();
    DependencyInjection.ConfigureServices(serviceProvider);
    return serviceProvider.BuildServiceProvider();
}
