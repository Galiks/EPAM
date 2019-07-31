using DataAccessLayer.Models;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IBackupDao
    {
        void AddBackup(Backup backup);
        void DeleteBackup(Backup backup);
        IEnumerable<Backup> GetBackups();
    }
}