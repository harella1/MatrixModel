using System;
using System.IO;

namespace DesignPatterns.Command
{
    public class FileSystemOperator : IFileOperator
    {
        private readonly string m_DirectoryPath;

        public FileSystemOperator(string directoryPath)
        {
            if (!Directory.Exists(directoryPath)) throw new ArgumentException("Directory should exist.");
            m_DirectoryPath = directoryPath;
        }

        public void Create(string fileName)
        {
            string fullName = Path.Combine(m_DirectoryPath, fileName);
            using (StreamWriter file = File.CreateText(fullName))
            {
                file.WriteLine("Hello world!");
            }
        }

        public void Rename(string oldName, string newName)
        {
            string oldFullName = Path.Combine(m_DirectoryPath, oldName);
            string newFullName = Path.Combine(m_DirectoryPath, newName);
            File.Copy(oldFullName, newFullName);
        }

        public void Delete(string fileName)
        {
            string fullName = Path.Combine(m_DirectoryPath, fileName);
            File.Delete(fullName);
        }
    }
}