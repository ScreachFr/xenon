using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenon.BusinessLogic.Models;
using Xenon.Interface;
using Xenon.Models;

namespace Xenon.BusinessLogic.Controllers
{
  public class ContractAction : IContractAction
  {
    public bool AddContract(Contract c)
    {
      try {
        AddContractToDB(c);
        return true;
      } catch (Exception e) {
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
      throw new NotImplementedException();
    }

    public Contract GetContractById(Guid id)
    {
      using(var ctx = new BusinessContext())
      {
        var query = from c in ctx.Contracts
                    where c.Id.Equals(id)
                    select c;

        return query.First();
      }
    }

    public List<Contract> GetContractByWalletId(Guid walletId)
    {
      throw new NotImplementedException();
    }
  }
}
