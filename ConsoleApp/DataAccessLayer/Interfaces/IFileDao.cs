using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IFileDao
    {
        void AddFile(string fileNameOrPath);
        void DeleteFile(string fileNameOrPath);
        void UpdateFile(Backup backup);
    }
}
