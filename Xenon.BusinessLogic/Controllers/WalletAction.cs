﻿using System;
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
        public bool AddWallet(Wallet w, Guid userId, bool initial)
        {
            if (IsWalletNameAlreadyInUse(w.Service))
                return false;

            try
            {
                var newWallet = AddWalletToDB(w);

                AddScope(userId, newWallet.Id, initial);
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

        public void AddScope(Guid idUser, Guid idWallet, bool inital)
        {
            using (var ctx = new BusinessContext())
            {

                ctx.Scopes.Add(new Scope
                {
                    Initial = inital,
                    User = idUser,
                    Wallet = idWallet
                });
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

                return query.Count() > 0;
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
        public List<Wallet> GetWalletNotInUserScope(Guid userId)
        {
            using (var ctx = new BusinessContext())
            {
                var sc = ctx.Scopes.Where(s => s.User.Equals(userId)).Select(s => s.Wallet).ToList();
                var query = ctx.Wallets.Where(w => !sc.Contains(w.Id)).ToList();
                return query;
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

                return query.FirstOrDefault();
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


        public bool GetScopeWalletByWalletIdAndUserId(Guid userid, Guid walletid)
        {
            using (var ctx = new BusinessContext())
            {
                var query = from s in ctx.Scopes
                            where s.User.Equals(userid) && s.Wallet.Equals(walletid)
                            select s.Initial;
                return query.FirstOrDefault();
            }
        }
    }
}
