using Newtonsoft.Json.Linq;
using ParserLib.Exceptions;
using ParserLib.Model;
using ParserLib.Services.Parsers;

namespace ParserLib.Implementation.Services.Parsers;

internal class ParseCapterra : IParser
{
    private readonly IFileReader _fileReader;
    internal ParseCapterra(IFileReader fileReader)
    {
        _fileReader = fileReader;
    }
    public List<Product> ParseRawData(string filePath)
    {
        var fileData = _fileReader.Read(filePath);
        var products = new List<Product>();
        try
        {
            var jsonData = JArray.Parse(fileData);
            foreach (dynamic item in jsonData)
            {
                var product = new Product
                {
                    Title = item.name,
                    Twitter = item.twitter
                };
                if (item.tags != null)
                    product.Categories = ((string)item.tags).Split(',').ToList();
                products.Add(product);
            }

        }
        catch (Exception e)
        {
            throw new ParsingException($"Issue occured while parsing {filePath} in class {this.GetType().FullName}", e);
        }

        return products;
    }



}