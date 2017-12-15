using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xenon.BusinessLogic.Models
{
  public class DataContextModel : DbContext
  {
        public DataContextModel()
        {
        }

        public DbSet<User> Users { get; private set; }


  }
}
