using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenon.BusinessLogic.Interface;
using Xenon.BusinessLogic.Models;

namespace Xenon.BusinessLogic.Controllers
{
  class GeoUserScopeAction : IGeoUserScopeAction
  {
    public void BindUserHisWithZone(User u)
    {
      using (var ctx = new BusinessContext())
      {
        var scopeRule = new GeoUserScope() { User = u.Id, Zone = u.GeographicZone };

        ctx.GeoUserScopes.Add(scopeRule);
        ctx.SaveChanges();
      }
    }
  }
}
