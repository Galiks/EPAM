using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IBackupDao
    {
        void AddBackup(Backup backup);
        void DeleteBackup(Backup backup);
    }
}