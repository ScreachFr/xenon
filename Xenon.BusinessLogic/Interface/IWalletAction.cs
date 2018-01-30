using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenon.BusinessLogic.Models;

namespace Xenon.BusinessLogic.Interface
{
    public interface IWalletAction
    {
        List<Wallet> GetWalletByScope(Guid userId);

        List<Wallet> GetWalletNotInUserScope(Guid userId);
        
        bool AddWallet(Wallet w, Guid userId, bool initial);

        bool EditWallet(Guid walletId, Wallet w);

        int NumberOfContractsByWalletId(Guid walletId);

        Wallet GetWalletById(Guid walletId);

        List<Wallet> GetAllWallet();

        bool GetScopeWalletByWalletIdAndUserId(Guid userid, Guid walletid);

        void AddScope(Guid idUser, Guid idWallet, bool inital);
    }
}
