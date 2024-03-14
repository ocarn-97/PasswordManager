namespace PasswordManager
{
    internal class AccountController
    {
        // List of account objects
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable IDE0028 // Simplify collection initialization
        private List<Account> accounts = new();
#pragma warning restore IDE0028 // Simplify collection initialization
#pragma warning restore IDE0044 // Add readonly modifier

        // Add account
        public void AddAccount(string title, string username, string password)
        {
            accounts.Add(new Account(title, username, password));
        }

        // Delete account
        public void DeleteAccount(string accountName)
        {
            if (accounts == null || accounts.Count == 0)
            {
                Console.WriteLine("No account exist");
                throw new InvalidOperationException("No accounts exist to be deleted.");
            }

            Account accountToDelete = accounts.FirstOrDefault(account => account.Title.Equals(accountName, StringComparison.OrdinalIgnoreCase)) ?? throw new ArgumentException("Account not found.");
            accounts.Remove(accountToDelete);
        }

        // Retrieve accounts
        public void RetrieveAccounts()
        {
            if (accounts == null || accounts.Count == 0)
            {
                Console.WriteLine("No account exist");
                throw new InvalidOperationException("No accounts exist to be deleted.");
            }
            else
            {
                Console.WriteLine("\nAccounts:");
                foreach (var account in accounts)
                {
                    Console.WriteLine($"Title: {account.Title}, Username: {account.Username}, Password: {account.Password}");
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
