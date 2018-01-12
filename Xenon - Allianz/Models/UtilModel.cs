using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xenon___Allianz.Models
{
    public class UtilModel
    {

    }
    public class HomePageModel
    {
        //public List<UserModel> users { get; set; }
        public List<WalletModel> Wallets { get; set; }
        public List<ContractModel> Contracts { get; set; }
    }

    public class UpdateStatusModel
    {
        public Guid UserId { get; set; }
        public string NewStatus { get; set; }
    }




}