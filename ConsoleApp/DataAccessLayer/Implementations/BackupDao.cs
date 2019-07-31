using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataAccessLayer.Implementations
{
    public sealed class BackupDao : IBackupDao
    {
        private const string _pathToFile = "backups.json";

        private List<Backup> backups;

        public BackupDao()
        {
            Backups = new List<Backup>();
        }

        public List<Backup> Backups { get => backups; private set => backups = value; }

        public void AddBackup(Backup backup)
        {
            //add NewLine to split basckups
            File.AppendAllText(_pathToFile, JsonConvert.SerializeObject(backup) + Environment.NewLine);
        }

        public void DeleteBackup(Backup backup)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Backup> GetBackups()
        {
            using (StreamReader streamReader = new StreamReader(_pathToFile))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Backup backup = JsonConvert.DeserializeObject<Backup>(line);
                    yield return backup;
                }
            }
        }

        /*
         * string text = "КУДА ИДЁМ С ПЯТОЧКОМ!";
            var bytes = Encoding.UTF8.GetBytes(text);
            var backup = new Backup(text, "Test1", "Test1", bytes, DateTime.Now, DateTime.Now);

            File.AppendAllText(pathToFile, JsonConvert.SerializeObject(backup) + Environment.NewLine);

            JsonSerializer serializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore
            };


            using (StreamReader streamReader = new StreamReader("backups.json"))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var item = JsonConvert.DeserializeObject<Backup>(line);

                    string codingText = Convert.ToBase64String(item.Bytes);
                    var enTextBytes = Convert.FromBase64String(codingText);
                    string deText = Encoding.UTF8.GetString(enTextBytes);

                    Console.WriteLine($"{item.FileName}{Environment.NewLine}{deText}{Environment.NewLine}");
                }
            }
         * 
         * */
    }
}
