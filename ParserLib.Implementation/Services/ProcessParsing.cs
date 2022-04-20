using ParserLib.Model;

namespace ParserLib.Implementation.Services;

internal class ProcessParsing : IProcessParsing
{
    private readonly IFactory _factory;
    private readonly IProductService _productService;

    public ProcessParsing(IFactory factory,IProductService productService)
    {
        _factory=factory ?? throw new ArgumentNullException(nameof(factory));
        _productService=productService ?? throw new ArgumentNullException(nameof(productService));
    }

    public void Process( string dirPath)
    {
        if (Directory.Exists(dirPath))
        {
           
            ProcessDirectory(dirPath);
            PrintProducts(_productService.GetAll());
        }
        else
        {
            Console.WriteLine("{0} is not a valid file or directory.", dirPath);
        }
    }
    void ProcessDirectory(string targetDirectory)
    {
        // Process the list of files found in the directory.
        var fileEntries = Directory.GetFiles(targetDirectory);
        foreach (var file in fileEntries)
        {
            try
            {
                var data = _factory.GetInstance(file);
                var products = data.ParseRawData(file);
                _productService.AddRange(products);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        // Recurse into subdirectories of this directory.
        var subdirectoryEntries = Directory.GetDirectories(targetDirectory);
        foreach (var subdirectory in subdirectoryEntries)
            ProcessDirectory(subdirectory);
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
}