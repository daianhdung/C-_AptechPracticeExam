using Aptech_TH.Data;
using Aptech_TH.Entity;
using Aptech_TH.Exceptions;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aptech_TH.Services.Imp
{
    internal class UserServiceImp : UserService
    {
        private readonly ApplicationDbContext db;
        public UserServiceImp(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        User UserService.CreateUser(User user)
        {
            user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(user.Password);
            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }

        public void DeleteUser(int id)
        {
            var user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
        public User GetUserById(int id)
        {
            return db.Users.Find(id);
        }

        public User UpdateUser(User user)
        {
            db.Users.Update(user);
            db.SaveChanges();
            return user;
        }

        public User CheckLoginUser(string UserName, string Password)
        {
            User user = db.Users.Where(user => user.UserName.Equals(UserName)).First();
            if(user == null)
            {
                throw new CustomException("Username not existed");
            }
            bool passwordMatches = BCrypt.Net.BCrypt.EnhancedVerify(Password, user.Password);
            if (!passwordMatches)
            {
                throw new CustomException("Username or password is invalid");
            }
            return user;
        }

        public User GetUserByUserName(string UserName)
        {
            User user = db.Users.Where(user => user.UserName.Equals(UserName)).First();
            if (user == null)
            {
                throw new CustomException("Username not existed");
            }
            return user;
        }

        public List<User> GetUsers()
        {

            return db.Users.ToList();
        }
    }
}
