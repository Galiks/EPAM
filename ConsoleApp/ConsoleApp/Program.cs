using DataAccessLayer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        private const string pathToFile = "backups.json";

        static void Main(string[] args)
        {
            #region Bla-bla
            //string pathToFile = @"E:\Документы\GitHub\Galiks\EPAM\ConsoleApp\ConsoleApp\Test";
            //var directory = Directory.GetFiles(pathToFile, "*Task.txt");

            //if (directory == null || directory.Length == 0)
            //{
            //    Console.WriteLine("EMPTY!");
            //}

            //foreach (var item in directory)
            //{
            //    if (item != null)
            //    {
            //        Console.WriteLine(item);
            //        Console.WriteLine($"Файл - {item.Split('\\').Last()}");
            //        Console.WriteLine();
            //        using (StreamReader reader = new StreamReader(item, Encoding.ASCII))
            //        {
            //            string line;
            //            while ((line = reader.ReadLine()) != null)
            //            {
            //                Console.WriteLine(line);
            //            }
            //        }
            //    }
            //} 
            #endregion
            string text = "КУДА ИДЁМ С ПЯТОЧКОМ!";
            var bytes = Encoding.UTF8.GetBytes(text);
            var backup = new Backup(text, "Test1", bytes, DateTime.Now, DateTime.Now);

            File.AppendAllText(pathToFile, JsonConvert.SerializeObject(backup) + Environment.NewLine);

            JsonSerializer serializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore
            };


            using (StreamReader streamReader = new StreamReader("backups.json"))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var item = JsonConvert.DeserializeObject<Backup>(line);

                    string codingText = Convert.ToBase64String(item.Bytes);
                    var enTextBytes = Convert.FromBase64String(codingText);
                    string deText = Encoding.UTF8.GetString(enTextBytes);

                    Console.WriteLine($"{item.FileName}{Environment.NewLine}{deText}{Environment.NewLine}");
                }
            }

                Console.ReadKey();
        }

        private static void Test(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);

            Backup[] backups = new Backup[]
            {
                new Backup(text, "Test1", bytes, DateTime.Now, DateTime.Now),
                new Backup(text, "Test2", bytes, DateTime.Now, DateTime.Now),
                new Backup(text, "Test3", bytes, DateTime.Now, DateTime.Now),
                new Backup(text, "Test4", bytes, DateTime.Now, DateTime.Now)
            };

            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Backup[]));

            using (FileStream fs = new FileStream("backups.json", FileMode.Append))
            {
                jsonFormatter.WriteObject(fs, backups);
            }

            using (FileStream fs = new FileStream("backups.json", FileMode.Open))
            {
                Backup[] newBackups = (Backup[])jsonFormatter.ReadObject(fs);

                foreach (var item in newBackups)
                {
                    string codingText = Convert.ToBase64String(item.Bytes);
                    var enTextBytes = Convert.FromBase64String(codingText);
                    string deText = Encoding.UTF8.GetString(enTextBytes);

                    Console.WriteLine($"{item.FileName}{Environment.NewLine}{deText}{Environment.NewLine}");
                }
            }
        }
    }
}
