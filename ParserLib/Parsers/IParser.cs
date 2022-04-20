using ParserLib.Model;

namespace ParserLib.Parsers;

public interface IParser
{
 List<Product> ParseRawData(string filePath);
   
}