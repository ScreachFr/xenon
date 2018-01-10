using System;
using System.Collections.Generic;
using System.Text;
using Xenon.BusinessLogic.Models;
using Xenon.BusinessLogic.Utils;
using System.Linq;
using Xenon.BusinessLogic.Exceptions;
using Xenon.Interface;

namespace Xenon.BusinessLogic.Controllers
{
    public class UserAction : IUserAction
    {


        private static bool IsUsernameTaken(String username)
        {
            using (var ctx = new BusinessContext())
            {
                var query = from u in ctx.Users
                            where u.Username.Equals(username)
                            select u;

                var count = query.Count();

                if (count > 0)
                    return true;
                else
                    return false;

            }
        }

        public User Login(string username, string password)
        {
            using (var ctx = new BusinessContext())
            {
                String hashedPassword = SHA.GenerateSHA256String(password);

                try
                {


                    var query = from usr in ctx.Users
                                where usr.Username.Equals(username) && usr.Password.Equals(hashedPassword)
                                select usr;

                    var count = query.Count();

                    // Not the right way to do it.
                    if (count > 0)
                    {
                        User r = query.First();
                        return r;
                    }
                    else
                        return null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                return null;
            }
        }

        public bool Register(User u)
        {
            if (IsUsernameTaken(u.Username))
                throw new DBFieldDuplicationException("Username already taken.");

            using (var ctx = new BusinessContext())
            {
                String hashedPassword = SHA.GenerateSHA256String(u.Password);
                u.Password = hashedPassword;
                ctx.Users.Add(u);
                ctx.GeoUserScopes.Add(new GeoUserScope() { User = u.Id, Zone = u.GeographicZone });

                ctx.SaveChanges();
                return true;
            }
        }

        public bool EditStatus(Guid userId, string status)
        {
            throw new NotImplementedException();
        }

        public bool EditPassWord(Guid userId, string password)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            using (var ctx = new BusinessContext())
            {
                var query = from u in ctx.Users
                            select u;

                var result = new List<User>();
                foreach (var item in query)
                {
                    result.Add(item);
                }

                return result;
            }
        }
    }
}
