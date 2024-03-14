using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    internal class StorageController
    {

        private readonly string FilePath = "C:\\C#\\PasswordManager\\StorageFile.txt";

        public void AddToFile(string title, string username, string password)
        {
            string FormattedString = $"Title: {title}, Username: {username}, Password: {password}\n";
            File.AppendAllText(FilePath, FormattedString);
        }

        public void DeleteFromFile(Account account)
        {
            string[] lines = File.ReadAllLines(FilePath);
            string lineToDelete = account.Title.ToString();
            var updatedLines = lines.Where(line => !line.Contains(lineToDelete)).ToList();
            File.WriteAllLines(FilePath, updatedLines);
        }

        //public static RetrieveFromFile(string accountName, string username, string password)
        //{

        //}

        //public static UpdateFile(string accountName, string username, string password)
        //{

        //}
    }
}
