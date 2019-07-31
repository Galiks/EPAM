using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{
    public interface IFileLogic
    {
        void AddFile(string fileNameOrPath);
        void DeleteFile(string fileNameOrPath);
        void UpdateFile(string updatingInformation);
    }
}
