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

    public class StatusToValid
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string OldStatus { get; set; }
        public string NewStatus { get; set; }
        public bool InProgress { get; set; }
        public string Path { get; set; }
        public DateTime SubmitTimeStamp { get; set; }
        public DateTime AnswerTimeStamp { get; set; }
    }

    public class RegisterUserModel
    {
        public List<GeographicZoneModel> GeographicZoneList { get; set; }
        public List<String> StatusList { get; set; } = new List<string>()
        {
            "souscripteur",
            "collaborateur",
            "manager",
            "admin",
            "actuaire",
        };
    }




}