using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xenon.BusinessLogic.Exceptions
{
  class DBFieldDuplicationException : Exception
  {
    public DBFieldDuplicationException(String message) : base(message)
    {}

  }

}
