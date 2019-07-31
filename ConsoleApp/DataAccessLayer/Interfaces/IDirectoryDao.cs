using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IDirectoryDao
    {
        void AddDirectory(string directoryNameOrPath);
        void DeleteDirectory(string directoryNameOrPath);
    }
}
