using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Xenon___Allianz.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string Mail { get; set; }
        public Guid GeographicZone { get; set; }
        public string GeographicZoneName { get; set; }

    }

    public class WalletModel
    {
        public Guid Id { get; set;  }
        public string Service { get; set; }
        public int numberOfContract { get; set; }
    }

    public class ContractModel
    {
        public Guid Id { get; set; }
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public String Start { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public String End { get; set; }
        [Range(0.01, 100.00, ErrorMessage = "Cover must be between 0.01 and 100.00")]
        public double Cover { get; set; }
        public bool Negociable { get; set; } = false;
        public int Prime { get; set; } = 0;
        public bool Rompu { get; set; } = false;
        public string Company { get; set; }
        public Guid Wallet { get; set; }
        public string WalletName { get; set; }
        public int Value { get; set; }
        public int Position { get; set; }
    }
    public class GeographicZoneModel
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public Guid Father { get; set; }
    }
    public class RegisterModel
    {
        public UserModel User { get; set; }
        public List<GeographicZoneModel> AllZones { get; set; }
    }
}