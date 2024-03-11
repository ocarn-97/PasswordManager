namespace PasswordManager
{
    internal class PasswordChecker
    {
        private static readonly string filePath = "C:\\C#\\PasswordManager\\BadPasswordList.txt";

        public static bool CheckPassword(string password)
        {
            if (IsTooShort(password))
            {
                throw new Exception($"The password {password} is too short. Please use a password that is at least 12 characters in length.");
            }
            else if (IsBadPassword(password))
            {
                throw new Exception($"The password {password} is too predictable. Please use a different password.");
            }

            return true;
        }


        private static bool IsTooShort(string password)
        {
            if (password.Length < 12)
            {
                return true;
            }
            return false;
        }

        private static bool IsBadPassword(string password)
        {
            CheckFileExistence(filePath);

            string[] badPasswords = File.ReadAllLines(filePath);

            foreach (string badPassword in badPasswords)
            {
                if (password == badPassword)
                {
                    return true;
                }
            }
            return false;
        }

        private static void CheckFileExistence(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Bad password list file not found at: {filePath}");
            }
        }
    }
}
