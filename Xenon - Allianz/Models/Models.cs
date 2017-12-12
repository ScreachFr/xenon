using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Xenon___Allianz.Models
{
    

    public class Database
    {
        public static HashSet<UserModel> users = new HashSet<UserModel>();
        public static HashSet<WalletModel> wallets = new HashSet<WalletModel>();
        public static HashSet<ContractModel> contracts = new HashSet<ContractModel>();


        public Database()
        {
            users = new HashSet<UserModel>();
            wallets = new HashSet<WalletModel>();
            contracts = new HashSet<ContractModel>();
            
            users.Add(new UserModel() { Username = "mohamed", Password = "pass", Type ="Colaborateur", Mail=""});
            users.Add(new UserModel() { Username = "alex", Password = "pass", Type = "Colaborateur", Mail = "" });
            users.Add(new UserModel() { Username = "gaetan", Password = "pass", Type = "Colaborateur", Mail = "" });
            users.Add(new UserModel() { Username = "admin", Password = "pass" });
            
            wallets.Add(new WalletModel() { Service = "Health" });
            wallets.Add(new WalletModel() { Service = "Defense" });
            wallets.Add(new WalletModel() { Service = "Sport" });
            /*
            contracts.Add(new ContractModel() { Start = DateTime.Now, End = DateTime.Now, Couverture = 15, Negociable = true, Prime = 15, Company = "Renault", Wallet = "Health" });
            contracts.Add(new ContractModel() { Start = DateTime.Now, End = DateTime.Now, Couverture = 15, Negociable = true, Company = "CardiWeb", Wallet = "Health" });
            contracts.Add(new ContractModel() { Start = DateTime.Now, End = DateTime.Now, Couverture = 15, Negociable = true, Company = "Avanade", Wallet = "Health" });
            contracts.Add(new ContractModel() { Start = DateTime.Now, End = DateTime.Now, Couverture = 15, Negociable = true, Company = "Levalois Metropolitans", Wallet = "Sport" });
            contracts.Add(new ContractModel() { Start = DateTime.Now, End = DateTime.Now, Couverture = 15, Negociable = true, Company = "Psg", Wallet = "Sport" });
            contracts.Add(new ContractModel() { Start = DateTime.Now, End = DateTime.Now, Couverture = 15, Negociable = true, Prime = 15, Company = "France", Wallet = "Defense" });
            */
        }
    }
}