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

        // edit user status
        void AcceptUpdateStatusUser(Guid id);

        void RefuseUpdateStatusUser(Guid id);

        // sort by inProgress = true then inProgress status will be first in line
        List<UpdateStatus> GetUpdateStatus(bool inProgress);

        UpdateStatus GetUpdateStatusById(Guid id);


    }
}
