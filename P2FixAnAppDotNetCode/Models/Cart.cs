using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        /// <summary>
        /// Read-only property for dispaly only
        /// </summary>
        public IEnumerable<CartLine> Lines => GetCartLineList();

        /// <summary>
        /// Backing field for holding list of cart items
        /// </summary>
        private List<CartLine> _cartLines;
        
        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        private List<CartLine> GetCartLineList()
        {
            if(_cartLines == null)
            {
                _cartLines = new List<CartLine>();
            }
            return _cartLines;
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            // TODO implement the method
            // Dilip:DONE
            var cartItems = Lines as List<CartLine>;

            //check if the product alredy exists in the cart
            CartLine cartItem = cartItems.FirstOrDefault(item => item.Product.Id == product.Id);
            if (cartItem != null)
            {
                //update quantity if product already exists in the cart
                cartItems.Remove(cartItem);
                cartItem.Quantity += quantity;
                cartItems.Add(cartItem);
            }
            else
            {
                //add the product
                cartItems.Add(new CartLine() { Product = product, Quantity = quantity });
            }
        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            // TODO implement the method
            // Dilip:DONE
            var cartItems = Lines as List<CartLine>;
            double total = 0;
            cartItems.ForEach(item =>
            {
                total += item.Product.Price * item.Quantity;
            });
            return total;
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            // TODO implement the method
            // Dilip:DONE
            var cartItems = Lines as List<CartLine>;
            double averageValue = 0;
            double totalProducts = 0;
            cartItems.ForEach(item =>
            {
                totalProducts += item.Quantity;
            });
            averageValue = GetTotalValue() / totalProducts;
            return averageValue;
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            // TODO implement the method
            // Dilip: Done
            var cartItems = Lines as List<CartLine>;
            return cartItems.FirstOrDefault(item => item.Product.Id == productId).Product;
        }

        /// <summary>
        /// Get a specifid cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
