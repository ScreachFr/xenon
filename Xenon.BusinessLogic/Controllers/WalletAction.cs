using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenon.Interface;
using Xenon.Models;

namespace Xenon.BusinessLogic.Controllers
{
    public class WalletAction : IWalletAction
    {
        public bool AddWallet(Wallet w, Guid userId)
        {
            throw new NotImplementedException();
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
