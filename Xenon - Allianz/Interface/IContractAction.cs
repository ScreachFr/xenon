using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenon___Allianz.Models;

namespace Xenon___Allianz.Interface
{
    public interface IContractAction
    {
        List<ContractModel> GetContractByWalletId(int walletId);
        bool AddContract(ContractModel c);
        bool EditContract(int contractId, ContractModel c);
        ContractModel GetContractById(int id);

    }
}
