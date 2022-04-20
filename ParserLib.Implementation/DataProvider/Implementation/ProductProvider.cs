using ParserLib.Model;

namespace ParserLib.Implementation.DataProvider.Implementation;

internal class ProductProvider : IProductProvider
{
    private static List<Product> _products = new List<Product>();
    public bool AddRange(List<Product> product)
    {
        _products.AddRange(product);
        return true;
    }

    public List<Product> GetAll()
    {
        return _products;
    }
}