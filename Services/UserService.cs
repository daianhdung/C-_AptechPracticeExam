using Aptech_TH.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aptech_TH.Services
{
    internal interface UserService
    {
        User GetUserById(int id);
        List<User> GetUsers();
        User GetUserByUserName(string UserName);
        User CheckLoginUser(string UserName, string Password);
        User CreateUser(User user);
        User UpdateUser(User user);
        void DeleteUser(int id);
    }
}
