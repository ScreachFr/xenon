using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xenon.BusinessLogic.Models
{
  public class User
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public String Username { get; set; }
    public String Password { get; set; }
    public string Status { get; set; }
    public string Mail { get; set; }
    public Guid GeographicZone { get; set; }
  }
}
