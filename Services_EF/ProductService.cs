﻿using BusinessObjects_EF;
using Repositories_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_EF
{
    public class ProductService : IProductService
    {
        IProductRepository productRepository;

        public ProductService()
        {
           productRepository = new ProductRepository();
        }

        public bool DeleteProduct(int product)
        {
            return productRepository.DeleteProduct(product);
        }

        public List<Product> GetProducts()
        {
            return productRepository.GetProducts();
        }

        public List<Product> GetProductsByCategory(int cateId)
        {
            return productRepository.GetProductsByCategory(cateId);
        }

        public bool SaveProduct(Product product)
        {
            return productRepository.SaveProduct(product);
        }

        public bool UpdateProduct(Product product)
        {
           return productRepository.UpdateProduct(product);
        }
    }
}
