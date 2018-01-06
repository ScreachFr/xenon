using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xenon___Allianz.Models;
using Xenon.BusinessLogic.Controllers;
using Xenon.BusinessLogic.Models;
using Xenon.Interface;

namespace Xenon___Allianz.Bouchon
{
  public class UserPlug : IUserAction
  {
    public bool EditPassWord(Guid userId, string password)
    {
      throw new NotImplementedException();
    }

    public bool EditStatus(Guid userId, string status)
    {
      throw new NotImplementedException();
    }

    public User Login(String username, String password)
    {
      /*User uu = UsersController.CheckLoginAndPassword(u.Username, u.Password);
      if (uu == null)
          return null;
      u = new UserModel() { Id = 1, Username = uu.Username, Password = uu.Password, Status = uu.Type, Mail = uu.Mail };
      */
      foreach (var u in Database.users)
      {
        if (u.Username.Equals(u.Username) && u.Password.Equals(u.Password))
        {
          return u;
        }
      }
      return null;
      /*
      return u;
      */
    }

    public bool Register(User u)
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