using Newtonsoft.Json;
using System;
using System.IO;

namespace ConsoleApp77
{
    internal class Program
    {
        private static object library;
        private static string folderName;

        static void Main(string[] args, object library)
        {

            string path = @"C:\Users\HP\source\repos\ConsoleApp77\ConsoleApp77\ConsoleApp77\";
            Directory.CreateDirectory(path + "Files");
            if (!File.Exists(path + @"Files\Database.json"))
            {
                File.Create(path + @"Files\Database.json");
            }

            bool check = true;
            do
            {
                Console.WriteLine("---------------------Menu----------------------");
                Console.WriteLine("Secim edin.");
                Console.WriteLine("1.AddBook");
                Console.WriteLine("2.Get book by id");
                Console.WriteLine("3.Remove book");
                Console.WriteLine("0.Quit");
                string choise = Console.ReadLine();

                switch (choise)
                {
                    case "1":

                        Console.WriteLine("1.Book Id-ni daxil edin.");
                        int bookId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("2.Book Name daxil edin.");
                        string BookName = Console.ReadLine();
                        Console.WriteLine("3.Book AuthorName daxil edin");
                        string BookAuthorName = Console.ReadLine();
                        Console.WriteLine("4.Book price daxil edin.");
                        double BookPrice = Convert.ToDouble(Console.ReadLine());
                        Book book = new Book
                        {
                            Id = bookId,
                            Name = BookName,
                            Price = BookPrice,
                            AuthorName = BookAuthorName,
                        };
                        library.AddBook(book);
                        var json = JsonConvert.SerializeObject(library);
                        // Add Database.Json
                        using (StreamWriter sw = new StreamWriter(path + folderName + @"\Database.json"))
                        {
                            sw.WriteLine(json);
                        }
                        break;
                    case "2":
                        Console.WriteLine("Id daxil edin");
                        int BookId = Convert.ToInt32(Console.ReadLine());
                        using (StreamReader sw = new StreamReader(path + folderName + @"\Database.json"))
                        {
                            var content = sw.ReadToEnd();
                            // DeSerialize
                            var jsonDecode = JsonConvert.DeserializeObject<Library>(content);
                            jsonDecode.GetBookById(Id).ShowInfo();
                        }
                        break;
                    case "3":
                        Console.WriteLine("Id daxil edin");
                        int BookId1 = Convert.ToInt32(Console.ReadLine());
                        using (StreamWriter sw = new StreamWriter(path + folderName + @"\Database.json"))
                        {
                            sw.WriteLine(library);
                        }
                        break;
                    case "0":
                        check = false;
                        break;
                    default:
                        break;
                }

            } while (check);
        }

        private static int IntInput(string v)
        {
            throw new NotImplementedException();
        }

        static int IntInput(string str1, string str2)
        {
            Console.WriteLine(str1);
            string inputStr = Console.ReadLine();
            int inputInt;
            while (!int.TryParse(inputStr, out inputInt))
            {
                Console.WriteLine(str2);
                inputStr = Console.ReadLine();
            }
            int.TryParse(inputStr, out inputInt);
            return inputInt;
        }
        static double DoubleInput(string str1, string str2)
        {
            Console.WriteLine(str1);
            string inputStr = Console.ReadLine();
            double inputDouble;
            while (!double.TryParse(inputStr, out inputDouble))
            {
                Console.WriteLine(str2);
                inputStr = Console.ReadLine();
            }
            double.TryParse(inputStr, out inputDouble);
            return inputDouble;
        }
    }
}
