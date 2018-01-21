using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenon.BusinessLogic.Models;
using Xenon.BusinessLogic.Interface;

namespace Xenon.BusinessLogic.Controllers
{
  class GeographicScopeAction : IGeographicScopeAction
  {
    public void AddContractScope(Guid contractId, Guid geographicZoneId)
    {
      using (var ctx = new BusinessContext())
      {
        ctx.GeograpicScopes.Add(new GeographicScope() { Contract = contractId, Zone = geographicZoneId });

        ctx.SaveChanges();

      }
    }
  }
}
