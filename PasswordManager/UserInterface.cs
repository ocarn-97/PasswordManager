using CommandLine;
using CommandLine.Text;
using PasswordManager;
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
            Console.WriteLine(@"
              _____                                    _   __  __                                   
             |  __ \                                  | | |  \/  |                                  
             | |__) |_ _ ___ _____      _____  _ __ __| | | \  / | __ _ _ __   __ _  __ _  ___ _ __ 
             |  ___/ _` / __/ __\ \ /\ / / _ \| '__/ _` | | |\/| |/ _` | '_ \ / _` |/ _` |/ _ \ '__|
             | |  | (_| \__ \__ \\ V  V / (_) | | | (_| | | |  | | (_| | | | | (_| | (_| |  __/ |   
             |_|   \__,_|___/___/ \_/\_/ \___/|_|  \__,_| |_|  |_|\__,_|_| |_|\__,_|\__, |\___|_|   
                                                                                     __/ |          
                                                                                    |___/        ");
            Console.WriteLine("Welcome to the Password Manager! This console application saves passwords for your most sacred of accounts.");
            Console.WriteLine("Enter '-h' or '--help' to see the menu options.");
            Console.WriteLine("\nPlease enter your command:");

            while (true)
            {
                AccountController accountController = new();

                string input = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("No command was specified. Please try again.");
                    continue;
                }

                string[] inputArgs = input.Split(' ');
                Parser.Default.ParseArguments<Options>(inputArgs)
                   .WithParsed(options =>
                   {
                       if (options.Help)
                       {
                           var parserResult = Parser.Default.ParseArguments<Options>([]);
                           var helpText = new HelpText(new HeadingInfo("Password Manager", "1.0"));
                           helpText.AddOptions(parserResult);
                           Console.WriteLine(helpText);
                           return;
                       }

                       if (options.Exit)
                       {
                           Console.WriteLine("Exiting Password Manager...");
                           Environment.Exit(0);
                       }

                       if (options.AddAccount)
                       {
                           if (string.IsNullOrEmpty(options.Title) || string.IsNullOrEmpty(options.Username) || string.IsNullOrEmpty(options.Password))
                           {
                               Console.WriteLine("Title, username, and password are required for adding an account.");
                               return;
                           }

                           accountController.AddAccount(options.Title, options.Username, options.Password);
                           Console.WriteLine("Account added successfully.");
                       }

                       if (options.DeleteAccount)
                       {
                           if (string.IsNullOrEmpty(options.Title))
                           {
                               Console.WriteLine("Title is required for deleting an account.");
                               return;
                           }
                           accountController.DeleteAccount(options.Title);
                           Console.WriteLine("Account deleted");
                       }

                       if (options.RetrieveAccounts)
                       {
                           accountController.RetrieveAccounts();
                       }

                       if (options.UpdateAccount)
                       {
                           if (string.IsNullOrEmpty(options.Title) || string.IsNullOrEmpty(options.Username) || string.IsNullOrEmpty(options.Password))
                           {
                               Console.WriteLine("Title, username, and password are required for adding an account.");
                               return;
                           }
                           Console.WriteLine("Updating account...");
                       }

                       if (options.GeneratePassword)
                       {
                           string GeneratedPassword = PasswordGenerator.GeneratePassword();
                           Console.WriteLine($"Generated Password: {GeneratedPassword}");
                       }
                   })
                   .WithNotParsed(errors =>
                   {
                       Console.WriteLine("Invalid command. Please try again.");
                   });
            }
        }
    }
}

