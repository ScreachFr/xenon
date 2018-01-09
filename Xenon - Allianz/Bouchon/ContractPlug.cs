using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xenon.Interface;
using Xenon.Models;

namespace Xenon___Allianz.Bouchon
{
    public class ContractPlug : IContractAction
    {
        public bool AddContract(ContractModel c)
        {
            Database.contracts.Add(c);
            return true;
        }

        public bool EditContract(Guid contractId, ContractModel c)
        {
            throw new NotImplementedException();
        }

        public ContractModel GetContractById(Guid id)
        {
            return Database.contracts.Where(e => e.Id.Equals(id)).FirstOrDefault();
        }

        public List<ContractModel> GetContractByWalletId(Guid walletId)
        {
            List<ContractModel> lc = new List<ContractModel>();
            foreach (var item in Database.contracts)
            {
                if (item.Wallet.Equals(walletId))
                {
                    
                    lc.Add(item);
                }
            }

            return lc;
        }
    }
}