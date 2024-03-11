using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    internal class UserInterface
    {
        public static void Run()
        {
            while (true)
            {
                MainMenu();

                ConsoleKeyInfo choice = Console.ReadKey(false);

                switch (choice.KeyChar)
                {
                    case '1':
                        AccountManagementMenu();
                        break;

                    case '2':
                        PasswordGeneratorMenu();
                        break;

                    case '3':
                        Exit();
                        break;
                }
            }
        }

        public static void MainMenu()
        {
            Console.WriteLine("######################################################################################################");
            Console.WriteLine("                                   Password Manager                                                   ");
            Console.WriteLine("######################################################################################################");
            Console.WriteLine("\nWelcome to the Password Manager! Please select a menu option to continue or press 3 to exit.");
            Console.WriteLine("\nPassword Manager Menu:");
            Console.WriteLine("1. Account Management");
            Console.WriteLine("2. Password Generator");
            Console.WriteLine("3. Exit");
        }

        public static void AccountManagementMenu()
        {
            Console.WriteLine("######################################################################################################");
            Console.WriteLine("                                   Password Manager                                                   ");
            Console.WriteLine("######################################################################################################");
            Console.WriteLine("\nWelcome to the Password Manager! Please select a menu option to continue or press ESC to exit.");
            Console.WriteLine("\nPassword Manager Menu:");
            Console.WriteLine("1. User Management");
            Console.WriteLine("2. Account Management");
            Console.WriteLine("3. Password Generator");
            Console.WriteLine("4. Exit");
        }

        public static void PasswordGeneratorMenu()
        {
            Console.WriteLine("######################################################################################################");
            Console.WriteLine("                                   Password Manager                                                   ");
            Console.WriteLine("######################################################################################################");
            Console.WriteLine("\nWelcome to the Password Manager! Please select a menu option to continue or press ESC to exit.");
            Console.WriteLine("\nPassword Manager Menu:");
            Console.WriteLine("1. User Management");
            Console.WriteLine("2. Account Management");
            Console.WriteLine("3. Password Generator");
            Console.WriteLine("4. Exit");
        }

        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}
