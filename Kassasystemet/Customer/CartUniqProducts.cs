using Kassasystemet.Products;

namespace Kassasystemet.Customer
{
    public class CartUniqProducts
    {
        public static List<Product> GatherProducts(List<Product> shoppingCart)
        {
            List<Product> uniqueProducts = new List<Product>();

            foreach (var product in shoppingCart)
            {
                bool found = false;
                foreach (var uniqueProduct in uniqueProducts)
                {
                    if (uniqueProduct.ProductName == product.ProductName)
                    {
                        uniqueProduct.Quantity += 1;
                        uniqueProduct.Price = product.Price;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    uniqueProducts.Add(new Product(
                        product.PLUCode,
                        product.ProductName,
                        product.Price,
                        product.Unit
                    ));
                }
            }
            return uniqueProducts;
        }
    }
}


