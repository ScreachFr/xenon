using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xenon___Allianz.Bouchon;
using Xenon.Interface;
using Xenon.BusinessLogic.Controllers;

namespace Xenon___Allianz.DataAccess
{
    public static class DataAccessAction
    {
        public static IUserAction user = new UserAction();
        public static IWalletAction wallet = new WalletAction();
        public static IContractAction contract = new ContractAction();
    }       
}