using ParserLib.Services.Parsers;

namespace ParserLib.Services;

public interface IFactory
{
    IParser GetInstance(string file);
}