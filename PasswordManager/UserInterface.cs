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

                ConsoleKeyInfo choice = Console.ReadKey(true);

                switch (choice.KeyChar)
                {
                    case 'a':
                        AccountManagementMenu();
                        break;

                    case 'b':
                        PasswordGeneratorMenu();
                        break;

                    case 'c':
                        Exit();
                        return;

                    default:
                        Console.WriteLine("Invalid input. Please enter a character");
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
            Console.WriteLine("a. Account Management");
            Console.WriteLine("b. Password Generator");
            Console.WriteLine("c. Exit");
        }

        public static void AccountManagementMenu()
        {
            Console.WriteLine("######################################################################################################");
            Console.WriteLine("                                   Account Management                                                 ");
            Console.WriteLine("######################################################################################################");
            Console.WriteLine("\nThis is where you securely add, delete, retrieve, or update your accounts and password. Select one of the options to continue.");
            Console.WriteLine("\nAccount Management Menu:");
            Console.WriteLine("a. Add Account");
            Console.WriteLine("b. Delete Account");
            Console.WriteLine("c. Retrieve Account");
            Console.WriteLine("d. Update Account");
            Console.WriteLine("e. Back");
            Console.WriteLine("f. Exit");
        }

        public static void PasswordGeneratorMenu()
        {
            Console.WriteLine("######################################################################################################");
            Console.WriteLine("                                   Password Generator                                                 ");
            Console.WriteLine("######################################################################################################");
            Console.WriteLine("\nThe password generator creates a secure password that you can save to one of your accounts.");
            Console.WriteLine("\nPassword Generator Menu:");
            Console.WriteLine("a. Generate Password");
            Console.WriteLine("d. Back");
            Console.WriteLine("c. Exit");
        }

        public static void Exit()
        {
            Console.Write("Exiting Password Manager...");
            Environment.Exit(0);
        }
    }
}
