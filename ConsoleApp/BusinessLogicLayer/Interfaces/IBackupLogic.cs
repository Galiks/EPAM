namespace BusinessLogicLayer.Interfaces
{
    public interface IBackupLogic
    {
        void AddBackup(string fileName, string currentPathToFile, string previousPathToFile, string text, string createdAt);
        void DeleteBackup(string fileNameOfPath);
    }
}