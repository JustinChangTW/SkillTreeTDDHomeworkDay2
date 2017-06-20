using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class ShoppingCart
    {
        private IEnumerable<Book> _books;

        public ShoppingCart(IEnumerable<Book> books)
        {
            this._books = books;
        }

        public int CalculatePrice(IEnumerable<BuyBook> buybooks)
        {
            var totalPrice = 0;
            foreach (var book in buybooks)
            {
                totalPrice += book.Price;
            }
            return totalPrice;
        }


    }

    public class Book
    {
        public string Serial { get; set; }
        public string Name { get; set; }
        public int volume { get; set; }
        public int Price { get; set; }
    }

    public class BuyBook : Book
    {
        public int Quantity { get; set; }
    }
}
