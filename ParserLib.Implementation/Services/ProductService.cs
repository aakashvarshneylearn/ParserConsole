using ParserLib.Implementation.DataProvider;
using ParserLib.Model;

namespace ParserLib.Implementation.Services;

internal class ProductService: IProductService
{
    private readonly IProductProvider _productProvider;
    public ProductService(IProductProvider productProvider)
    {
        _productProvider = productProvider ?? throw new ArgumentNullException(nameof(productProvider));
    }
    public bool AddRange(List<Product> product)
    {
        _productProvider.AddRange(product);
        return true;
    }

    public List<Product> GetAll()
    {
        return _productProvider.GetAll();
    }
}