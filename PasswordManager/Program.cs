using PasswordManager;

//UserInterface.Run();

string password = PasswordGenerator.GeneratePassword();

byte[] EncryptedPassword = EncryptionEngine.Encrypt(password);

Console.WriteLine(EncryptedPassword);

string decryptedpassword = EncryptionEngine.Decrypt(EncryptedPassword);

Console.WriteLine(decryptedpassword);