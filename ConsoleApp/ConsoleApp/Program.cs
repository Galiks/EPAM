using System;
using System.Collections.Generic;
using System.IO;
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
            Observer.CreateFile("File2");
            //Observer.DeleteFile("File2.txt", "");
            Observer.UpdateText("File2.txt", "", "Some text");
            Observer.RenameFile("File2.txt", "", "New File2.txt");
            Observer.CreateFolder("New Folder");
            Observer.MoveFileTo("New File2.txt", "", "MainFolder\\New Folder\\New File2.txt");
        }

        private static void UserInterface()
        {
            Console.WriteLine($"Hello, Stranger!{Environment.NewLine}I see that you decided to run this program{Environment.NewLine}Good luck!{Environment.NewLine}So... What do you want?{Environment.NewLine}");
            Console.WriteLine("Press O to start OBSERVER mode");
            Console.WriteLine("Press R to start ROLLBACK mode");
            Console.WriteLine("Press Esc to start EXIT mode" + Environment.NewLine);
            while (true)
            {
                var command = Console.ReadKey();
                // Не люблю когда после ввода символа в консоль он остаётся. Следующая процедура убирает его (Bakcspace)
                Console.Write("\b");

                switch (command.Key)
                {
                    case ConsoleKey.O:
                        StartObserverMode();
                        break;
                    case ConsoleKey.R:
                        StartRollbackMode();
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("Bye-bye!");
                        return;
                    default:
                        Console.WriteLine("Do not try to fool me, dude! There is no such command");
                        break;
                }
            }
        }

        private static void StartRollbackMode()
        {
            Console.WriteLine("Для отката введите дату, в том же формате, какой указан в бэкапе.");
        }

        #region Observer
        private static void StartObserverMode()
        {
            //текст набран в 3-4 ночи, поэтому он на русском языке, а не на коверканном английском.
            Console.WriteLine("Для ваших нужд создана папка MainFolder. Когда будете писать путь, начинайте с ней. " + Environment.NewLine +
                "Также, следует учесть, что если действия происходят в текущей папке, " + Environment.NewLine +
                "то путь можно не указывать (просто нажать Enter при запросе)");

            Console.WriteLine("The jokes are over!");
            Console.WriteLine("Press F to Create File");
            Console.WriteLine("Press Q to Create Folder");
            Console.WriteLine("Press D to Delete File");
            Console.WriteLine("Press W to Find File");
            Console.WriteLine("Press M to Move File");
            Console.WriteLine("Press R to Rename File");
            Console.WriteLine("Press S to Set Current Directory");
            Console.WriteLine("Press U to Update Text");
            Console.WriteLine("Press Esc to start EXIT mode" + Environment.NewLine);

            var command = Console.ReadKey();

            switch (command.Key)
            {
                case ConsoleKey.F:
                    CreateFile();
                    break;
                case ConsoleKey.Q:
                    CreateFolder();
                    break;
                case ConsoleKey.D:
                    DeleteFile();
                    break;
                case ConsoleKey.W:
                    FindFile();
                    break;
                case ConsoleKey.M:
                    MoveFile();
                    break;
                case ConsoleKey.R:
                    RenameFile();
                    break;
                case ConsoleKey.S:
                    SetCurrentDirectory();
                    break;
                case ConsoleKey.U:
                    UpdateText();
                    break;
                case ConsoleKey.Escape:
                    Console.WriteLine("Bye-bye!");
                    return;
                default:
                    Console.WriteLine("Do not try to fool me, dude! There is no such command");
                    break;
            }
        }

        private static void UpdateText()
        {
            Console.Write("Название файла с расширением: ");
            string fileName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fileName))
            {
                Console.WriteLine("Имя файла не должно быть пустое!");
                return;
                //throw new Exception();
            }

            Console.Write("Путь к файлу: ");
            string path = Console.ReadLine();
            Console.Write("Текст файла: ");
            string text = Console.ReadLine();
            Observer.UpdateText(fileName, path, text);
        }

        private static void SetCurrentDirectory()
        {
            Console.Write("Путь: ");
            string path = Console.ReadLine();
            Observer.SetCurrentDirectory(path);
        }

        private static void RenameFile()
        {
            Console.Write("Название файла с расширением: ");
            string fileName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fileName))
            {
                Console.WriteLine("Имя файла не должно быть пустое!");
                return;
                //throw new Exception();
            }

            Console.Write("Путь к файлу: ");
            string path = Console.ReadLine();
            Console.Write("Новое имя файла с расширением: ");
            string newName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newName))
            {
                Console.WriteLine("Новое имя файла не должно быть пустое!");
                return;
                //throw new Exception();
            }

            Observer.RenameFile(fileName, path, newName);
        }

        private static void MoveFile()
        {
            Console.Write("Название файла с расширением: ");
            string fileName = Console.ReadLine();
            Console.Write("Путь к файлу: ");
            string currentPath = Console.ReadLine();
            Console.Write("Новый путь к файлу вместе с именем файла и расширением: ");
            string futurePath = Console.ReadLine();
            Observer.MoveFileTo(fileName, currentPath, futurePath);
        }

        private static void FindFile()
        {
            Console.Write("Название файла: ");
            string fileName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fileName))
            {
                Console.WriteLine("Имя файла не должно быть пустое!");
                return;
                //throw new Exception();
            }

            Console.Write("Путь к файлу: ");
            string path = Console.ReadLine();
            Observer.FindFile(fileName, path);
        }

        private static void DeleteFile()
        {
            Console.Write("Название файла с расширением: ");
            string fileName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fileName))
            {
                Console.WriteLine("Имя файла не должно быть пустое!");
                return;
                //throw new Exception();
            }

            Console.Write("Путь к файлу: ");
            string path = Console.ReadLine();
            Observer.DeleteFile(fileName, path);
        }

        private static void CreateFolder()
        {
            Console.Write("Название папки: ");
            string folderName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(folderName))
            {
                Console.WriteLine("Имя папки не должно быть пустое!");
                return;
                //throw new Exception();
            }

            Observer.CreateFolder(folderName);
        }

        private static void CreateFile()
        {
            Console.Write("Название файла: ");
            string fileName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fileName))
            {
                Console.WriteLine("Имя файла не должно быть пустое!");
                return;
                //throw new Exception();
            }

            Observer.CreateFile(fileName);
        } 
        #endregion
    }
}
