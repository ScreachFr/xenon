using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xenon___Allianz.Interface;
using Xenon___Allianz.Models;

namespace Xenon___Allianz.Bouchon
{
    public class ContractPlug : IContractAction
    {
        public bool AddContract(ContractModel c)
        {
            throw new NotImplementedException();
        }

        public bool EditContract(int contractId, ContractModel c)
        {
            throw new NotImplementedException();
        }

        public List<ContractModel> GetContractByWalletId(string walletId)
        {
            List<ContractModel> lc = new List<ContractModel>();
            foreach (var item in Database.contracts)
            {
                if (item.Wallet.Equals(walletId))
                    lc.Add(item);
            }

            return lc;
        }
    }
}