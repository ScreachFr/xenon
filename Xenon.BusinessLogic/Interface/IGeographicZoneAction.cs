using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenon.BusinessLogic.Models;

namespace Xenon.BusinessLogic.Interface
{
  interface IGeographicZoneAction
  {
    GeographicZone AddGeographicZone(GeographicZone zone);

    GeographicZone GetGeographicZoneById(Guid id);

    List<GeographicZone> GetAllAvailableGeographicZones();

    bool IsWithinScope(Guid father, Guid supposedChild);
  }
}
