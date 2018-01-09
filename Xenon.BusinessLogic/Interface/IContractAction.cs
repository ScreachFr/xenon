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
        List<Contract> GetContractByWalletId(Guid walletId);
        bool AddContract(Contract c);
        bool EditContract(Guid contractId, Contract c);
        Contract GetContractById(Guid id);

    }
}
