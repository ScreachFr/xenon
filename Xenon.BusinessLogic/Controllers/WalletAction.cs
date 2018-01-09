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
  public class WalletAction : IWalletAction
  {
    public bool AddWallet(Wallet w, Guid userId)
    {
      if (IsWalletNameAlreadyInUse(w.Service))
        return false;

      try {
        AddWalletToDB(w);
        return true;
      } catch (Exception e) {
        Console.WriteLine(e.StackTrace);
        return false;
      }


    }

    private bool AddWalletToDB(Wallet w)
    {
      using (var ctx = new BusinessContext())
      {
        ctx.Wallets.Add(w);
        ctx.SaveChanges();
        Console.WriteLine("Register done.");

        return true;
      }
    }

    private bool IsWalletNameAlreadyInUse(String name)
    {
      using (var ctx = new BusinessContext())
      {
        var query = from w in ctx.Wallets
                    where w.Service.Equals(name)
                    select w;

        var count = query.Count();

        if (count > 0)
          return true;
        else
          return false;
      }
    }

    public bool EditWallet(Guid walletId, Wallet w)
    {
      throw new NotImplementedException();
    }

    public List<Wallet> GetWalletByScope(Guid userId)
    {
      throw new NotImplementedException();
    }

    public int NumberOfContractsByWalletId(Guid walletId)
    {
      throw new NotImplementedException();
    }
  }
}
