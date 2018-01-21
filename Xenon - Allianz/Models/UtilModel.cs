using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

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
        public string State { get; set; } = "In progress";
        public HttpPostedFileBase File { get; set; }
    }


    public class PaginationModel
    {
        public Guid WalletId { get; set; }
        public int Page { get; set; }
        public int NumberOfElementsByPage { get; set; }
        public string SortResult { get; set; }
    }

    public class ContractListModel
    {
        public int NumberOfContractInWallet { get; set; }
        public List<ContractModel> ContractList { get; set; }
        public string WalletName { get; set; }
        public string Scope { get; set; }
    }




}