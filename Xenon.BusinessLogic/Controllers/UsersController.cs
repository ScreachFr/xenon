using System;
using System.Collections.Generic;
using System.Text;
using Xenon.BusinessLogic.Models;
using Xenon.BusinessLogic.Utils;
using System.Linq;
using Xenon.BusinessLogic.Exceptions;

namespace Xenon.BusinessLogic.Controllers
{
  class UsersController
  {

    public static bool CheckLoginAndPassword(String username, String password)
    {
      using (var ctx = new BusinessContext())
      {
        String hashedPassword = SHA.GenerateSHA256String(password);

        var query = from u in ctx.Users
                   where u.Username.Equals(username) && u.Password.Equals(hashedPassword)
                   select u;

        // Not the right way to do it.
        if (query.Count() > 0)
          return false;
        else
          return true;
      }
      

    }

    public static void ChangePassword(String oldPwd, String newPwd)
    {
      // TODO
      throw new NotImplementedException();
    }

    public static void Register(String username, String password, String type, String mail)
    {
      if (IsUsernameTaken(username)) 
        throw new DBFieldDuplicationException("Username already taken.");
      
      using (var ctx = new BusinessContext())
      {
        User u = new User(username, password, type, mail);
        ctx.Users.Add(u);
        
        // TODO handle exception.
        ctx.SaveChanges();
      }

    }

    private static bool IsUsernameTaken(String username)
    {
      using (var ctx = new BusinessContext())
      {
        var query = from u in ctx.Users
                    where u.Username.Equals(username)
                    select u;

        if (query.Count() > 0)
          return true;
        else
          return false;

      }
    }

  }
}
