using System;
using System.Collections.Generic;
using System.Text;
using Xenon.BusinessLogic.Models;
using Xenon.BusinessLogic.Utils;
using System.Linq;
using Xenon.BusinessLogic.Exceptions;
using Xenon.BusinessLogic.Interface;

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

    public bool EditStatus(Guid userId, string status, string filename)
    {
      using (var ctx = new BusinessContext())
      {
        var query = from u in ctx.Users
                    where u.Id == userId
                    select u;
        User usr = query.FirstOrDefault();

        if (usr != null)
        {
          return false;
        }
        else
        {
          usr.Status = status;
          ctx.Entry(usr).State = System.Data.Entity.EntityState.Modified;
          ctx.SaveChanges();

          return true;
        }

      }

    }

    public bool EditPassWord(Guid userId, string password)
    {
       using (var ctx = new BusinessContext())
      {
        var query = from u in ctx.Users
                    where u.Id == userId
                    select u;
        User usr = query.FirstOrDefault();

        if (usr != null)
        {
          return false;
        }
        else
        {
          usr.Password = SHA.GenerateSHA256String(password);
          ctx.Entry(usr).State = System.Data.Entity.EntityState.Modified;
          ctx.SaveChanges();

          return true;
        }
      }
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

    public User GetUserById(Guid id)
    {
      using (var ctx = new BusinessContext())
      {
        var query = from usr in ctx.Users
                    where usr.Id.Equals(id)
                    select usr;

        return query.FirstOrDefault();
      }
    }
  }
}
