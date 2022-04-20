using ParserLib.Model;

namespace ParserLib.Implementation.DataProvider;

internal interface IProductProvider
{
    bool AddRange(List<Product> product);
    List<Product> GetAll();
}