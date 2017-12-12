using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Xenon___Allianz.Models
{
    public class UserModels
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int type { get; set; } = 4;
        public string mail { get; set; }
    }

    public class WalletModel
    {
        public string Service { get; set; }
    }

    public class ContractModel
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public double Couverture { get; set; }
        public bool Negociable { get; set; } = false;
        public int Prime { get; set; } = 0;
        public bool Rompu { get; set; } = false;
        public string Company { get; set; }
        public string Wallet { get; set; }
        public int Value { get; set; }
    }
    public class Database
    {
        public static HashSet<UserModels> users = new HashSet<UserModels>();
        public static HashSet<WalletModel> wallets = new HashSet<WalletModel>();
        public static HashSet<ContractModel> contracts = new HashSet<ContractModel>();


        public Database()
        {
            users = new HashSet<UserModels>();
            wallets = new HashSet<WalletModel>();
            contracts = new HashSet<ContractModel>();

            users.Add(new UserModels() { Username = "mohamed", Password = "pass" });
            users.Add(new UserModels() { Username = "admin", Password = "pass" });

            wallets.Add(new WalletModel() { Service = "Health" });
            wallets.Add(new WalletModel() { Service = "Defense" });
            wallets.Add(new WalletModel() { Service = "Sport" });

            contracts.Add(new ContractModel() { Start = DateTime.Now, End = DateTime.Now, Couverture = 15, Negociable = true, Prime = false, Company = "Renault", Wallet = "Health" });
            contracts.Add(new ContractModel() { Start = DateTime.Now, End = DateTime.Now, Couverture = 15, Negociable = true, Prime = false, Company = "CardiWeb", Wallet = "Health" });
            contracts.Add(new ContractModel() { Start = DateTime.Now, End = DateTime.Now, Couverture = 15, Negociable = true, Prime = false, Company = "Avanade", Wallet = "Health" });
            contracts.Add(new ContractModel() { Start = DateTime.Now, End = DateTime.Now, Couverture = 15, Negociable = true, Prime = false, Company = "Levalois Metropolitans", Wallet = "Sport" });
            contracts.Add(new ContractModel() { Start = DateTime.Now, End = DateTime.Now, Couverture = 15, Negociable = true, Prime = false, Company = "Psg", Wallet = "Sport" });
            contracts.Add(new ContractModel() { Start = DateTime.Now, End = DateTime.Now, Couverture = 15, Negociable = true, Prime = false, Company = "France", Wallet = "Defense" });

        }
    }
}