using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Xenon___Allianz.Utils
{
    public class Utils
    {
        public static int NumberOfPages(int numberOfElements, int numberOfElementByPage)
        {
            int n = numberOfElements/numberOfElementByPage;
            return ((numberOfElements % numberOfElementByPage) == 0) ?  n : n+1;
        }
    }
}