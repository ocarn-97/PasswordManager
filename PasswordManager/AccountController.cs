namespace PasswordManager
{
    internal class AccountController
    {
#pragma warning disable IDE0044 // Add readonly modifier
        private StorageController storageController = new();
#pragma warning restore IDE0044 // Add readonly modifier

        // List of account objects
#pragma warning disable IDE0044 // Add readonly modifier
        private List<Account> accounts = [];
#pragma warning restore IDE0044 // Add readonly modifier

        // Add account
        public void AddAccount(string title, string username, string password)
        {
            Account account = new(title, username, password);
            accounts.Add(account);
            StorageController.AddToFile(account);
            Console.WriteLine("Account added successfully.");
        }

        // Delete account
        public static void DeleteAccount(string accountName)
        {
            StorageController.DeleteFromFile(accountName);
        }

        // Retrieve accounts
        public static void RetrieveAccounts()
        {
            string[] retrievedLines = StorageController.RetrieveFromFile();
            if (retrievedLines.Length > 0)
            {
                Console.WriteLine("\nAccounts:");
                foreach (string line in retrievedLines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("No accounts exist");
                throw new ArgumentNullException("No accounts exist.");
            }
        }

        // Update account
        public static void UpdateAccount(string accountName, string newUsername, string newPassword)
        {
            StorageController.UpdateFile(accountName, newUsername, newPassword);
        }
    }
}
