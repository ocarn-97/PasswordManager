using System.Text;

namespace PasswordManager
{
    internal class PasswordGenerator
    {
        public static string GeneratePassword()
        {
            string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string symbols = "!@#$%^&*";

            Random rand = new();
            int max = rand.Next(14, 18);
            int length = rand.Next(12, max + 1);
            StringBuilder str = new(length);

            for (int i = 0; i < length; i++)
            {
                bool addCharacter = rand.Next(2) == 0;

                if (addCharacter)
                    str.Append(characters[rand.Next(characters.Length)]);
                else
                    str.Append(symbols[rand.Next(symbols.Length)]);
            }

            return str.ToString();
        }
    }
}
