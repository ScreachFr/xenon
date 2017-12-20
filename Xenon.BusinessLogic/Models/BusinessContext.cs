using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenon.BusinessLogic.Utils;

namespace Xenon.BusinessLogic.Models
{
  public class BusinessContext : DbContext
  {
    // TODO really ugly way to do this.
    public BusinessContext() : base(ConfigLoader.GetValue("db-connection"))
    {

    }

    public DbSet<User> Users { get; set; }

  }
}
