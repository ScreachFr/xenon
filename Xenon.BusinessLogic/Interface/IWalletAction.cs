using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenon.BusinessLogic.Models;

namespace Xenon.Interface
{
  public interface IWalletAction
  {
    List<Wallet> GetWalletByScope(Guid userId);

    bool AddWallet(Wallet w, Guid userId);

    bool EditWallet(Guid walletId, Wallet w);

    int NumberOfContractsByWalletId(Guid walletId);

    Wallet GetWalletById(Guid walletId);
  }
}
