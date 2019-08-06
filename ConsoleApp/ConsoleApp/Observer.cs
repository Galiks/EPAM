using Newtonsoft.Json;
using System;
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
        /// <param name="fileName"></param>
        /// <param name="path"></param>
        /// <param name="text"></param>
        /// <param name="backup">необязательный параметр, отвечающий за запись в бэкап</param>
        public static void UpdateText(string fileName, string path, string text, bool backup = true)
        {
            var file = FindFile(fileName, path);

            if (file == null)
            {
                Console.WriteLine("File not found");
                return;
                //throw new Exception("File not found");
            }

            string oldText = "";

            using (StreamReader reader = new StreamReader(file.OpenRead()))
            {
                oldText = reader.ReadToEnd();
            }

            //using (FileStream fileStream = file.Open(FileMode.Open, FileAccess.Write, FileShare.Write))
            //{
            File.WriteAllText(file.FullName, text);
            //}

            if (backup)
            {
                var bytes = ConvertTextOnBytes("");
                WriteBackupEvent(new Backup(file.Name, file.Name, file.FullName, file.FullName, bytes, Actions.UpdateFile));
            }
        }

        /// <summary>
        /// Удаляет файл
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="path"></param>
        /// <param name="backup">необязательный параметр, отвечающий за запись в бэкап</param>
        public static void DeleteFile(string fileName, string path, bool backup = true)
        {
            FileInfo file = FindFile(fileName, path);

            if (file == null)
            {
                Console.WriteLine("File not found");
                return;
                //throw new Exception("File not found");
            }

            if (backup)
            {
                byte[] bytes = ConvertTextOnBytes(file.OpenText().ReadToEnd());
                WriteBackupEvent(new Backup(file.Name, file.Name, file.FullName, file.FullName, bytes, Actions.DeleteFile));
            }

            file.Delete();
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
        /// <param name="backup">необязательный параметр, отвечающий за запись в бэкап</param>
        public static void CreateFile(string name, bool backup = true)
        {
            if (!IsExistsFile(ref name))
            {
                name = name + ".txt";
                using (FileStream fileStream = File.Create(name))
                {
                    fileStream.Close();
                }
            }

            if (backup)
            {
                WriteBackupEvent(new Backup(name, name, Directory.GetCurrentDirectory(), Directory.GetCurrentDirectory(), new byte[0], Actions.CreateFile));
            }

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
            DirectoryInfo directoryInfo = GetDirectoryByPath(path);

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

        private static DirectoryInfo GetDirectoryByPath(string path)
        {
            string[] splitPath = path.Split('\\');

            DirectoryInfo directoryInfo;

            if (splitPath.Length == 1)
            {
                directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\" + path);
            }
            else
            {
                StringBuilder filePath = new StringBuilder();
                for (int i = 1; i < splitPath.Length; i++)
                {
                    filePath.Append("\\" + splitPath[i]);
                }

                directoryInfo = new DirectoryInfo(MyDirectoryInfo.FullName + filePath.ToString());
            }

            return directoryInfo;
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
            var directory = GetDirectoryByPath(path);
            Directory.SetCurrentDirectory(directory.FullName);
        }

        /// <summary>
        /// Перемещает файл
        /// </summary>
        /// <param name="fileName">имя файла</param>
        /// <param name="currentFilePath">путь к файлу</param>
        /// <param name="futureFilePath">новый путь к файлу</param>
        /// <param name="backup">необязательный параметр, отвечающий за запись в бэкап</param>
        public static void MoveFileTo(string fileName, string currentFilePath, string futureFilePath, bool backup = true)
        {
            var file = FindFile(fileName, currentFilePath);

            if (file == null)
            {
                Console.WriteLine("File not found");
                return;
                //throw new Exception("File not found");
            }

            string oldText = "";

            using (StreamReader reader = new StreamReader(file.OpenRead()))
            {
                oldText = reader.ReadToEnd();
                reader.Close();
            }

            string currentDirectory = GetDirectoryByPath(currentFilePath).FullName + fileName;

            string futureName = GetNameFromPath(futureFilePath);

            string futureDirectory = GetDirectoryByPath(futureFilePath).FullName;

            //using (FileStream fileTemp = file.Open(FileMode.Open))
            //{
            File.Move(currentDirectory, futureDirectory);
            //}

            if (backup)
            {
                Actions action = Actions.MoveFile;

                if (futureName != fileName)
                {
                    action = Actions.MoveAndRenameFile;
                }

                var bytes = ConvertTextOnBytes(oldText);
                WriteBackup(new Backup(currentName: futureName, previousName: fileName, currentPathToFile: futureFilePath, previousPathToFile: currentFilePath, bytes: bytes, action: action));
            }
        }

        /// <summary>
        /// Переименовывает файл
        /// </summary>
        /// <param name="fileName">имя файла</param>
        /// <param name="path">путь к файлу</param>
        /// <param name="newName">новое имя файла</param>
        /// <param name="backup">необязательный параметр, отвечающий за запись в бэкап</param>
        public static void RenameFile(string fileName, string path, string newName, bool backup = true)
        {
            var file = FindFile(fileName, path);

            if (file == null)
            {
                Console.WriteLine("File not found");
                return;
                //throw new Exception("File not found");
            }

            //field for class Backup
            string futurePath = MyDirectoryInfo.FullName + path;

            //field for MoveTo()
            string futurePathAndFileName = futurePath + "\\" + newName;
            //переименовывание через Move и Remove. Еееееееееее, костыли!

            file.MoveTo(futurePathAndFileName);


            //if path is current directory - path is empty. So we do next...
            if (string.IsNullOrWhiteSpace(path))
            {
                path = MyDirectoryInfo.FullName;
            }

            if (backup)
            {
                var bytes = ConvertTextOnBytes(file?.OpenText().ReadToEnd());
                Actions action = Actions.RenameFile;
                WriteBackup(new Backup(currentName: newName, previousName: fileName, currentPathToFile: futurePath, previousPathToFile: path, bytes: bytes, action: action));
            }
        }

        private static bool IsLocked(string fileName)
        {
            try
            {
                using (FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    fs.Close();
                    // Здесь вызываем свой метод, работаем с файлом
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2147024894)
                    return false;
            }
            return true;
        }
    }
}
