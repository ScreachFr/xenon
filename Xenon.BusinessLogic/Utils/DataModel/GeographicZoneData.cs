using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xenon.BusinessLogic.Utils.DataModel
{
  public class GeographicZoneData
  {
    public String Name { get; set; }
    public List<GeographicZoneData> Childs { get; set; }
  }
}
