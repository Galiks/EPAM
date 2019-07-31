using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataAccessLayer.Implementations
{
    public class DirectoryDao: IDirectoryDao
    {
        private readonly string _rootDirectory;

        public DirectoryDao()
        {
            var mainFolder = Directory.CreateDirectory("MainFolder");
            _rootDirectory = mainFolder.FullName;
            Directory.SetCurrentDirectory(_rootDirectory);
        }

        public void AddDirectory(string directoryNameOrPath)
        {
            Directory.CreateDirectory(directoryNameOrPath);
        }

        public void DeleteDirectory(string directoryNameOrPath)
        {
            Directory.Delete(directoryNameOrPath);
        }
    }
}
