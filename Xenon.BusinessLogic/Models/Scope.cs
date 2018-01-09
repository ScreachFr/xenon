using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Xenon.Models
{
  public class ScopeModel
  {
    [Key]
    public Guid User { get; set; }
    [Key]
    public Guid Wallet { get; set; }
  }
}