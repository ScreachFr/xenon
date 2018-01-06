using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenon.Models;

namespace Xenon.Interface
{
    public interface IWalletAction
    {
        List<WalletModel> GetWalletByScope(Guid userId);

        bool AddWallet(WalletModel w, Guid userId);

        bool EditWallet(Guid walletId, WalletModel w);

    }
}
