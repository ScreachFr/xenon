using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenon.Models;

namespace Xenon.Interface
{
    public interface IContractAction
    {
        List<ContractModel> GetContractByWalletId(Guid walletId);
        bool AddContract(ContractModel c);
        bool EditContract(Guid contractId, ContractModel c);
        ContractModel GetContractById(Guid id);

    }
}
