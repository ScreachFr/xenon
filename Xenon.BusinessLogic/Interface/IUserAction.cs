using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenon.BusinessLogic.Models;

namespace Xenon.Interface
{
    public interface IUserAction
    {
        User Login(String username, String password);
        bool Register(User u);
        bool EditStatus(Guid userId, string status);
        bool EditPassWord(Guid userId, string password);
        List<User> GetAllUsers();
    }
}
