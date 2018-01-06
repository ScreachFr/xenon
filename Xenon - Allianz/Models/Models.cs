using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Xenon.BusinessLogic.Models;
using Xenon.Models;

namespace Xenon___Allianz.Models
{


  public class Database
  {
    public static List<User> users;
    public static List<WalletModel> wallets;
    public static List<ContractModel> contracts;
    public static List<ScopeModel> scopes;


    public Database()
    {
      users = new List<User>();
      wallets = new List<WalletModel>();
      contracts = new List<ContractModel>();
      scopes = new List<ScopeModel>();

      users.Add(new User() { Id = new Guid(), Username = "souscripteur", Password = "pass", Status = "souscripteur", Mail = "souscripteur@xenon.com" });
      users.Add(new User() { Id = new Guid(), Username = "manager", Password = "pass", Status = "manager", Mail = "manager@xenon.com" });
      users.Add(new User() { Id = new Guid(), Username = "collaborateur", Password = "pass", Status = "collaborateur", Mail = "collaborateur@xenon.com" });
      //users.Add(new User() { Id = new Guid(), Username = "actuaire", Password = "pass", Status = "actuaire", Mail = "actuaire@xenon.com" });
      users.Add(new User() { Id = new Guid(), Username = "admin", Password = "pass", Status = "admin", Mail = "admin@xenon.com" });

      wallets.Add(new WalletModel() { Id = new Guid(), Service = "Health" });
      wallets.Add(new WalletModel() { Id = new Guid(), Service = "Defense" });
      wallets.Add(new WalletModel() { Id = new Guid(), Service = "Agroalimentaire" });
      wallets.Add(new WalletModel() { Id = new Guid(), Service = "Electricité - Electronique" });
      wallets.Add(new WalletModel() { Id = new Guid(), Service = "Machine et equipements" });
      wallets.Add(new WalletModel() { Id = new Guid(), Service = "Plastique" });
      wallets.Add(new WalletModel() { Id = new Guid(), Service = "Transport" });

      scopes.Add(new ScopeModel() { User = users[0].Id, Wallet = wallets[0].Id });
      scopes.Add(new ScopeModel() { User = users[0].Id, Wallet = wallets[1].Id });
      scopes.Add(new ScopeModel() { User = users[0].Id, Wallet = wallets[2].Id });
      scopes.Add(new ScopeModel() { User = users[1].Id, Wallet = wallets[0].Id });
      scopes.Add(new ScopeModel() { User = users[1].Id, Wallet = wallets[1].Id });

      contracts.Add(new ContractModel() { Id = new Guid(), Start = DateTime.Now.ToString().Split(' ')[0], End = DateTime.Now.ToString().Split(' ')[0], Cover = 15, Negociable = true, Prime = 15, Company = "Renault", Wallet = wallets[0].Id });
      contracts.Add(new ContractModel() { Id = new Guid(), Start = DateTime.Now.ToString().Split(' ')[0], End = DateTime.Now.ToString().Split(' ')[0], Cover = 15, Negociable = true, Company = "CardiWeb", Wallet = wallets[0].Id });
      contracts.Add(new ContractModel() { Id = new Guid(), Start = DateTime.Now.ToString().Split(' ')[0], End = DateTime.Now.ToString().Split(' ')[0], Cover = 15, Negociable = true, Company = "Avanade", Wallet = wallets[1].Id });
      contracts.Add(new ContractModel() { Id = new Guid(), Start = DateTime.Now.ToString().Split(' ')[0], End = DateTime.Now.ToString().Split(' ')[0], Cover = 15, Negociable = true, Company = "Levalois Metropolitans", Wallet = wallets[1].Id });
      contracts.Add(new ContractModel() { Id = new Guid(), Start = DateTime.Now.ToString().Split(' ')[0], End = DateTime.Now.ToString().Split(' ')[0], Cover = 15, Negociable = true, Company = "Psg", Wallet = wallets[2].Id });
      contracts.Add(new ContractModel() { Id = new Guid(), Start = DateTime.Now.ToString().Split(' ')[0], End = DateTime.Now.ToString().Split(' ')[0], Cover = 15, Negociable = true, Prime = 15, Company = "France", Wallet = wallets[2].Id });

    }
  }
}