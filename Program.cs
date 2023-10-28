using Aptech_TH.Entity;
using Aptech_TH.Services;
using Aptech_TH.Services.Imp;
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
            .BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var userService = scope.ServiceProvider.GetRequiredService<UserService>();
                var transactionService = scope.ServiceProvider.GetRequiredService<TransactionService>();

                // Sử dụng các dịch vụ ở đây
                while (true)
                {
                    Console.WriteLine("1. Sign up");
                    Console.WriteLine("2. Login");
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
                            break;
                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                }
            }
        }
    }
}