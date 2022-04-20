using ParserLib.Model;

namespace ParserLib.Services.Parsers;

public interface IParser
{
 List<Product> ParseRawData(string filePath);
   
}