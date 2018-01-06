using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xenon___Allianz.Bouchon;
using Xenon.Interface;

namespace Xenon___Allianz.DataAccess
{
    public static class DataAccessAction
    {
        public static IUserAction user = new UserPlug();
        public static IWalletAction wallet = new WalletPlug();
        public static IContractAction contract = new ContractPlug();
    }       
}