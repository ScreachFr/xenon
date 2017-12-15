using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xenon.BusinessLogic.Models
{
  class Repository<T> : IRepository<T> where T:class
  {
    protected DataContextModel Ctx { get; private set; }
    public DbSet<T> DataSet { get; private set; }

    public Repository(DataContextModel ctx, DbSet<T> dataSet)
    {
      this.Ctx = ctx;
      this.DataSet = dataSet;
    }




    public void Insert(T element) => DataSet.Add(element);

    public bool Remove(T element) => (DataSet.Remove(element) == null) ? false: true;

    public void SaveChanges() => Ctx.SaveChanges();

    // TODO something is missing.
    public bool Update(T element) => (DataSet.Attach(element) == null) ? false: true;
  }
}
