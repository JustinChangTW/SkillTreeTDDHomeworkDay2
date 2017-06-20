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
        public void CalculatePriceTest_Buy_Book_Number1_Quantity1_TotalPrice100()
        {
            //arrange
            var shoppingcart = new ShoppingCart(GetBook());
            List<BuyBook> buybook = new List<BuyBook>()
            {
                new BuyBook() { Serial="B001",Name="哈利波特第一集",Price=100,volume=1,Quantity=1 }
            };
            var expected = 100;
            //act
            var actual = shoppingcart.CalculatePrice(buybook);

            //assert
            Assert.AreEqual(expected, actual);
        }

        public IEnumerable<Book> GetBook()
        {
            return new List<Book>()
            {
                new Book() { Serial="B001",Name="哈利波特第一集",volume=1,Price=100 },
                new Book() { Serial="B002",Name="哈利波特第二集",volume=1,Price=100 },
                new Book() { Serial="B003",Name="哈利波特第三集",volume=1,Price=100 },
                new Book() { Serial="B004",Name="哈利波特第四集",volume=1,Price=100 },
                new Book() { Serial="B005",Name="哈利波特第五集",volume=1,Price=100 }
            };
        }
    }

}