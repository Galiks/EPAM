using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public sealed class Backup
    {
        public string CurrentName { get; set; }
        public string PreviousName { get; set; }
        public string CurrentPathToFile { get; set; }
        public string PreviousPathToFile { get; set; }
        public byte[] Bytes { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Actions Action { get; set; }

        /// <summary>
        /// Initial object of class Backup
        /// </summary>
        /// <param name="currentName">current name</param>
        /// <param name="previousName">previous name</param>
        /// <param name="currentPathToFile">current path where file is located</param>
        /// <param name="previousPathToFile">current path where file was located</param>
        /// <param name="bytes">text in file as bytes</param>
        /// <param name="action">action on file</param>
        public Backup(string currentName, string previousName, string currentPathToFile, string previousPathToFile, byte[] bytes, Actions action)
        {
            UpdatedAt = DateTime.Now;
            CurrentName = currentName;
            PreviousName = previousName;
            CurrentPathToFile = currentPathToFile;
            PreviousPathToFile = previousPathToFile;
            Bytes = bytes;
            Action = action;
        }

        /// <summary>
        /// Initial object of class Backup
        /// </summary>
        public Backup()
        {
        }

        public override string ToString()
        {
            return $"Current Name: {CurrentName}{Environment.NewLine}Previous Name: {PreviousName}{Environment.NewLine}Current Path To File: {CurrentPathToFile}{Environment.NewLine}Previous Path To File: {PreviousPathToFile}{Environment.NewLine}Action: {Action}{Environment.NewLine}Update At: {UpdatedAt}{Environment.NewLine}";
        }
    }
}
