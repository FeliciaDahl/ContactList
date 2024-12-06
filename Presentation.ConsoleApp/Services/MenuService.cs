
using Business.Entites;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Presentation.ConsoleApp.Interfaces;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Presentation.ConsoleApp.Services;

public class MenuService(IUserService userService) : IMenuService
{
    private readonly IUserService _userService = userService;

    public void Run()
    {
        var isRunning = true;
        do
        {
            Console.Clear();
            Console.WriteLine("-----MAIN MENU-----");
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. View users");
            Console.WriteLine("3. Remove user");
            Console.WriteLine("q. Quit application");
            Console.WriteLine("-------------------");

            Console.Write("Please choose one option from the menu: ");
            var option = Console.ReadLine()!;


            switch (option.ToLower())
            {
                case "1":
                    AddUser();
                    break;

                case "2":
                    ShowList();
                    break;

                case "3":
                    Console.Clear();
                    break;

                case "q":
                    QuitOption();
                    break;

                default:
                    Console.Clear();
                    OutputDialog("Please enter a valid key");
                    Console.ReadKey();
                    break;
            }

        } while (isRunning);
    }

    public void AddUser()
    {
        var user = UserFactory.Create();

        Console.Clear();
        Console.WriteLine("Enter first name : ");
        user.FirstName = Console.ReadLine()!;

        Console.WriteLine("Enter last name : ");
        user.LastName = Console.ReadLine()!;

        Console.WriteLine("Enter email : ");
        user.Email = Console.ReadLine()!;

        Console.WriteLine("Enter phonenumber : ");
        user.Phone = Console.ReadLine()!;

        Console.WriteLine("Enter andress : ");
        user.Adress = Console.ReadLine()!;

        Console.WriteLine("Enter postalcode : ");
        user.PostalCode = Console.ReadLine()!;

        Console.WriteLine("Enter city : ");
        user.City = Console.ReadLine()!;

        bool result = _userService.CreateUser(user);

        if (result)
            OutputDialog("User was created");
        else 
            OutputDialog("We could not create a user, please try again");

        Console.ReadKey();
    }

    public void ShowList()
    {
        var users = _userService.GetAll();

        Console.Clear();
        if (!users.Any())
        {
            OutputDialog("No users were found in the list");
            return;
        }
        foreach (var user in users)
        {
            Console.WriteLine($"{"Name:",-5}{user.FullName}");
            Console.WriteLine($"{"Email:",-5}{user.Email}");
            Console.WriteLine($"{"Phone:",-5}{user.Phone}");
            Console.WriteLine($"{"Adress:",-5}{user.Adress}");
            Console.WriteLine($"{"PostalCode:",-5}{user.PostalCode}");
            Console.WriteLine($"{"City:",-5}{user.City}");
            Console.WriteLine();
        }
        Console.ReadKey ();
    }

    public void QuitOption()
    {
        Console.Clear();
        Console.WriteLine("Do you want to exit? y/n?");
        var option = Console.ReadLine()!;

        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            Environment.Exit(0);
        }
    }
    public void OutputDialog(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        Console.ReadKey();

    }
}
