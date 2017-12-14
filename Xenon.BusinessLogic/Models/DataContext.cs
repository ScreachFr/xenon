using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xenon.BusinessLogic.Models
{
  class DataContext : DbContext
  {
    public DbSet<User> Users { get; private set; }


  }
}
