using ParserLib.Model;

namespace ParserLib;

public interface IProductService
{
    bool AddRange(List<Product> product);
    List<Product> GetAll();
}