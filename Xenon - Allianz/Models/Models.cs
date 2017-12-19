using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Xenon___Allianz.Models
{


    public class Database
    {
        public static List<UserModel> users;
        public static List<WalletModel> wallets;
        public static List<ContractModel> contracts;
        public static List<ScopeModel> scopes;


        public Database()
        {
            users = new List<UserModel>();
            wallets = new List<WalletModel>();
            contracts = new List<ContractModel>();
            scopes = new List<ScopeModel>();
            int cpt=0;
            users.Add(new UserModel() { Id = cpt++, Username = "mohamed", Password = "pass", Status = "souscripteur", Mail = "mohamed@xenon.com" });
            users.Add(new UserModel() { Id = cpt++, Username = "alex", Password = "pass", Status = "manager", Mail = "mohamed@xenon.com" });
            users.Add(new UserModel() { Id = cpt++, Username = "admin", Password = "pass", Status = "admin", Mail = "admin@xenon.com" });

            wallets.Add(new WalletModel() { Id = cpt++, Service = "Health" });
            wallets.Add(new WalletModel() { Id = cpt++, Service = "Defense" });
            wallets.Add(new WalletModel() { Id = cpt++, Service = "Sport" });

            scopes.Add(new ScopeModel() { User = users[0].Id, Wallet = wallets[0].Id });
            scopes.Add(new ScopeModel() { User = users[0].Id, Wallet = wallets[1].Id });
            scopes.Add(new ScopeModel() { User = users[0].Id, Wallet = wallets[2].Id });
            scopes.Add(new ScopeModel() { User = users[1].Id, Wallet = wallets[0].Id });
            scopes.Add(new ScopeModel() { User = users[1].Id, Wallet = wallets[1].Id });

            contracts.Add(new ContractModel() { Id = cpt++, Start = DateTime.Now, End = DateTime.Now, Cover = 15, Negociable = true, Prime = 15, Company = "Renault", Wallet = "Health" });
            contracts.Add(new ContractModel() { Id = cpt++, Start = DateTime.Now, End = DateTime.Now, Cover = 15, Negociable = true, Company = "CardiWeb", Wallet = "Health" });
            contracts.Add(new ContractModel() { Id = cpt++, Start = DateTime.Now, End = DateTime.Now, Cover = 15, Negociable = true, Company = "Avanade", Wallet = "Health" });
            contracts.Add(new ContractModel() { Id = cpt++, Start = DateTime.Now, End = DateTime.Now, Cover = 15, Negociable = true, Company = "Levalois Metropolitans", Wallet = "Sport" });
            contracts.Add(new ContractModel() { Id = cpt++, Start = DateTime.Now, End = DateTime.Now, Cover = 15, Negociable = true, Company = "Psg", Wallet = "Sport" });
            contracts.Add(new ContractModel() { Id = cpt++, Start = DateTime.Now, End = DateTime.Now, Cover = 15, Negociable = true, Prime = 15, Company = "France", Wallet = "Defense" });
        }

        public static UserModel Login(UserModel u)
        {
            foreach (var item in users)
            {
                if (u.Username.Equals(item.Username) && u.Password.Equals(item.Password))
                {
                    return item;
                }
            }
            return null;
        }
        public static bool Register(UserModel u)
        {
            foreach (var item in users)
            {
                if (item.Username.Equals(u.Username))
                    return false;
            }
            users.Add(u);
            return true;
        }
        public static ISet<WalletModel> GetWalletByScope(int userId)
        {
            ISet<WalletModel> s = new HashSet<WalletModel>();
            List<WalletModel> l = new List<WalletModel>();
            foreach (var item in scopes)
            {
                if(item.User == userId)
                {
                    foreach (var wal in wallets)
                    {
                        if (wal.Id.Equals(item.Wallet))
                        {
                            s.Add(wal);
                        }
                    }
                }
            }
           // s = new HashSet<WalletModel>()
            return s;
        }
        public static bool AddWallet(WalletModel w)
        {
            foreach (var item in wallets)
            {
                if (item.Service.Equals(w.Service))
                    return false;
            }
            wallets.Add(w);
            return true;
        }

        public static List<ContractModel> GetContractFromWallet(string s)
        {
            List<ContractModel> lc = new List<ContractModel>();
            foreach (var item in contracts)
            {
                if (item.Wallet.Equals(s))
                    lc.Add(item);
            }

            return lc;
        }
    }
}