using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Tests
{
    [TestClass()]
    public class ShoppingCartTests
    {
        [TestMethod()]
        public void CalculatePriceTest()
        {
            //
            var books = GetBook();
            var shoppings = new List<Shopping>()
            {
                new Shopping() { Serial="001",Name="哈利波特-1",Number="1",Price=100,Quantity=1 }
            };
            var shopingCart = new ShoppingCart();
            //Assert.Fail();

        }

        public IEnumerable<Book> GetBook()
        {
            return new List<Book>()
            {
                new Book() { Serial="001",Name="哈利波特-1",Number="1",Price=100 },
                new Book() { Serial="002",Name="哈利波特-2",Number="2",Price=100 },
                new Book() { Serial="003",Name="哈利波特-3",Number="3",Price=100 },
                new Book() { Serial="004",Name="哈利波特-4",Number="4",Price=100 },
                new Book() { Serial="005",Name="哈利波特-5",Number="5",Price=100 }
            };
        }
    }

    public class Book
    {
        public string Serial { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int Price { get; set; }
    }

    public class Shopping:Book
    {
        public int Quantity { get; set; }
    }
}