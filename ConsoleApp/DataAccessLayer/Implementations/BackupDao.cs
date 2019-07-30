using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Implementations
{
    public sealed class BackupDao : IBackupDao
    {
        private List<Backup> backups;

        public BackupDao()
        {
            this.backups = new List<Backup>();
        }

        public void AddBackup(Backup backup)
        {
            throw new NotImplementedException();
        }

        public void DeleteBackup(Backup backup)
        {
            throw new NotImplementedException();
        }
    }
}
