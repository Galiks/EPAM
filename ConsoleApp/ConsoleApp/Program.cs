using DataAccessLayer.Implementations;
using DataAccessLayer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;

namespace ConsoleApp
{
    public class Program
    {
        private const string rootDirectoryName = "MainFolder";
        private const string dateFormat = "dd.MM.yyyy hh:mm:ss";
        private static DirectoryInfo directoryInfo;

        private static string _rootDirectory;

        private delegate void MyDelegate();

        public static string RootDirectory { get => _rootDirectory; private set => _rootDirectory = value; }
        public static DirectoryInfo MyDirectoryInfo { get => directoryInfo; private set => directoryInfo = value; }

        public static Dictionary<string, Delegate> BackUp { get; private set; }

        public static string PathToBackupFile { get; private set; }

        static Program()
        {
            PathToBackupFile = Directory.GetCurrentDirectory() + "\\backups.json";

            if (!Directory.Exists(rootDirectoryName))
            {
                var mainFolder = Directory.CreateDirectory(rootDirectoryName);
                RootDirectory = mainFolder.FullName;
                Directory.SetCurrentDirectory(RootDirectory);
            }
            else
            {
                RootDirectory = Directory.GetCurrentDirectory() + "\\" + rootDirectoryName;
                Directory.SetCurrentDirectory(RootDirectory);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Begin");

            var file = Observer.FindFile("New file.txt", "");

            Console.WriteLine("Create File" == Actions.CreateFile.ToString());

            Console.WriteLine("End");

            Console.ReadKey();
        }

        //private static void SerializeAndDeserialize()
        //{
        //    string text = "КУДА ИДЁМ С ПЯТОЧКОМ!";
        //    var bytes = Encoding.UTF8.GetBytes(text);
        //    var backup = new Backup(text, text, "Test1", "Test1", bytes, DateTime.Now);

        //    File.AppendAllText(PathToBackupFile, JsonConvert.SerializeObject(backup) + Environment.NewLine);

        //    JsonSerializer serializer = new JsonSerializer
        //    {
        //        NullValueHandling = NullValueHandling.Ignore
        //    };


        //    using (StreamReader streamReader = new StreamReader("backups.json"))
        //    {
        //        string line;
        //        while ((line = streamReader.ReadLine()) != null)
        //        {
        //            var item = JsonConvert.DeserializeObject<Backup>(line);

        //            string codingText = Convert.ToBase64String(item.Bytes);
        //            var enTextBytes = Convert.FromBase64String(codingText);
        //            string deText = Encoding.UTF8.GetString(enTextBytes);

        //            Console.WriteLine($"{item.CurrentName}{Environment.NewLine}{deText}{Environment.NewLine}");
        //        }
        //    }
        //}
    }
}
