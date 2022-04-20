using Microsoft.Extensions.DependencyInjection;
using ParserLib.Implementation;
using ParserLib.Model;
using ParserLib.Services;


string dirPath = Environment.GetCommandLineArgs()[1];

var sp = Initialize();

if (Directory.Exists(dirPath))
{
    var factory = sp.GetService<IFactory>();
    ProcessDirectory(dirPath, factory);
}
else
{
    Console.WriteLine("{0} is not a valid file or directory.", dirPath);
}

void ProcessDirectory(string targetDirectory, IFactory factory)
{
    // Process the list of files found in the directory.
    var fileEntries = Directory.GetFiles(targetDirectory);
    foreach (var file in fileEntries)
    {
        try
        {
            var data = factory.GetInstance(file);
            var products = data.ParseRawData(file);
            PrintProducts(products);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }

    // Recurse into subdirectories of this directory.
    var subdirectoryEntries = Directory.GetDirectories(targetDirectory);
    foreach (var subdirectory in subdirectoryEntries)
        ProcessDirectory(subdirectory, factory);
}



void PrintProducts(List<Product> products)
{
    foreach (var item in products)
    {
        Console.WriteLine("Product: ");
        if (!string.IsNullOrEmpty(item.Title))
            Console.WriteLine("Title : " + item.Title);
        if (!string.IsNullOrEmpty(item.Twitter))
            Console.WriteLine("Twitter : " + item.Twitter);
        if (item.Categories != null && item.Categories.Count > 0)
            Console.WriteLine("Categories : " + string.Join(',', item.Categories));
    }
}

ServiceProvider Initialize()
{
    var serviceProvider = new ServiceCollection();
    DependencyInjection.ConfigureServices(serviceProvider);
    return serviceProvider.BuildServiceProvider();
}