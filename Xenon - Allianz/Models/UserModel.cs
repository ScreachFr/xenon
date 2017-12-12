using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xenon___Allianz.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Type { get; set; } = "";
        public string Mail { get; set; } = "";
    }
}