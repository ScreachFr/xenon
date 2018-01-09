using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenon.BusinessLogic.Models;

namespace Xenon.BusinessLogic.Interface
{
  interface IGeoUserScopeAction
  {
    void BindUserHisWithZone(User u);
  }
}
