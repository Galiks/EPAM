using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    public static class RollBacker
    {
        private const string dateFormat = "dd.MM.yyyy hh:mm:ss";
        public static string PathToBackupFile;

        private static event Action<Backup> RemoveBackupEvent;

        private static readonly DirectoryInfo myDirectoryInfo;

        public static DirectoryInfo MyDirectoryInfo => myDirectoryInfo;

        static RollBacker()
        {
            myDirectoryInfo = new DirectoryInfo(Program.RootDirectory);
            PathToBackupFile = Program.PathToBackupFile;
            RemoveBackupEvent += RemoveBackup;
        }

        /// <summary>
        /// Удаляет Backup из файла
        /// </summary>
        /// <param name="removedBackup"></param>
        private static void RemoveBackup(Backup removedBackup)
        {
            var allLines = File.ReadAllLines(PathToBackupFile);
            for (int i = 0; i < allLines.Length; i++)
            {
                var line = allLines[i];

                Backup backupInLine = JsonConvert.DeserializeObject<Backup>(line);
                if (backupInLine.CurrentPathToFile == removedBackup.CurrentPathToFile && backupInLine.UpdatedAt == removedBackup.UpdatedAt)
                {
                    allLines[i] = string.Empty;
                }
            }
            File.WriteAllLines(PathToBackupFile, allLines);
        }

        /// <summary>
        /// Возвращает обновления
        /// </summary>
        /// <param name="fileName"></param>
        private static void ReturnUpdate(string fileName, string path)
        {

            var items = GetBackups().Where(f => f.CurrentName == fileName).ToList();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

            Console.Write("Enter the date: ");
            string date = Console.ReadLine();
            var dateTime = DateTime.Parse(date);

            var backup = items.Where(b => b.UpdatedAt.ToString(dateFormat) == dateTime.ToString(dateFormat)).FirstOrDefault();

            switch (backup.Action)
            {
                case Actions.UpdateFile:
                    RollbackUpdateFile(backup);
                    break;
                case Actions.CreateFile:
                    RollbackCreateFile(backup);
                    break;
                case Actions.DeleteFile:
                    RollbackDeleteFile(backup);
                    break;
                case Actions.MoveFile:
                    RollbackMoveFile(backup);
                    break;
                case Actions.RenameFile:
                    RollbackRenameFile(backup);
                    break;
                case Actions.MoveAndRenameFile:
                    RollbackMoveAndRenameFile(backup);
                    break;
                default:
                    break;
            }
        }

        private static void RollbackMoveAndRenameFile(Backup backup)
        {
            //сначала Rename, а потом Move или наоборот?
            string previousPathAndFileName = backup.PreviousPathToFile + "\\" + backup.PreviousName;
            Observer.MoveFileTo(backup.CurrentName, backup.CurrentPathToFile, previousPathAndFileName, false);
            RemoveBackupEvent?.Invoke(backup);
        }

        private static void RollbackRenameFile(Backup backup)
        {
            Observer.RenameFile(backup.CurrentName, backup.CurrentPathToFile, backup.PreviousName, false);
            RemoveBackupEvent?.Invoke(backup);
        }

        private static void RollbackMoveFile(Backup backup)
        {
            Observer.MoveFileTo(backup.CurrentName, backup.CurrentPathToFile, backup.PreviousPathToFile, false);
            RemoveBackupEvent?.Invoke(backup);
        }

        private static void RollbackDeleteFile(Backup backup)
        {
            Observer.CreateFile(backup.CurrentName, false);
            RemoveBackupEvent?.Invoke(backup);
        }

        private static void RollbackCreateFile(Backup backup)
        {
            Observer.DeleteFile(backup.CurrentName, backup.CurrentPathToFile, false);
            RemoveBackupEvent?.Invoke(backup);
        }

        private static void RollbackUpdateFile(Backup backup)
        {
            string text = ConvertBytesToText(backup.Bytes);
            Observer.UpdateText(backup.CurrentName, backup.CurrentName, text, false);
            RemoveBackupEvent?.Invoke(backup);
        }

        public static IEnumerable<Backup> GetBackups()
        {
            using (StreamReader streamReader = new StreamReader(Program.PathToBackupFile))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        Backup backup = JsonConvert.DeserializeObject<Backup>(line);
                        yield return backup;
                    }
                }
            }
        }

        private static Backup GetBackupByUpdateAt(string date)
        {
            var dateTime = DateTime.Parse(date);

            var item = GetBackups().Where(b => b.UpdatedAt.ToString(dateFormat) == dateTime.ToString(dateFormat)).FirstOrDefault();
            return item;
        }

        public static string ConvertBytesToText(byte[] bytes)
        {
            string codingText = Convert.ToBase64String(bytes);
            var enTextBytes = Convert.FromBase64String(codingText);
            string deText = Encoding.UTF8.GetString(enTextBytes);

            return deText;
        }
    }
}
