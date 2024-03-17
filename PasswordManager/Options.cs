using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    internal class Options
    {
        [Option("title", HelpText = "Title/Account Name.")]
        public string? Title { get; set; }

        [Option("username", HelpText = "Username.")]
        public string? Username { get; set; }

        [Option("password", HelpText = "Password.")]
        public string? Password { get; set; }

        [Option('a', "add", HelpText = "Add an account.")]
        public bool AddAccount { get; set; }

        [Option('d', "delete", HelpText = "Delete an account.")]
        public bool DeleteAccount { get; set; }

        [Option('r', "retrieve", HelpText = "Retrieve all accounts.")]
        public bool RetrieveAccounts { get; set; }

        [Option('u', "update", HelpText = "Update an account.")]
        public bool UpdateAccount { get; set; }

        [Option('e', "exit", HelpText = "Exit the application.")]
        public bool Exit { get; set; }

        [Option('h', "help", HelpText = "Display help screen.")]
        public bool Help { get; set; }

        [Option('g', "generate", HelpText = "Generate a secure password.")]
        public bool GeneratePassword { get; set; }

        [Option('c', "check", HelpText = "Check whether your password is secure.")]
        public bool CheckPassword { get; set; }
    }
}
