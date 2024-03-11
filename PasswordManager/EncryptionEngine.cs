using System.Security.Cryptography;
using System.Text;

namespace PasswordManager
{
    internal class EncryptionEngine
    {
        public static byte[] EncryptPassword(string password)
        {
            byte[] encryptedData = ProtectedData.Protect(Encoding.UTF8.GetBytes(password), null, DataProtectionScope.CurrentUser);
            return encryptedData;
        }

        public static string DecryptPassword(byte[] encryptedData)
        {
            byte[] decryptedBytes = ProtectedData.Unprotect(encryptedData, null, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
