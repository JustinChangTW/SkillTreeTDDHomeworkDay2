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
        private IEnumerable<Shop.Tests.Book> enumerable;

        public ShoppingCart(IEnumerable<Shop.Tests.Book> enumerable)
        {
            this.enumerable = enumerable;
        }

        public int CalculatePrice()
        {
            return 0;
        }
    }
}
