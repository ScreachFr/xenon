using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenon.Interface;
using Xenon.Models;

namespace Xenon.BusinessLogic.Controllers
{
  public class ContractAction : IContractAction
  {
    public bool AddContract(ContractModel c)
    {
      throw new NotImplementedException();
    }

    private void AddContractToDB(ContractModel c)
    {

    }

    public bool EditContract(Guid contractId, ContractModel c)
    {
      throw new NotImplementedException();
    }

    public ContractModel GetContractById(Guid id)
    {
      throw new NotImplementedException();
    }

    public List<ContractModel> GetContractByWalletId(Guid walletId)
    {
      throw new NotImplementedException();
    }
  }
}
