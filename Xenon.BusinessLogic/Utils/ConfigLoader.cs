using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xenon.BusinessLogic.Utils
{
  public class ConfigLoader
  {
    private static String CONFIG_PATH = AppDomain.CurrentDomain.BaseDirectory + @"\config.json";
    private static Dictionary<String, String> Vars { get; set; }



    public static String GetValue(String key)
    {
      if (Vars == null)
        Vars = LoadConfigFile();

      return Vars[key];
    }

    public static Dictionary<String, String> LoadConfigFile()
    {
      var result = new Dictionary<String, String>();

      Console.WriteLine("Loading " + CONFIG_PATH + ".");

      using (StreamReader r = new StreamReader(CONFIG_PATH))
      {
        string json = r.ReadToEnd();
        var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        result = values;
      }


      return result;
    }

   
  }

}
