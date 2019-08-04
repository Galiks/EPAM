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
            WriteBackupEvent += WriteBackup;
        }

        /// <summary>
        /// Записывает еткст в файл
        /// </summary>
        /// <param name="fileNameOrPath"></param>
        /// <param name="text"></param>
        public static void UpdateText(string fileNameOrPath, string text)
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

            WriteBackupEvent(new Backup(file.Name, file.Name, file.FullName, file.FullName, bytes, Actions.UpdateFile));
        }

        /// <summary>
        /// Удаляет файл
        /// </summary>
        /// <param name="fileName"></param>
        public static void DeleteFile(string filePath)
        {
            string fileName = GetNameFromPath(filePath);

            FileInfo file = FindFile(fileName, filePath);

            if (file == null)
            {
                Console.WriteLine("File doesn't found");
                return;
            }

            byte[] bytes = ConvertTextOnBytes(file.OpenText().ReadToEnd());

            file.Delete();

            WriteBackupEvent(new Backup(file.Name, file.Name, file.FullName, file.FullName, bytes, Actions.DeleteFile));
        }

        private static string GetNameFromPath(string filePath)
        {
            string[] splitPath = filePath.Split('\\');

            string fileName = splitPath.Last();
            return fileName;
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

            WriteBackupEvent(new Backup(name, name, Directory.GetCurrentDirectory(), Directory.GetCurrentDirectory(), bytes, Actions.CreateFile));

            //сделать возвращаемый тип или нет?
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
        /// <param name="fileName">имя файла</param>
        /// <param name="path">путь к папке</param>
        /// <returns></returns>
        public static FileInfo FindFile(string fileName, string path)
        {
            string[] splitPath = path.Split('\\');

            DirectoryInfo directoryInfo;

            if (splitPath.Length == 1)
            {
                directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\" + path);
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

        /// <summary>
        /// Перемещает файл
        /// </summary>
        /// <param name="fileName">имя файла</param>
        /// <param name="currentFilePath">путь к файлу</param>
        /// <param name="futureFilePath">новый путь к файлу</param>
        public static void MoveFileTo(string fileName, string currentFilePath, string futureFilePath)
        {
            Actions action = Actions.MoveFile;
            //string previousFileName = GetNameFromPath(currentFilePath);
            string currentFileName = GetNameFromPath(futureFilePath);

            var file = FindFile(fileName, currentFilePath);

            if (currentFileName != fileName)
            {
                action = Actions.MoveAndRenameFile;
            }

            var bytes = ConvertTextOnBytes(file?.OpenText().ReadToEnd());

            File.Move(currentFilePath, futureFilePath);

            WriteBackup(new Backup(currentName: currentFileName, previousName: fileName, currentPathToFile: futureFilePath, previousPathToFile: currentFilePath, bytes: bytes, action: action));
        }

        /// <summary>
        /// Переименовывает файл
        /// </summary>
        /// <param name="fileName">имя файла</param>
        /// <param name="path">путь к файлу</param>
        /// <param name="name">новое имя файла</param>
        public static void RenameFile(string fileName, string path, string name)
        {
            var file = FindFile(fileName, path);
            //переименовывание через Move и Remove. Еееееееееее, костыли!
        }
    }
}
