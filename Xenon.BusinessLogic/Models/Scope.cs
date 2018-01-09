using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Xenon.BusinessLogic.Models;

namespace Xenon.BusinessLogic.Models
{
    public class Scope
    {

        [Key]
        public Guid Id { get; set; }
        public Guid User { get; set; }
        public Guid Wallet { get; set; }

        public Scope(Guid user, Guid wallet)
        {
            this.User = user;
            this.Wallet = wallet;
        }

    }
}