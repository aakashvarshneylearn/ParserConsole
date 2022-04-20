using ParserLib.Parsers;

namespace ParserLib;

public interface IFactory
{
    IParser GetInstance(string file);
}