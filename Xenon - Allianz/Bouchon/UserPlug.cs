using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xenon___Allianz.Interface;
using Xenon___Allianz.Models;

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
            foreach (var item in Database.users)
            {
                if (u.Username.Equals(item.Username) && u.Password.Equals(item.Password))
                {
                    return item;
                }
            }
            return null;
        }

        public bool Register(UserModel u)
        {
            throw new NotImplementedException();
        }
    }
}