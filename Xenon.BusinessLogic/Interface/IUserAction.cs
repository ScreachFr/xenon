using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenon.BusinessLogic.Models;

namespace Xenon.BusinessLogic.Interface
{
    public interface IUserAction
    {
        User Login(String username, String password);
        bool Register(User u);
        bool EditStatus(Guid userId, string status, string filename);
        bool EditPassWord(Guid userId, string password);
        User GetUserById(Guid id);
        List<User> GetAllUsers();
    }
}
