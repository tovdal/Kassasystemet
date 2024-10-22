namespace Kassasystemet.Products
{
    public interface IProductLoader
    {
        List<Product> LoadProducts(string filePath);
    }
}
