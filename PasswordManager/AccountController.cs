namespace PasswordManager
{
    internal class AccountController
    {
        // List of account objects
        private List<Account> accounts = [];

        // Add account
        public void AddAccount(string title, string username, string password)
        {
            accounts.Add(new Account(title, username, password));
        }

        // Delete account
        public void DeleteAccount(Account account)
        {
            accounts.Remove(account);
        }

        // Retrieve accounts
        public void RetrieveAccounts()
        {
            foreach (var account in accounts)
            {
                Console.WriteLine($"Title: {account.Title}, Username: {account.Username}, Password: {account.Password}");
            }
        }

        // Update account
        public void UpdateAccount(string accountName, string newTitle, string newUsername, string newPassword)
        {
            if (accounts == null)
            {
                throw new ArgumentNullException(accountName, "No accounts with this name exist.");
            }

            Account? accountToUpdate = accounts.FirstOrDefault(account => account.Title.Equals(accountName, StringComparison.OrdinalIgnoreCase));

            if (accountToUpdate != null)
            {
                bool isValidPassword = PasswordChecker.CheckPassword(newPassword);

                if (isValidPassword)
                {
                    accountToUpdate.Title = newTitle;
                    accountToUpdate.Username = newUsername;
                    accountToUpdate.Password = newPassword;
                }
                else
                {
                    throw new ArgumentException("Invalid password. Please use a different password.", nameof(newPassword));
                }
            }
            else
            {
                throw new ArgumentException("Account not found.", nameof(accountName));
            }
        }
    }
}
