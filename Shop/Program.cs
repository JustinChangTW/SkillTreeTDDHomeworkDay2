using System.Collections.Generic;
using System.Linq;

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
        private readonly IEnumerable<Book> _books;


        public ShoppingCart(IEnumerable<Book> books)
        {
            this._books = books;
        }

        public double CalculatePrice(IEnumerable<BuyBook> buybooks)
        {
            double totalPrice = 0;

            //分套
            var bookGroupgroups = buybooks.SetGroup(_books);
            //計算每一套金額
            foreach (var bookGroupgroup in bookGroupgroups)
            {        
                var kitcount= 0;
                var kitTotalPrice = 0.0;
                foreach (var book in bookGroupgroup)
                {
                    kitcount += book.FirstOrDefault().Key;
                    kitTotalPrice += book.FirstOrDefault().Value;
                }
                //取得折扣
                var discount = CalculateDiscount(kitcount);
                totalPrice += kitTotalPrice * discount;
            }

            return totalPrice;
        }

        internal double CalculateDiscount(int count )
        {
            var discount = 1.0;
            if (count == 2) discount =  0.95;
            if (count == 3) discount =  0.90;
            if (count == 4) discount =  0.80;
            if (count == 5) discount =  0.75;
            return discount;
        }

    }

    public static class ShoppingCarExtensions
    {
        public static Dictionary<int, double>[][] SetDefault(this Dictionary<int, double>[][] bookgriup, int kit, int volume)
        {
            var volumemapprice = new Dictionary<int, double> { { 0, 0 } };
            var _kit = 0;
            for (; _kit <= kit - 1; _kit++)
            {
                bookgriup[_kit] = new Dictionary<int, double>[volume];
                var _volume = 0;
                for (; _volume <= volume - 1; _volume++)
                {
                    bookgriup[_kit][_volume] = volumemapprice;
                }
            }
            return bookgriup;
        }

        public static Dictionary<int, double>[][] SetGroup(this IEnumerable<BuyBook> buybooks, IEnumerable<Book> books)
        {
            var buyBooks = buybooks as IList<BuyBook> ?? buybooks.ToList();
            var maxquantity = buyBooks.Max(o => o.Quantity); //找尋最多數量的集數
            var bookmax = books.Count();                    //商品數量
            var bookgriup = new Dictionary<int, double>[maxquantity][];
            bookgriup[0] = new Dictionary<int, double>[bookmax]; // {0, 0, 0, 0, 0};

            bookgriup.SetDefault(maxquantity, bookmax);

            var voluem = 0;
            foreach (var book in books)
            {
                var buybookVolume = buyBooks.SingleOrDefault(o => o.Serial == book.Serial);

                if (buybookVolume != null)
                {
                    for (var kit = 0; kit <= buybookVolume.Quantity - 1; kit++)
                    {
                        var volumemapprice = new Dictionary<int, double> { { 1, buybookVolume.Price } };
                        bookgriup[kit][voluem] = volumemapprice;
                    }
                }
                voluem++;
            }

            return bookgriup;
        }


    }

    public class Book
    {
        public string Serial { get; set; }
        public string Name { get; set; }
        public int Volume { get; set; }
        public double Price { get; set; }
    }

    public class BuyBook : Book
    {
        public int Quantity { get; set; }
    }
}
