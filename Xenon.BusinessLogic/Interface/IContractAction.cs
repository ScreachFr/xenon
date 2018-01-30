using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenon.BusinessLogic.Models;

namespace Xenon.BusinessLogic.Interface
{
    public interface IContractAction
    {
        List<Contract> GetContractByWalletId(Guid walletId, Guid geoId);
        List<GeographicZone> GetGeographicZoneByContractId(Guid contractId); 
        //List<Contract> GetContractByWalletId(Guid walletId, int page, int numberByPage);
        bool AddContract(Contract c, List<Guid> geoIdZone);
        bool EditContract(Guid contractId, Contract c);
        Contract GetContractById(Guid id);
        List<Contract> GetAllContract();
        void AddGeoZoneToContract(Guid contractId, Guid zoneId);
           

    }
}
