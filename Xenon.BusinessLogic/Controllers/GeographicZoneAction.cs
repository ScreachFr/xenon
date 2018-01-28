using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenon.BusinessLogic.Exceptions;
using Xenon.BusinessLogic.Interface;
using Xenon.BusinessLogic.Models;
using Xenon.BusinessLogic.Utils.DataModel;

namespace Xenon.BusinessLogic.Controllers
{
  public class GeographicZoneAction : IGeographicZoneAction
  {
    private static String ZONES_PATH = AppDomain.CurrentDomain.BaseDirectory + @"\GeographicZones.json";

    public GeographicZone AddGeographicZone(GeographicZone zone)
    {
      try
      {
        if (IsZoneNameInUse(zone.Name))
          throw new DBFieldDuplicationException("This GeograpicZone name is already in use. (" + zone.Name + ")");
        return AddGeographicZoneToDB(zone);
      }
      catch (Exception)
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


        }
        else
          return false;

      }
    }

    public void AddContractScope(Guid contractId, Guid geographicZoneId)
    {
      using (var ctx = new BusinessContext())
      {
        ctx.GeograpicScopes.Add(new GeographicScope() { Contract = contractId, Zone = geographicZoneId });

        ctx.SaveChanges();

      }
    }

    public Guid GetGeographicZoneByContractId(Guid contractid)
    {
      using (var ctx = new BusinessContext())
      {
        var query = from c in ctx.GeograpicScopes
                    where c.Contract.Equals(contractid)
                    select c.Zone;
        return query.FirstOrDefault();
      }
    }

    public GeographicZone GetZoneByName(String name)
    {
      using (var ctx = new BusinessContext())
      {
        var query = from z in ctx.GeographicZones
                    where z.Name.Equals(name)
                    select z;

        return query.FirstOrDefault();
      }
    }

    public void UpdateGeographicZones()
    {
      using (StreamReader r = new StreamReader(ZONES_PATH))
      {
        string json = r.ReadToEnd();
        var values = JsonConvert.DeserializeObject<GeographicZoneData>(json);
        
        using (var ctx = new BusinessContext())
        {
          UpdateZone(ctx, new Guid(), values);
        }
      }

    }

    private void UpdateZone(BusinessContext bc, Guid fatherId, GeographicZoneData gz)
    {
      var dbZone = GetZoneByName(gz.Name);
      if(dbZone == null)
      {
        dbZone = bc.GeographicZones.Add(new GeographicZone() { Name = gz.Name });
      }

      gz.Childs.ForEach(c => UpdateZone(bc, dbZone.Id, c));
    }
  }
}
