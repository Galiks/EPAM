using System;
using System.Runtime.Serialization;

namespace DataAccessLayer.Models
{
    public sealed class Backup
    {
        public string FileName { get; set; }
        public string PathToFile { get; set; }
        public byte[] Bytes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Backup(string fileName, string pathToFile, byte[] bytes, DateTime createdAt, DateTime updatedAt)
        {
            FileName = fileName;
            PathToFile = pathToFile;
            Bytes = bytes;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
