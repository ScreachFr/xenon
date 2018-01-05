using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenon___Allianz.Models;

namespace Xenon___Allianz.Interface
{
    public interface IUserAction
    {
        UserModel Login(UserModel u);
        bool Register(UserModel u);
        bool EditStatus(int userId, string status);
        bool EditPassWord(int userId, string password);
    }
}
