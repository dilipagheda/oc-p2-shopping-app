﻿using P2FixAnAppDotNetCode.Models.Repositories;
using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// This class provides services to manages the products
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public ProductService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Get all product from the inventory
        /// </summary>
        public List<Product> GetAllProducts()
        {
            // Dilip: DONE the changes. This change also required uncommenting the line from 'Product' unit test in ProductServiceTests.
            return _productRepository.GetAllProducts();
        }

        /// <summary>
        /// Get a product form the inventory by its id
        /// </summary>
        public Product GetProductById(int id)
        {
            // Dilip: DONE
            return _productRepository.GetProductById(id);
        }

        /// <summary>
        /// Update the quantities left for each product in the inventory depending of ordered the quantities
        /// </summary>
        public void UpdateProductQuantities(Cart cart)
        {
            // update product inventory by using _productRepository.UpdateProductStocks() method.
            // Dilip:Done
            var cartLines = cart.Lines as List<CartLine>;
            cartLines.ForEach(cartItem =>
            {
                _productRepository.UpdateProductStocks(cartItem.Product.Id, cartItem.Quantity);
            });
            
        }


    }
}
