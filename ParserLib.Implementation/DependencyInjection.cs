using Microsoft.Extensions.DependencyInjection;
using ParserLib.Implementation.Services;
using ParserLib.Implementation.Services.Parsers;
using ParserLib.Services;
using ParserLib.Services.Parsers;

namespace ParserLib.Implementation;

public class DependencyInjection
{
    public static void ConfigureServices(IServiceCollection serviceProvider)
    {
        serviceProvider.AddSingleton<IFileReader, FileReader>();
        serviceProvider.AddSingleton<IParser, ParseCapterra>();
        serviceProvider.AddSingleton<IParser, ParseSoftwareadvice>();
        serviceProvider.AddSingleton<IFactory, Factory>();
    }
}