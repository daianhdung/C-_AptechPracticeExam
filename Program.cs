using Aptech_TH.Data;
using Aptech_TH.Entity;
using Aptech_TH.Services;
using Aptech_TH.Services.Imp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Aptech_TH
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddScoped<UserService, UserServiceImp>()
            .AddScoped<TransactionService, TransactionServiceImp>()
            .AddDbContext<ApplicationDbContext>()
            .BuildServiceProvider();

            var userService = serviceProvider.GetRequiredService<UserService>();
            var transactionService = serviceProvider.GetRequiredService<TransactionService>();
            

            // Sử dụng các dịch vụ ở đây
            while (true)
            {
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Sign up");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Input username");
                        string UserName = Console.ReadLine();
                        Console.WriteLine("Input password");
                        string Password = Console.ReadLine();
                        try
                        {
                            User user = userService.CheckLoginUser(UserName, Password);
                            if (user.RoleId == 1)
                            {
                                Console.WriteLine("Login successfully, hello " + user.UserName);
                                bool signOut = false;
                                while (!signOut)
                                {
                                    Console.WriteLine("1. Add Loyalty Points");
                                    Console.WriteLine("2. Print all user");
                                    Console.WriteLine("0. Log out");
                                    string optionRole = Console.ReadLine();
                                    switch (optionRole)
                                    {
                                        case "1":
                                            Console.WriteLine("Input username");
                                            string UserNameLoyalty = Console.ReadLine();
                                            User userLoyalty = userService.GetUserByUserName(UserNameLoyalty);
                                            Console.WriteLine("Input total payment");
                                            string TotalPayment = Console.ReadLine();
                                            Transaction transaction = new Transaction();
                                            try
                                            {

                                            }catch(Exception ex)
                                            {
                                                Console.WriteLine(new StackTrace().ToString());
                                            }
                                            userLoyalty.LoyaltyPoint = Int32.Parse(TotalPayment) / 100000;
                                            userService.UpdateUser(userLoyalty);
                                            Console.WriteLine($"Add {userLoyalty.LoyaltyPoint} loyalty point to {userLoyalty.UserName} successfully");
                                            break;
                                        case "2":
                                            List<User> users = userService.GetUsers();
                                            users.ForEach(item => Console.WriteLine(item.ToString()));
                                            break;
                                        case "0":
                                            Console.WriteLine("Log out successfully");
                                            signOut = true;
                                            break;
                                        default:
                                            Console.WriteLine("Invalid option");
                                            break;
                                    }
                                }
                            }
                            else if (user.RoleId == 2)
                            {

                                Console.WriteLine("Login successfully, hello " + user.UserName);
                                bool signOut = false;
                                while (!signOut)
                                {
                                    Console.WriteLine("1. Check Loyalty Point");
                                    Console.WriteLine("0. Log out");
                                    string optionRole = Console.ReadLine();
                                    switch (optionRole)
                                    {
                                        case "1":
                                            User UserLoyalty = userService.GetUserByUserName(user.UserName);
                                            Console.WriteLine(UserLoyalty.ToString());
                                            break;
                                        case "0":
                                            Console.WriteLine("Log out successfully");
                                            signOut = true;
                                            break;
                                        default:
                                            Console.WriteLine("Invalid option");
                                            break;
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "2":
                        Console.WriteLine("Input username");
                        string UserNameRegister = Console.ReadLine();
                        Console.WriteLine("Input password");
                        string PasswordRegister = Console.ReadLine();
                        User NewUser = new User();
                        NewUser.UserName = UserNameRegister;
                        NewUser.Password = PasswordRegister;
                        NewUser.RoleId = 2;
                        userService.CreateUser(NewUser);
                        Console.WriteLine("Sign up successfully! Please log in");
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }

}