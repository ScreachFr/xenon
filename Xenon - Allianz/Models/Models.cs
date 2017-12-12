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
        public int Type { get; set; } = 4;
        public string Mail { get; set; }
    }

    public class WalletModel
    {
        public int Id { get; set; }
        public string Service { get; set; }
    }

    public class ContractModel
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        [Range(0.01, 100.00, ErrorMessage = "Cover must be between 0.01 and 100.00")]
        public double Cover { get; set; }
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
            /*
            users.Add(new UserModels() { Username = "mohamed", Password = "pass" });
            users.Add(new UserModels() { Username = "admin", Password = "pass" });

            wallets.Add(new WalletModel() { Service = "Health" });
            wallets.Add(new WalletModel() { Service = "Defense" });
            wallets.Add(new WalletModel() { Service = "Sport" });

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