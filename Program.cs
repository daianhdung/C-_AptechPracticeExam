using Aptech_TH.Data;
using Aptech_TH.Entity;
using Aptech_TH.Services;
using Aptech_TH.Services.Imp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
                                Console.WriteLine("1.Add Loyalty Points");
                                Console.WriteLine("2. Print all user");
                                Console.WriteLine("0. Log out");
                                string optionRole = Console.ReadLine();
                                bool signOut = false;
                                while (!signOut)
                                {
                                    switch (optionRole)
                                    {
                                        case "1":
                                            Console.WriteLine("Input username");
                                            string UserNameLoyalty = Console.ReadLine();
                                            User userLoyalty = userService.GetUserByUserName(UserNameLoyalty);
                                            user.LoyaltyPoint = Console.Read();
                                            userService.UpdateUser(user);
                                            Console.WriteLine("Add loyalty point successfully");
                                            break;
                                        case "2":
                                            List<User> users = userService.GetUsers();
                                            users.ForEach(item => Console.WriteLine(item));
                                            break;
                                        case "0":
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
                                Console.WriteLine("1. Check Loyalty Point");
                                Console.WriteLine("0. Log out");
                                string optionRole = Console.ReadLine();
                                bool signOut = false;
                                while (!signOut)
                                {
                                    switch (optionRole)
                                    {
                                        case "1":
                                            Console.WriteLine("Input username");
                                            string UserNameLoyalty = Console.ReadLine();
                                            User UserLoyalty = userService.GetUserByUserName(UserNameLoyalty);
                                            Console.WriteLine(UserLoyalty);
                                            break;
                                        case "0":
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
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }

}