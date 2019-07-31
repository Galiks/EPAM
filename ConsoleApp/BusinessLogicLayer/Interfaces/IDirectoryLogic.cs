using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{
    public interface IDirectoryLogic
    {
        void AddDirectory(string directoryNameOrPath);
        void DeleteDirectory(string directoryNameOrPath);
    }
}
