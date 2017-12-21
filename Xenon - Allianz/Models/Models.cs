﻿using System;
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
        static int cpt = 0;


        public Database()
        {
            users = new List<UserModel>();
            wallets = new List<WalletModel>();
            contracts = new List<ContractModel>();
            scopes = new List<ScopeModel>();
            
            users.Add(new UserModel() { Id = cpt++, Username = "mohamed", Password = "pass", Status = "souscripteur", Mail = "mohamed@xenon.com" });
            users.Add(new UserModel() { Id = cpt++, Username = "alex", Password = "pass", Status = "manager", Mail = "mohamed@xenon.com" });
            users.Add(new UserModel() { Id = cpt++, Username = "admin", Password = "pass", Status = "admin", Mail = "admin@xenon.com" });

            wallets.Add(new WalletModel() { Id = cpt++, Service = "Health" });
            wallets.Add(new WalletModel() { Id = cpt++, Service = "Defense" });
            wallets.Add(new WalletModel() { Id = cpt++, Service = "Agroalimentaire" });
            wallets.Add(new WalletModel() { Id = cpt++, Service = "Electricité - Electronique" });
            wallets.Add(new WalletModel() { Id = cpt++, Service = "Machine et equipements" });
            wallets.Add(new WalletModel() { Id = cpt++, Service = "Plastique" });
            wallets.Add(new WalletModel() { Id = cpt++, Service = "Transport" });

            scopes.Add(new ScopeModel() { User = users[0].Id, Wallet = wallets[0].Id });
            scopes.Add(new ScopeModel() { User = users[0].Id, Wallet = wallets[1].Id });
            scopes.Add(new ScopeModel() { User = users[0].Id, Wallet = wallets[2].Id });
            scopes.Add(new ScopeModel() { User = users[1].Id, Wallet = wallets[0].Id });
            scopes.Add(new ScopeModel() { User = users[1].Id, Wallet = wallets[1].Id });

            contracts.Add(new ContractModel() { Id = cpt++, Start = DateTime.Now, End = DateTime.Now, Cover = 15, Negociable = true, Prime = 15, Company = "Renault", Wallet = wallets[0].Id });
            contracts.Add(new ContractModel() { Id = cpt++, Start = DateTime.Now, End = DateTime.Now, Cover = 15, Negociable = true, Company = "CardiWeb", Wallet = wallets[0].Id });
            contracts.Add(new ContractModel() { Id = cpt++, Start = DateTime.Now, End = DateTime.Now, Cover = 15, Negociable = true, Company = "Avanade", Wallet = wallets[1].Id });
            contracts.Add(new ContractModel() { Id = cpt++, Start = DateTime.Now, End = DateTime.Now, Cover = 15, Negociable = true, Company = "Levalois Metropolitans", Wallet = wallets[1].Id });
            contracts.Add(new ContractModel() { Id = cpt++, Start = DateTime.Now, End = DateTime.Now, Cover = 15, Negociable = true, Company = "Psg", Wallet = wallets[2].Id });
            contracts.Add(new ContractModel() { Id = cpt++, Start = DateTime.Now, End = DateTime.Now, Cover = 15, Negociable = true, Prime = 15, Company = "France", Wallet = wallets[2].Id });

        }
    }
}