using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xenon.Models
{
    public class ScopeModel
    {
        public Guid User { get; set; }
        public Guid Wallet { get; set; }
    }
}