using System;
using System.Collections.Generic;
using System.Text;
using Xenon.BusinessLogic.Models;
using Xenon.BusinessLogic.Utils;
using System.Linq;
using Xenon.BusinessLogic.Exceptions;

namespace Xenon.BusinessLogic.Controllers
{
  public class UsersController
  {

    public static User CheckLoginAndPassword(String username, String password)
    {
      using (var ctx = new BusinessContext())
      {
        String hashedPassword = SHA.GenerateSHA256String(password);

        try
        {
          var query = from u in ctx.Users
                     where u.Username.Equals(username) && u.Password.Equals(hashedPassword)
                     select u;

          var count = query.Count();

        // Not the right way to do it.
          if (count > 0)
          return query.First();
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
        String hashedPassword = SHA.GenerateSHA256String(password);
        User u = new User(username, hashedPassword, type, mail);
        ctx.Users.Add(u);
        
        // TODO handle exception.
        ctx.SaveChanges();
        Console.WriteLine("Register done.");
      }

    }

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

  }
}
