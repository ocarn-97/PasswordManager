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
            accounts.Add(new Account(title, username, password));
            storageController.AddToFile(title, username, password);
        }

        // Delete account
        public void DeleteAccount(string accountName)
        {
            if (accounts == null || accounts.Count == 0)
            {
                Console.WriteLine("No account exist");
                throw new InvalidOperationException("No accounts exist.");
            }

            Account accountToDelete = accounts.FirstOrDefault(account => account.Title.Equals(accountName, StringComparison.OrdinalIgnoreCase)) ?? throw new ArgumentException("Account not found.");
            accounts.Remove(accountToDelete);
            storageController.DeleteFromFile(accountToDelete);
        }

        // Retrieve accounts
        public void RetrieveAccounts()
        {
            if (accounts == null || accounts.Count == 0)
            {
                Console.WriteLine("No accounts exist");
                throw new InvalidOperationException("No accounts exist.");
            }
            else
            {
                Console.WriteLine("\nAccounts:");
                foreach (var Account in accounts)
                {
                    Console.WriteLine($"Title: {Account.Title}, Username: {Account.Username}, Password: {Account.Password}");
                }
        }
    }

        // Update account
        public void UpdateAccount(string accountName, string newUsername, string newPassword)
        {
            if (accounts == null || accounts.Count == 0)
            {
                Console.WriteLine("No accounts exist");
                throw new ArgumentNullException(nameof(accountName), "No accounts exist.");
            }

            Account? accountToUpdate = accounts.FirstOrDefault(account => account.Title.Equals(accountName, StringComparison.OrdinalIgnoreCase));

            if (accountToUpdate != null)
            {
                bool isValidPassword = PasswordChecker.CheckPassword(newPassword);

                if (isValidPassword)
                {
                    accountToUpdate.Username = newUsername;
                    accountToUpdate.Password = newPassword;
                }
                else
                {
                    throw new ArgumentException("Invalid password. Please use a different one.", nameof(newPassword));
                }
            }
            else
            {
                throw new ArgumentException("Account not found.", nameof(accountName));
            }
        }
    }
}
