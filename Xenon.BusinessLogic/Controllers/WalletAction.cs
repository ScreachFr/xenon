using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenon.BusinessLogic.Models;
using Xenon.BusinessLogic.Interface;

namespace Xenon.BusinessLogic.Controllers
{
    public class WalletAction : IWalletAction
    {
        public bool AddWallet(Wallet w, Guid userId)
        {
            if (IsWalletNameAlreadyInUse(w.Service))
                return false;

            try
            {
                var newWallet = AddWalletToDB(w);

                AddScope(userId, newWallet.Id);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }


        }

        private Wallet AddWalletToDB(Wallet w)
        {
            using (var ctx = new BusinessContext())
            {
                var result = ctx.Wallets.Add(w);
                ctx.SaveChanges();

                return result;
            }
        }

        private void AddScope(Guid idUser, Guid idWallet)
        {
            using (var ctx = new BusinessContext())
            {
                ctx.Scopes.Add(new Scope(idUser, idWallet));
                ctx.SaveChanges();
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
            using (var ctx = new BusinessContext())
            {
                var query = from w in ctx.Wallets
                            join s in ctx.Scopes on w.Id equals s.Wallet
                            where s.User.Equals(userId)
                            select new { owner = s.User, wallet = w };

                var result = new List<Wallet>();
                foreach (var item in query)
                {
                    result.Add(item.wallet);
                }

                return result;
            }
        }

        public int NumberOfContractsByWalletId(Guid walletId)
        {

            using (var ctx = new BusinessContext())
            {
                var query = from c in ctx.Contracts
                            where c.Wallet.Equals(walletId)
                            select c;

                return query.Count();
            }
        }

        public Wallet GetWalletById(Guid walletId)
        {
            using (var ctx = new BusinessContext())
            {
                var query = from w in ctx.Wallets
                            where w.Id.Equals(walletId)
                            select w;

                int count = query.Count();

                if (count > 0)
                    return query.First();
                else
                    return null;


            }
        }

        public List<Wallet> GetAllWallet()
        {
            using (var ctx = new BusinessContext())
            {
                var query = from w in ctx.Wallets
                            select w;

                var result = new List<Wallet>();
                foreach (var item in query)
                {
                    result.Add(item);
                }

                return result;
            }
        }
    }
}
