using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Xenon.BusinessLogic.Models;

namespace Xenon.Models
{
  public class Scope
  {
    [Key]
    public Guid User { get; set; }
    [Key]
    public Guid Wallet { get; set; }

    public Scope(Guid user, Guid wallet)
    {
      this.User = user;
      this.Wallet = wallet;
    }

  }
}