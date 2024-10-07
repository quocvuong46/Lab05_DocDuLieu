using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace DocDuLieuXML
{
  
        public class Book
        {
            public string ISBN { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public decimal Price { get; set; }
            public int YearPublished { get; set; }
        }
        internal class Program
        {

            private static void SaveToXmlFile(List<Book> books)
            {
                var serializer = new XmlSerializer(typeof(List<Book>));
                using (var writer = new StreamWriter("books.xml"))
                {
                    serializer.Serialize(writer, books);
                }
            }
            private static List<Book> LoadFromXmlFile()
            {
                var serializer = new XmlSerializer(typeof(List<Book>));
                using (var reader = new StreamReader("books.xml"))
                {
                    return (List<Book>)serializer.Deserialize(reader);
                }
            }
            public static void Main(string[] args)
            {
                // Tạo danh sách sách
                List<Book> books = new List<Book>
        {
            new Book { ISBN = "9782317267", Title = "A Programmer's Guide to ADO .Net using C#", Author = "Mahesh Chand", Price = 44.99m, YearPublished = 2002 },
            new Book { ISBN = "9781484234", Title = "Pro Entity Framework Core 1", Author = "Adam Freeman", Price = 44.99m, YearPublished = 2018 }
        };

                // Lưu vào tệp XML
                SaveToXmlFile(books);


                // Đọc từ tệp XML
                List<Book> loadedBooks = LoadFromXmlFile();

                // Hiển thị thông tin sách đã đọc
                foreach (var book in loadedBooks)
                {
                    Console.WriteLine($"ISBN: {book.ISBN}, Title: {book.Title}, Author: {book.Author}, Price: {book.Price}, Year: {book.YearPublished}");
                }
                Console.ReadLine();
            }
        }
    }

