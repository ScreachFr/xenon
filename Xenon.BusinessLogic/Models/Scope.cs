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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid User { get; set; }
        public Guid Wallet { get; set; }
        public Boolean Initial { get; set; }

        public Scope(Guid user, Guid wallet, bool intial)
        {
            this.User = user;
            this.Wallet = wallet;
            this.Initial = intial;
        }

    }
}