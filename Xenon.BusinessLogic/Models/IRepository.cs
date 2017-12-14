using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xenon.BusinessLogic.Models
{
  interface IRepository<T>
  {
    void Insert(T element);
    bool Remove(T element);

    bool Update(T element);
    void SaveChanges();

  }
}
