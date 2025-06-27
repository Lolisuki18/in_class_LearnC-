using BusinessObject;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository iProductRepository;

        public ProductService()
        {
            iProductRepository = new ProductRepository();
        }

        public bool DeleteProduct(int id)
        {
            return iProductRepository.DeleteProduct(id);
        }

        public bool DeleteProduct(Product product)
        {
            return iProductRepository.DeleteProduct(product);
        }

        public void GenerateSampleDataset()
        {
            iProductRepository.GenerateSampleDataset();
        }

        public List<Product> GetAllProducts()
        {
            return iProductRepository.GetAllProducts();
        }

        public Product GetProduct(int id)
        {
            return iProductRepository.GetProduct(id);
        }

        public bool SaveProduct(Product product)
        {
            return iProductRepository.SaveProduct(product);
        }

        public bool UpdateProduct(Product product)
        {
            return iProductRepository.UpdateProduct(product);
        }
    }
}
