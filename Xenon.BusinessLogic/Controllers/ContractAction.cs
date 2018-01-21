using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public List<Contract> GetContractByWalletId(Guid walletId)
    {
      using (var ctx = new BusinessContext())
      {
        var query = from c in ctx.Contracts
                    where c.Wallet.Equals(walletId)
                    select c;

        var result = new List<Contract>();
        foreach (var item in query)
        {
          result.Add(item);
        }

        return result;
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
  }
}
