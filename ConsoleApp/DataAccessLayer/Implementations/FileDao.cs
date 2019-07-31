using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataAccessLayer.Implementations
{
    public class FileDao : IFileDao
    {
        public void AddFile(string fileNameOrPath)
        {
            File.Create(fileNameOrPath);
        }

        public void DeleteFile(string fileNameOrPath)
        {
            File.Delete(fileNameOrPath);         
        }

        public void UpdateFile(Backup backup)
        {
            throw new NotImplementedException();
        }
    }
}
