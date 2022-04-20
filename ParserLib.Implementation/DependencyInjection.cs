using Microsoft.Extensions.DependencyInjection;
using ParserLib.Implementation.DataProvider;
using ParserLib.Implementation.DataProvider.Implementation;
using ParserLib.Implementation.Services;
using ParserLib.Implementation.Services.Parsers;
using ParserLib.Parsers;

namespace ParserLib.Implementation;

public class DependencyInjection
{
    public static void ConfigureServices(IServiceCollection serviceProvider)
    {
        serviceProvider.AddSingleton<IFileReader, FileReader>();
        serviceProvider.AddSingleton<IParser, ParseCapterra>();
        serviceProvider.AddSingleton<IParser, ParseSoftwareadvice>();
        serviceProvider.AddSingleton<IFactory, Factory>();
        serviceProvider.AddSingleton<IProductService, ProductService>();
        serviceProvider.AddSingleton<IProductProvider, ProductProvider>();
        serviceProvider.AddSingleton<IProcessParsing, ProcessParsing>();
    }
}