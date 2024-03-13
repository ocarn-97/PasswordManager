using CommandLine;
using CommandLine.Text;
using PasswordManager;

Console.WriteLine(@"
  _____                                    _   __  __                                   
 |  __ \                                  | | |  \/  |                                  
 | |__) |_ _ ___ _____      _____  _ __ __| | | \  / | __ _ _ __   __ _  __ _  ___ _ __ 
 |  ___/ _` / __/ __\ \ /\ / / _ \| '__/ _` | | |\/| |/ _` | '_ \ / _` |/ _` |/ _ \ '__|
 | |  | (_| \__ \__ \\ V  V / (_) | | | (_| | | |  | | (_| | | | | (_| | (_| |  __/ |   
 |_|   \__,_|___/___/ \_/\_/ \___/|_|  \__,_| |_|  |_|\__,_|_| |_|\__,_|\__, |\___|_|   
                                                                         __/ |          
                                                                        |___/        ");
Console.WriteLine("Welcome to the Password Manager! This console application allows you to save passwords for your most sacred of accounts.");
Console.WriteLine("Enter '-h' or 'help' to see the menu options.");
Console.WriteLine("\nPlease enter your command:");

while (true)
{
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
               var parserResult = Parser.Default.ParseArguments<Options>(new string[] { });
               var helpText = new HelpText(new HeadingInfo("Password Manager", "1.0"));
               helpText.AddOptions(parserResult);
               Console.WriteLine(helpText);
               return;
           }

           if (options.Exit)
           {
               Console.WriteLine("Exiting Password Manager...");
               System.Threading.Thread.Sleep(1000);
               Environment.Exit(0);
           }

           if (options.AddAccount)
           {
               Console.WriteLine("Adding account...");
           }

           if (options.DeleteAccount)
           {
               Console.WriteLine("Deleting account...");
           }

           if (options.RetrieveAccounts)
           {
               Console.WriteLine("Retrieving all accounts...");
           }

           if (options.UpdateAccount)
           {
               Console.WriteLine("Updating account...");
           }
       })
       .WithNotParsed(errors =>
       {
           Console.WriteLine("Invalid command. Please try again.");
       });
}