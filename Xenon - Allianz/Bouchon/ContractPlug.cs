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
            Database.contracts.Add(c);
            return true;
        }

        public bool EditContract(int contractId, ContractModel c)
        {
            throw new NotImplementedException();
        }

        public ContractModel GetContractById(int id)
        {
            return Database.contracts.Where(e => e.Id == id).FirstOrDefault();
        }

        public List<ContractModel> GetContractByWalletId(int walletId)
        {
            List<ContractModel> lc = new List<ContractModel>();
            foreach (var item in Database.contracts)
            {
                if (item.Wallet == walletId)
                {
                    
                    lc.Add(item);
                }
            }

            return lc;
        }
    }
}