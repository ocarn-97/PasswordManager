****Password Manager****

Password Manager is a simple console-based application written in C# that allows users to manage their passwords. It provides basic functionalities such as adding, deleting, updating, and retrieving account information as well as generating and checking passwords. This program is insecure and not meant for production-use. 


****Features****

    - Add Account: Add a new account with a title, username, and password.
    - Delete Account: Delete an existing account based on its title.
    - Update Account: Update the username or password of an existing account.
    - Retrieve Accounts: Retrieve and display all existing accounts.


****Getting Started****

To get started with Password Manager, follow these steps:

    1. Clone the repository to your local machine:
      git clone https://github.com/your-username/password-manager.git

    2. Open the project in Visual Studio or your preferred C# development environment.

    3. Build the solution to ensure all dependencies are resolved.

    4. Run the application.


****Usage****

The application provides a command-line interface (CLI) for interacting with the password manager. Here are the available commands:

    - add: Add a new account.
    - delete: Delete an existing account.
    - update: Update an existing account.
    - retrieve: Retrieve and display all existing accounts.
    - generate: Generate a random password.
    - check: Check the strength of a password.


    Example usage:
    
    add --title gmail --username john.doe --password Pa$$w0rd
    delete --title facebook
    update --title gmail --username john.doe --password NewPa$$w0rd
    retrieve
    generate
    check --password Pa$$w0rd


****Contributing****

Contributions are welcome! If you find any bugs or have suggestions for new features, please open an issue or submit a pull request.


****License****

This project is licensed under the MIT License - see the LICENSE file for details.

****Acknowledgements****

This project was inspired by the need for a simple way to manage passwords.
