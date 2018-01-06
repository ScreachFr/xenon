using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenon.Interface;
using Xenon.Models;

namespace Xenon.BusinessLogic.Controllers
{
  class WalletAction : IWalletAction
  {
    public bool AddWallet(WalletModel w, Guid userId)
    {
      throw new NotImplementedException();
    }

    public bool EditWallet(Guid walletId, WalletModel w)
    {
      throw new NotImplementedException();
    }

    public List<WalletModel> GetWalletByScope(Guid userId)
    {
      throw new NotImplementedException();
    }
  }
}
