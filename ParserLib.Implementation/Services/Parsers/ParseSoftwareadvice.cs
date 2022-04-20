using Newtonsoft.Json;
using ParserLib.Exceptions;
using ParserLib.Model;
using ParserLib.Parsers;

namespace ParserLib.Implementation.Services.Parsers;

internal class ParseSoftwareadvice : IParser
{
    private readonly IFileReader _fileReader;
    public ParseSoftwareadvice(IFileReader fileReader)
    {
        _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
    }
    public List<Product> ParseRawData(string filePath)
    {
        var fileData = _fileReader.Read(filePath);
        ProductsVm? productsVm;
        try
        {
            productsVm = JsonConvert.DeserializeObject<ProductsVm>(fileData);
        }
        catch (Exception e)
        {
            throw new ParsingException($"Issue occured while parsing {filePath} in class {this.GetType().FullName}", e);
        }
        if (productsVm != null)
            return productsVm.Products;
        return new List<Product>();

    }


}