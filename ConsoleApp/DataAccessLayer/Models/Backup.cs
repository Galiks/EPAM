﻿using System;
using System.Runtime.Serialization;

namespace DataAccessLayer.Models
{
    public sealed class Backup
    {
        public string CurrentName { get; set; }
        public string PreviousName { get; set; }
        public string CurrentPathToFile { get; set; }
        public string PreviousPathToFile { get; set; }
        public byte[] Bytes { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Action { get; set; }

        public Backup(string currentName, string previousName, string currentPathToFile, string previousPathToFile, byte[] bytes, DateTime updatedAt)
        {
            CurrentName = currentName;
            PreviousName = previousName;
            CurrentPathToFile = currentPathToFile;
            PreviousPathToFile = previousPathToFile;
            Bytes = bytes;
            UpdatedAt = updatedAt;
        }

        public Backup(string currentName, string previousName, string currentPathToFile, string previousPathToFile, byte[] bytes)
        {
            DateTime nowDateTime = DateTime.Now;
            CurrentName = currentName;
            PreviousName = previousName;
            CurrentPathToFile = currentPathToFile;
            PreviousPathToFile = previousPathToFile;
            Bytes = bytes;
            UpdatedAt = nowDateTime;
        }

        /// <summary>
        /// Initial object of class Backup
        /// </summary>
        /// <param name="currentName">current name</param>
        /// <param name="previousName">previous name</param>
        /// <param name="currentPathToFile">current path where file is located</param>
        /// <param name="previousPathToFile">current path where file was located</param>
        /// <param name="bytes">text in file as bytes</param>
        /// <param name="action">action on file</param>
        public Backup(string currentName, string previousName, string currentPathToFile, string previousPathToFile, byte[] bytes, string action) : this(currentName, previousName, currentPathToFile, previousPathToFile, bytes)
        {
            Action = action;
        }

        public Backup()
        {
        }

        public override string ToString()
        {
            return $"Current Name: {CurrentName}{Environment.NewLine}Previous Name: {PreviousName}{Environment.NewLine}Current Path To File: {CurrentPathToFile}{Environment.NewLine}Previous Path To File: {PreviousPathToFile}{Environment.NewLine}Action: {Action}{Environment.NewLine}{Environment.NewLine}Update At: {UpdatedAt}{Environment.NewLine}";
        }
    }
}
