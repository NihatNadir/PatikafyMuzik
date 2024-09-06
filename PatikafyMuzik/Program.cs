using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikafyMuzik
{
    public class Program
    {
        static void Main(string[] args)
        {
            var singerList = new List<Singer>() // Şarkıcı listesini oluşturdum ve değerleri aktardım 
            {
                new Singer("Ajda Pekkan",new List<string> {"Pop"},1968,20000000),
                new Singer("Sezen Aksu",new List<string> {"Pop","Türk Halk Müziği"},1971,10000000),
                new Singer("Funda Arar",new List<string> {"Pop"},1999,3000000),
                new Singer("Sertab Erener",new List<string> {"Pop"},1994,5000000),
                new Singer("Sıla",new List<string> {"Pop"},2009,3000000),
                new Singer("Serdar Ortaç",new List<string> {"Pop"},1994,10000000),
                new Singer("Tarkan",new List<string> {"Pop"},1992,40000000),
                new Singer("Hande Yener",new List<string> {"Pop"},1999,7000000),
                new Singer("Hadise",new List<string> {"Pop"},2005,5000000),
                new Singer("Gülben Ergen",new List<string> {"Pop","Türk Halk Müziği"},1997,10000000),
                new Singer("Neşet Ertaş",new List<string> {"Türk Sanat Müziği","Türk Halk Müziği"},1960,2000000)

            };

            var filteredList = singerList.Where(x => x.FullName.StartsWith("S")); // FullName i S ile başlayan şarkıcıları filtreledim

            Console.WriteLine("Adı S ile başlayan şarkıcılar\n");

            foreach (var filter in filteredList) // Filtrelenen şarkıcıları tek tek yazdırdım.
            {
                Console.WriteLine(filter.FullName);
            }

            filteredList = null; // tekrar değişken oluşturmamak için null yaptım.

            Console.WriteLine("\n----------------------\nAlbüm satışları 10 milyon'un üzerinde olan şarkıcılar\n");

            filteredList = singerList.Where(x => x.Sales > 10000000); // Satış rakamı 10 milyon üzeri olanları filtreledim

            foreach (var filter in filteredList) // Filtrelenen şarkıcıları tek tek yazdırdım.
            {
                Console.WriteLine(filter.FullName);
            }



            Console.WriteLine("\n----------------------\n2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar\n");

            filteredList = singerList.Where(x => x.ReleaseYear < 2000 && x.Genre.Contains("Pop")); // Çıkış tarihi 2000 önce ve türü Pop olanları filtreledim.

            var groupByYear = filteredList.GroupBy(x => x.ReleaseYear); // Çıkış tarihine göre grupladım.

            foreach (var year in groupByYear.OrderBy(x => x.Key )) // Önce gruplandıkları yılı sıraladım ve bunlara göre yazdırdım.
            {
                Console.WriteLine("\n" + year.Key);

                foreach (var y in year.OrderBy(f => f.FullName )) // Yıla göre gruplandıktan sonra o filtreye ait isimleri sıralayarak isimlerini yazdırdım
                {
                    Console.WriteLine(y.FullName);
                }

            }

            Console.WriteLine("\n----------------------\nEn çok albüm satan şarkıcı\n");

            filteredList = null; // tekrar değişken oluşturmamak için null yaptım.

            var bestSeller = (from x in singerList // Satış rakamlarına göre sıralama yaptım burada sonuncu değeri aldım (son değer en yüksek)
                               orderby x.Sales
                               select x).LastOrDefault(); 
            
            Console.WriteLine(bestSeller.FullName);


            Console.WriteLine("\n----------------------\nEn yeni çıkış yapan şarkıcı ve en eski çıkış yapan şarkıcı\n");

            var lastSinger = (from x in singerList // Çıkış tarihlerine göre sıralama yaptım burada son değeri aldım (son değer en eski tarih)
                              orderby x.ReleaseYear
                              select x).LastOrDefault();

            var firstSinger = (from x in singerList // Çıkış tarihlerine göre sıralama yaptım burada son ilk aldım (ilk değer en yeni tarih)
                               orderby x.ReleaseYear
                              select x).FirstOrDefault();
            Console.WriteLine($"En yeni çıkış yapan şarkıcı {lastSinger.FullName}");
            Console.WriteLine($"En eski çıkış yapan şarkıcı {firstSinger.FullName}");
           
            Console.ReadLine();
        }
    }
}
