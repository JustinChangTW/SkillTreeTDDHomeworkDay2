using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public double CalculatePrice(IEnumerable<BuyBook> buybooks)
        {
            double totalPrice = 0;

            var groups = SetGroup(buybooks); //分套
            var kitcount = 0;
            double kitTotalPrice = 0;
            for (var kit=0;kit<=groups.GetLength(0)-1;kit++)
            {
                kitTotalPrice = 0;
                kitcount = 0;
                for (var volume = 0; volume <= groups[kit].GetLength(0)-1; volume++)
                {
                    kitcount += (groups[kit][volume]).FirstOrDefault().Key;
                    kitTotalPrice += (groups[kit][volume]).FirstOrDefault().Value;
                }

                kitTotalPrice = CalculateDiscount(kitcount, kitTotalPrice);
                totalPrice += kitTotalPrice;
            }
            return totalPrice;
        }

        private double CalculateDiscount(int count , double totalPrice)
        {
            if (count == 2) totalPrice = totalPrice * 0.95;
            if (count == 3) totalPrice = totalPrice * 0.90;
            if (count == 4) totalPrice = totalPrice * 0.80;
            if (count == 5) totalPrice = totalPrice * 0.75;
            return totalPrice;
        }

        private Dictionary<int, double>[][] SetGroup(IEnumerable<BuyBook> buybooks)
        {

            var maxquantity = buybooks.Max(o => o.Quantity); //找尋最多數量的集數
            var bookmax = _books.Count();                    //商品數量
            Dictionary<int, double>[][] bookgriup = new Dictionary<int, double>[maxquantity][];
            bookgriup[0] = new Dictionary<int, double>[bookmax];// {0, 0, 0, 0, 0};

            SetDefault(bookgriup,maxquantity, bookmax);

            var voluem = 0;
            foreach(var book in _books)
            {
                var buybookVolume = buybooks.Where(o => o.Serial == book.Serial).SingleOrDefault();

                if (buybookVolume != null)
                {
                    for (var kit = 0; kit <= buybookVolume.Quantity - 1; kit++)
                    {
                        var volumemapprice = new Dictionary<int, double>();
                        volumemapprice.Add(1, buybookVolume.Price);
                        bookgriup[kit][voluem] = volumemapprice;
                    }
                }
                voluem++; 
            }

            return bookgriup;
        }

        private void SetDefault(Dictionary<int, double>[][] bookgriup,int kit,int volume)
        {
            var volumemapprice = new Dictionary<int, double>();
            volumemapprice.Add(0, 0);
            try
            {
                for (var _kit = 0; _kit <= kit - 1; _kit++)
                {
                    bookgriup[_kit] = new Dictionary<int, double>[volume];
                    for (var _volume = 0; _volume <= volume - 1; _volume++)
                    {
                        bookgriup[_kit][_volume] = volumemapprice;
                    }
                }
            }
            catch(Exception e)
            {
                var a = e;
            }
        }
    }

    public class Book
    {
        public string Serial { get; set; }
        public string Name { get; set; }
        public int volume { get; set; }
        public double Price { get; set; }
    }

    public class BuyBook : Book
    {
        public int Quantity { get; set; }
    }
}
