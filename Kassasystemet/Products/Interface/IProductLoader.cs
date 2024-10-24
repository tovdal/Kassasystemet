namespace Kassasystemet.Products.Interface
{
    public interface IProductLoader
    {
        List<Product> LoadProducts(string filePath);
    }
}
