using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenon.BusinessLogic.Exceptions;
using Xenon.BusinessLogic.Interface;
using Xenon.BusinessLogic.Models;

namespace Xenon.BusinessLogic.Controllers
{
  public class GeographicZoneAction : IGeographicZoneAction
  {
    public GeographicZone AddGeographicZone(GeographicZone zone)
    {
      try
      {
        if (IsZoneNameInUse(zone.Name))
          throw new DBFieldDuplicationException("This GeograpicZone name is already in use. (" + zone.Name + ")");
        return AddGeographicZoneToDB(zone);
      } catch(Exception)
      {
        return null;
      }
    }

    private GeographicZone AddGeographicZoneToDB(GeographicZone zone)
    {
      using (var ctx = new BusinessContext())
      {
        var result = ctx.GeographicZones.Add(zone);
        ctx.SaveChanges();

        return result;
      }
    }

    private bool IsZoneNameInUse(String name)
    {
      using (var ctx = new BusinessContext())
      {
        var query = from z in ctx.GeographicZones
                    where z.Name.Equals(name)
                    select z;
        return query.Count() > 0;
      }
    }

    public List<GeographicZone> GetAllAvailableGeographicZones()
    {
      using (var ctx = new BusinessContext())
      {
        var query = from z in ctx.GeographicZones
                    select z;

        var result = new List<GeographicZone>();

        foreach (var item in query)
        {
          result.Add(item);
        }


        return result;
      }
    }

    public GeographicZone GetGeographicZoneById(Guid id)
    {
      using (var ctx = new BusinessContext())
      {
        var query = from z in ctx.GeographicZones
                    where z.Id.Equals(id)
                    select z;
        var count = query.Count();

        if (count > 0)
          return query.First();
        else
          return null;
      }
    }

    public bool IsWithinScope(Guid father, Guid supposedChild)
    {
      if (father == null)
        return false;
      

      using (var ctx = new BusinessContext())
      {
        var query = from z in ctx.GeographicZones
                    where z.Id.Equals(supposedChild)
                    select z;
        var count = query.Count();

        if (count > 0)
        {
          var res = query.First();
          if (res.Father.Equals(father))
            return true;
          else
            return IsWithinScope(father, res.Father);


        } else
          return false;
        
      }

    }
    
  }
}
