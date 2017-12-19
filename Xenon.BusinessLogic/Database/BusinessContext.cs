using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xenon.BusinessLogic.Models
{
  class BusinessContext : DbContext
  {
    public BusinessContext() : base(){} 

    public DbSet<User> Users { get; set; }



  }
}
