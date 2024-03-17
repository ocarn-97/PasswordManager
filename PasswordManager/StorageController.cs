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

        private const string FilePath = "C:\\C#\\PasswordManager\\StorageFile.txt";

        public static void AddToFile(Account account)
        {
            string title = account.Title;
            string username = account.Username;
            string password = account.Password;

            string FormattedString = $"Title: {title}, Username: {username}, Password: {password}";
            File.AppendAllText(FilePath, FormattedString);
        }

        public static void DeleteFromFile(string accountName)
        {
            string[] lines = File.ReadAllLines(FilePath);
            var linesToDelete = lines.Where(line => !line.Contains(accountName)).ToList();
            var lengthOfUpdatedlines = linesToDelete.Count;
            Console.WriteLine($"Number of accounts deleted: {lengthOfUpdatedlines}.");
            File.WriteAllLines(FilePath, linesToDelete);
        }

        public static string[] RetrieveFromFile()
        {
            string[] lines = File.ReadAllLines(FilePath);
            return lines;
        }

        public static void UpdateFile(string accountName, string newUsername, string newPassword)
        {
            string[] lines = File.ReadAllLines(FilePath);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(accountName))
                {
                    lines[i] = $"Title: {accountName}, Username: {newUsername}, Password: {newPassword}";
                    break;
                }
            }

            File.WriteAllLines(FilePath, lines);
            Console.WriteLine($"Account '{accountName}' updated successfully.");
        }

    }
}
