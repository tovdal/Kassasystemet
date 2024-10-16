using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Products
{
    public interface IProductLoader
    {
        List<Product> LoadProducts(string filePath);
    }
}
