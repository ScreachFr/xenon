using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenon___Allianz.Models;

namespace Xenon___Allianz.Interface
{
    public interface IWalletAction
    {
        List<WalletModel> GetWalletByScope(int userId);

        bool AddWallet(WalletModel w, int userId);

        bool EditWallet(int walletId, WalletModel w);

    }
}
