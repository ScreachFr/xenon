using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xenon___Allianz.Interface;
using Xenon___Allianz.Models;

namespace Xenon___Allianz.Bouchon
{
    public class WalletPlug : IWalletAction
    {
        public bool AddWallet(WalletModel w, int userId)
        {
            foreach (var item in Database.wallets)
            {
                if (item.Service.Equals(w.Service))
                    return false;
            }
            Database.wallets.Add(w);
            Database.scopes.Add(new ScopeModel() { User = userId, Wallet = w.Id });
            return true;
        }

        public bool EditWallet(int walletId, WalletModel w)
        {
            throw new NotImplementedException();
        }

        public List<WalletModel> GetWalletByScope(int userId)
        {
            ISet<WalletModel> s = new HashSet<WalletModel>();
            List<WalletModel> l = new List<WalletModel>();
            foreach (var item in Database.scopes)
            {
                if (item.User == userId)
                {
                    foreach (var wal in Database.wallets)
                    {
                        if (wal.Id.Equals(item.Wallet))
                        {
                            s.Add(wal);
                        }
                    }
                }
            }
            // s = new HashSet<WalletModel>()
            return s.ToList();
        }
    }
}