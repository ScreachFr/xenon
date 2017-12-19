using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xenon.BusinessLogic.Models
{
  public class User
  {

    public string Username { get; set; }
    public string Password { get; set; }
    public string Type { get; set; }
    public string Mail { get; set; }

    public User(String username, String password, String type, String mail)
    {
      this.Username = username;
      this.Password = password;
      this.Type = type;
      this.Mail = mail;
    }
  }
}
