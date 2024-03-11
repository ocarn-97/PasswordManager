namespace PasswordManager
{
    internal class Account(string title, string username, string password)
    {
        public string Id { get; set; } = GenerateId();
        public string Title { get; set; } = title;
        public string Username { get; set; } = username;
        public string Password { get; set; } = password;

        private static string GenerateId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
