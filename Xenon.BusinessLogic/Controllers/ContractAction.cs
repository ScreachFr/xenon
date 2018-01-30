using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Xenon.BusinessLogic.Models;
using Xenon.BusinessLogic.Interface;

namespace Xenon.BusinessLogic.Controllers
{
  public class ContractAction : IContractAction
  {
    public bool AddContract(Contract c)
    {
      try
      {
        AddContractToDB(c);
        return true;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.StackTrace);
        return false;
      }

    }

    private void AddContractToDB(Contract c)
    {

      using (var ctx = new BusinessContext())
      {
        ctx.Contracts.Add(c);
        ctx.SaveChanges();
      }
    }

    public bool EditContract(Guid contractId, Contract c)
    {
      using (var ctx = new BusinessContext())
      {
        var query = from contract in ctx.Contracts
                    where contract.Id.Equals(contractId)
                    select contract;

        var toModify = query.FirstOrDefault();

        if (toModify == null)
          return false;
        else
        {
          toModify.Update(c);
          ctx.Entry(toModify).State = System.Data.Entity.EntityState.Modified;
          ctx.SaveChanges();
          return true;
        }
      }
      throw new NotImplementedException();
    }

    public Contract GetContractById(Guid id)
    {
      using (var ctx = new BusinessContext())
      {
        var query = from c in ctx.Contracts
                    where c.Id.Equals(id)
                    select c;

        return query.FirstOrDefault();
      }
    }

    public List<Contract> GetContractByWalletId(Guid walletId, Guid geoid)
    {
      using (var ctx = new BusinessContext())
      {
        System.Linq.Expressions.Expression<Func<Guid, Guid, bool>> Test = (p1, p2) => p1.Equals(p2);

        var query = from c in ctx.Contracts
                    join g in ctx.GeograpicScopes on c.Id equals g.Contract
                    where c.Wallet.Equals(walletId)
                    select new { Contract = c, Zone = g };

        //var query = ctx.Contracts.Include("GeographicZones").Where(c =>c.Wallet.Equals(walletId) && c.GeographicZones.Select(e => e.Id).Contains(geoid) ).ToList();

        var contractsAndZones = query.Where(c => IsWithinScope(geoid, c.Zone.Zone)).ToList();

        var result = contractsAndZones.Select(e => e.Contract);

        return result.ToList();

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

    public List<Contract> GetContractByWalletId(Guid walletId, int page, int numberByPage)
    {
      using (var ctx = new BusinessContext())
      {
        var query = from c in ctx.Contracts
                    where c.Wallet.Equals(walletId)
                    && c.Position <= (page * numberByPage) && c.Position > ((page * numberByPage) - numberByPage)
                    select c;

        var result = new List<Contract>();
        foreach (var item in query)
        {
          result.Add(item);
        }

        return result;
      }
    }

    public List<Contract> GetAllContract()
    {
      using (var ctx = new BusinessContext())
      {
        var query = from c in ctx.Contracts
                    select c;

        var result = new List<Contract>();
        foreach (var item in query)
        {
          result.Add(item);
        }

        return result;
      }

    }

    public void AddGeoZoneToContract(Guid contractId, Guid zoneId)
    {
      using (var ctx = new BusinessContext())
      {
        ctx.GeograpicScopes.Add(new GeographicScope() { Contract = contractId, Zone = zoneId });

        ctx.SaveChanges();
      }


    }
  }




  
}
