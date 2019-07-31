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

        private static string pathToBackupFile;
        private static DirectoryInfo directoryInfo;

        private static string _rootDirectory;

        private static event Action<Backup> WriteBackupEvent;

        private delegate void MyDelegate();

        public static string RootDirectory { get => _rootDirectory; private set => _rootDirectory = value; }
        public static DirectoryInfo MyDirectoryInfo { get => directoryInfo; private set => directoryInfo = value; }

        public static Dictionary<string, Delegate> BackUp { get; private set; }

        static Program()
        {
            pathToBackupFile = Directory.GetCurrentDirectory() + "\\backups.json";
            WriteBackupEvent = WriteBackup;

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

            MyDirectoryInfo = new DirectoryInfo(RootDirectory);

        }

        static void Main(string[] args)
        {

            //31.07.2019 23:22:38

            //CreateFile("New file");
            //Thread.Sleep(2000);
            //CreateFile("New file 2");

            //string date = "31.07.2019 23:22:38";
            //Backup item = GetBackupByUpdateAt(date);

            //Console.WriteLine(item);

            //01.08.2019 02:15:39 - update
            //01.08.2019 02:14:53 - create

            WriteTextInFile("New file.txt", "I wanna cry, don't like files");
            //WriteTextInFile("New file 2.txt", "I wanna cry, don't like files");

            foreach (var item2 in GetBackups())
            {
                Console.WriteLine(item2);
            }

            #region Observer



            #endregion




            Console.ReadKey();
        }

        private static void WriteTextInFile(string fileNameOrPath, string text)
        {
            var file = FindFile(fileNameOrPath, MyDirectoryInfo);

            if (file == null)
            {
                Console.WriteLine("File doesn't found");
                return;
            }

            //StreamReader reader = new file.OpenText()

            using (StreamWriter writer = file.AppendText())
            {
                writer.WriteLine(text);
            }

            var bytes = ConvertTextOnBytes(text);

            WriteBackupEvent(new Backup(file.Name, file.Name, file.FullName, file.FullName, bytes, "Update text"));
        }

        private static void ReturnUpdate(string fileName)
        {
            string date = "31.07.2019 23:22:38";
        }

        private static void DeleteFile(string fileName)
        {
            var file = FindFile(fileName, MyDirectoryInfo);

            if (file == null)
            {
                Console.WriteLine("File doesn't found");
                return;
            }

            file.Delete();
        }

        private static FileInfo FindFile(string fileName, DirectoryInfo directoryInfo)
        {
            try
            {
                var files = directoryInfo.GetFiles(fileName).ToArray();
                foreach (var file in files)
                {
                    try
                    {
                        return file;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"ERROR! {e.Message}");
                        return null;
                    }
                }
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    var file = FindFile(fileName, directory);
                    return file;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR! {e.Message}");
                return null;
            }
            return null;
        }

        private static Backup GetBackupByUpdateAt(string date)
        {
            var dateTime = DateTime.Parse(date);

            var item = GetBackups().Where(b => b.UpdatedAt.ToString(dateFormat) == dateTime.ToString(dateFormat)).FirstOrDefault();
            return item;
        }

        private static void MoveTo(string path)
        {
            string[] splitPath = path.Split('\\', StringSplitOptions.RemoveEmptyEntries);
        }

        public static void WriteBackup(Backup backup)
        {
            File.AppendAllText(pathToBackupFile, JsonConvert.SerializeObject(backup) + Environment.NewLine);
        }

        public static void CreateFolder(string name)
        {
            if(!IsExistsDirectory(ref name))
            {
                var newFolder = Directory.CreateDirectory(name);

                Directory.SetCurrentDirectory(newFolder.FullName);
            }
        }

        public static void CreateFile(string name)
        {
            if (!IsExistsFile(ref name))
            {
                File.Create(name + ".txt");
            }
            var bytes = ConvertTextOnBytes("");

            WriteBackupEvent(new Backup(name, name, Directory.GetCurrentDirectory(), Directory.GetCurrentDirectory(), bytes, "Create File"));
        }

        private static byte[] ConvertTextOnBytes(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        private static bool IsExistsDirectory(ref string name)
        {
            if (Directory.Exists(name))
            {
                name = name + "_свежайшее";
                IsExistsDirectory(ref name);
            }
            return false;
        }

        private static bool IsExistsFile(ref string name)
        {
            if (File.Exists(name + ".txt"))
            {
                name = name + "_свежайшее";
                IsExistsFile(ref name);
            }
            return false;
        }

        public static IEnumerable<Backup> GetBackups()
        {
            using (StreamReader streamReader = new StreamReader(pathToBackupFile))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Backup backup = JsonConvert.DeserializeObject<Backup>(line);
                    yield return backup;
                }
            }
        }

        private static void SerializeAndDeserialize()
        {
            string text = "КУДА ИДЁМ С ПЯТОЧКОМ!";
            var bytes = Encoding.UTF8.GetBytes(text);
            var backup = new Backup(text, text, "Test1", "Test1", bytes, DateTime.Now, DateTime.Now);

            File.AppendAllText(pathToBackupFile, JsonConvert.SerializeObject(backup) + Environment.NewLine);

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

                    Console.WriteLine($"{item.CurrentName}{Environment.NewLine}{deText}{Environment.NewLine}");
                }
            }
        }

        public static string ConvertBytesToString(byte[] bytes)
        {
            string codingText = Convert.ToBase64String(bytes);
            var enTextBytes = Convert.FromBase64String(codingText);
            string deText = Encoding.UTF8.GetString(enTextBytes);

            return deText;
        }

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
    }
}
