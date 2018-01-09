using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xenon.BusinessLogic.Models
{
  public class GeographicScope
  {
    [Key]
    public Guid Id { get; set; }

    public Guid Zone { get; set; }

    public Guid Contract { get; set; }
  }
}
