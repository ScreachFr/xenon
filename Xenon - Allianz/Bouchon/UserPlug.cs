using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xenon___Allianz.Interface;
using Xenon___Allianz.Models;
using Xenon.BusinessLogic.Controllers;
using Xenon.BusinessLogic.Models;

namespace Xenon___Allianz.Bouchon
{
    public class UserPlug : IUserAction
    {
        public bool EditPassWord(int userId, string password)
        {
            throw new NotImplementedException();
        }

        public bool EditStatus(int userId, string status)
        {
            throw new NotImplementedException();
        }

        public UserModel Login(UserModel u)
        {
            /*User uu = UsersController.CheckLoginAndPassword(u.Username, u.Password);
            if (uu == null)
                return null;
            u = new UserModel() { Id = 1, Username = uu.Username, Password = uu.Password, Status = uu.Type, Mail = uu.Mail };
            */foreach (var item in Database.users)
            {
                if (u.Username.Equals(item.Username) && u.Password.Equals(item.Password))
                {
                    return item;
                }
            }
            return null;
            /*
            return u;
            */
        }

        public bool Register(UserModel u)
        {
            //UsersController.Register(u.Username, u.Password, u.Status, u.Mail);
            
            foreach (var item in Database.users)
            {
                if (item.Username.Equals(u.Username))
                    return false;
            }
            Database.users.Add(u);
            
            return true;
            
        }
    }
}