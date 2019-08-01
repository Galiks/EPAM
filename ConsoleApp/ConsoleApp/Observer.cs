using DataAccessLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    public static class Observer
    {
        private static readonly DirectoryInfo myDirectoryInfo;

        public static DirectoryInfo MyDirectoryInfo => myDirectoryInfo;

        private static event Action<Backup> WriteBackupEvent;

        static Observer()
        {
            myDirectoryInfo = new DirectoryInfo(Program.RootDirectory);
            WriteBackupEvent = WriteBackup;
        }

        /// <summary>
        /// Записывает еткст в файл
        /// </summary>
        /// <param name="fileNameOrPath"></param>
        /// <param name="text"></param>
        public static void WriteTextInFile(string fileNameOrPath, string text)
        {
            var file = FindFile(fileNameOrPath, fileNameOrPath);

            if (file == null)
            {
                Console.WriteLine("File doesn't found");
                return;
            }

            StringBuilder stringBuilder = new StringBuilder();

            using (StreamReader reader = file.OpenText())
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    stringBuilder.Append(reader.ReadLine());
                }
            }

            using (StreamWriter writer = file.AppendText())
            {
                writer.WriteLine(text);
            }

            var bytes = ConvertTextOnBytes(stringBuilder.ToString());

            WriteBackupEvent(new Backup(file.Name, file.Name, file.FullName, file.FullName, bytes, "Update text"));
        }

        /// <summary>
        /// Удаляет файл
        /// </summary>
        /// <param name="fileName"></param>
        public static void DeleteFile(string filePath)
        {
            string[] splitPath = filePath.Split('\\');

            string fileName = splitPath.Last();

            FileInfo file = FindFile(fileName, filePath);

            if (file == null)
            {
                Console.WriteLine("File doesn't found");
                return;
            }

            byte[] bytes = ConvertTextOnBytes(file.OpenText().ReadToEnd());

            file.Delete();

            WriteBackupEvent(new Backup(file.Name, file.Name, file.FullName, file.FullName, bytes, "Delete file"));
        }

        /// <summary>
        /// Создаёт файл
        /// </summary>
        /// <param name="name"></param>
        public static void CreateFile(string name)
        {
            if (!IsExistsFile(ref name))
            {
                name = name + ".txt";
                var file = File.Create(name);
                file.Close();
            }
            var bytes = ConvertTextOnBytes("");

            WriteBackupEvent(new Backup(name, name, Directory.GetCurrentDirectory(), Directory.GetCurrentDirectory(), bytes, "Create file"));
        }

        public static void MoveFile(string name)
        {

            var bytes = ConvertTextOnBytes("");

            WriteBackupEvent(new Backup(name, name, "", "", bytes, "Move file"));
        }

        /// <summary>
        /// Создаёт папку
        /// </summary>
        /// <param name="name"></param>
        public static void CreateFolder(string name)
        {
            if (!IsExistsDirectory(ref name))
            {
                var newFolder = Directory.CreateDirectory(name);
            }
        }

        /// <summary>
        /// Проверяет существование папки
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static bool IsExistsDirectory(ref string name)
        {
            if (Directory.Exists(name))
            {
                name = name + "_свежайшее";
                IsExistsDirectory(ref name);
            }
            return false;
        }

        /// <summary>
        /// Проверяет существование файла
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static bool IsExistsFile(ref string name)
        {
            if (File.Exists(name + ".txt"))
            {
                name = name + "_свежайшее";
                IsExistsFile(ref name);
            }
            return false;
        }

        /// <summary>
        /// Ищет файл
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="directoryInfo"></param>
        /// <returns></returns>
        public static FileInfo FindFile(string fileName, string filePath)
        {
            string[] splitPath = filePath.Split('\\');

            DirectoryInfo directoryInfo;

            if (splitPath.Length == 1)
            {
                directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\" + filePath);
            }
            else
            {
                StringBuilder path = new StringBuilder();
                for (int i = 1; i < splitPath.Length; i++)
                {
                    path.Append("\\" + splitPath[i]);
                }

                directoryInfo = new DirectoryInfo(MyDirectoryInfo.FullName + path.ToString());
            }
           
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
                    var file = FindFile(fileName, directory.FullName);
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

        /// <summary>
        /// Записывает изменения в файл
        /// </summary>
        /// <param name="backup"></param>
        public static void WriteBackup(Backup backup)
        {
            File.AppendAllText(Program.PathToBackupFile, JsonConvert.SerializeObject(backup) + Environment.NewLine);
        }


        public static byte[] ConvertTextOnBytes(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        public static void SetCurrentDirectory(string path)
        {


            Directory.SetCurrentDirectory(path);
        }
    }
}
