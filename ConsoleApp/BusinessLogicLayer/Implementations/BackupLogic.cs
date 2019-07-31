using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using System;

namespace BusinessLogicLayer.Implementations
{
    public class BackupLogic : IBackupLogic
    {
        public void AddBackup(string fileName, string currentPathToFile, string previousPathToFile, string text, string createdAt)
        {
            var backup = new Backup();
        }

        public void DeleteBackup(string fileNameOfPath)
        {
            throw new NotImplementedException();
        }
    }
}
