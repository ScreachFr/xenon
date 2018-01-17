using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenon.BusinessLogic.Models;

namespace Xenon.BusinessLogic.Interface
{
    public interface IAdminAction
    {
        void AddUpdateStatusUser(UpdateStatus us);
        void UpdateStatusUser(UpdateStatus us);
    }
}
