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
                       }

                       if (options.DeleteAccount)
                       {
                           if (string.IsNullOrEmpty(options.Title))
                           {
                               Console.WriteLine("Title is required for deleting an account.");
                               return;
                           }
                           AccountController.DeleteAccount(options.Title);
                       }

                       if (options.RetrieveAccounts)
                       {
                           AccountController.RetrieveAccounts();
                       }

                       if (options.UpdateAccount)
                       {
                           if (string.IsNullOrEmpty(options.Title) || string.IsNullOrEmpty(options.Username) || string.IsNullOrEmpty(options.Password))
                           {
                               Console.WriteLine("The title of the target account as well as the new username and password are required to update it.");
                               return;
                           }
                           AccountController.UpdateAccount(options.Title, options.Username, options.Password);
                       }

                       if (options.GeneratePassword)
                       {
                           string GeneratedPassword = PasswordGenerator.GeneratePassword();
                           Console.WriteLine($"Generated Password: {GeneratedPassword}");
                       }

                       if (options.CheckPassword)
                       {
                           if (string.IsNullOrEmpty(options.Password))
                           {
                               Console.WriteLine("Please include a password to check.");
                               return;
                           }
                           PasswordChecker.CheckPassword(options.Password);
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

