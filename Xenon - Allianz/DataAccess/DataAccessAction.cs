using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xenon.BusinessLogic.Interface;
using Xenon.BusinessLogic.Controllers;

namespace Xenon___Allianz.DataAccess
{
    public static class DataAccessAction
    {
        public static IUserAction user = new UserAction();
        public static IWalletAction wallet = new WalletAction();
        public static IContractAction contract = new ContractAction();
        public static IGeographicZoneAction geographicZone = new GeographicZoneAction();
        public static IAdminAction admin = new AdminAction();
    }       
}