using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Xenon.BusinessLogic.Models;
using Xenon.BusinessLogic.Interface;

namespace Xenon.BusinessLogic.Controllers
{
    public class ContractAction : IContractAction
    {
        public bool AddContract(Contract c)
        {
            try
            {
                AddContractToDB(c);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }

        }

        private void AddContractToDB(Contract c)
        {

            using (var ctx = new BusinessContext())
            {
                ctx.Contracts.Add(c);
                ctx.SaveChanges();
            }
        }

        public bool EditContract(Guid contractId, Contract c)
        {
            using (var ctx = new BusinessContext())
            {
                var query = from contract in ctx.Contracts
                            where contract.Id.Equals(contractId)
                            select contract;

                var toModify = query.FirstOrDefault();

                if (toModify == null)
                    return false;
                else
                {
                    toModify.Update(c);
                    ctx.Entry(toModify).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                    return true;
                }
            }
            throw new NotImplementedException();
        }

        public Contract GetContractById(Guid id)
        {
            using (var ctx = new BusinessContext())
            {
                var query = from c in ctx.Contracts.Include(e => e.GeographicZones)
                            where c.Id.Equals(id)
                            select c;

                return query.FirstOrDefault();
            }
        }

        public List<Contract> GetContractByWalletId(Guid walletId, Guid geoid)
        {
            using (var ctx = new BusinessContext())
            {
                System.Linq.Expressions.Expression<Func<Guid, Guid, bool>> Test = (p1, p2) => p1.Equals(p2);
                
                //var query = from c in ctx.Contracts
                //            join g in ctx.GeograpicScopes on c.Id equals g.Contract
                //            where Test(geoid, g.Zone)
                //            //where g.Zone.Equals(geoid) & c.Wallet.Equals(walletId)
                //            //where IsWithinScope(geoid, g.Zone)
                //            select c;

                var query = ctx.Contracts.Include("GeographicZones").Where(c =>c.Wallet.Equals(walletId) && c.GeographicZones.Select(e => e.Id).Contains(geoid) ).ToList();

                

                return query;
            
            }
        }

        



        /* TO DELETE */
        public List<Contract> GetContractByWalletId(Guid walletId, int page, int numberByPage)
        {
            using (var ctx = new BusinessContext())
            {
                var query = from c in ctx.Contracts
                            where c.Wallet.Equals(walletId)
                            && c.Position <= (page * numberByPage) && c.Position > ((page * numberByPage) - numberByPage)
                            select c;

                var result = new List<Contract>();
                foreach (var item in query)
                {
                    result.Add(item);
                }

                return result;
            }
        }

        public List<Contract> GetAllContract()
        {
            using (var ctx = new BusinessContext())
            {
                var query = from c in ctx.Contracts
                            select c;

                var result = new List<Contract>();
                foreach (var item in query)
                {
                    result.Add(item);
                }

                return result;
            }

        }

        private bool IsWithinScope(Guid father, Guid supposedChild)
        {
            if (father == null)
                return false;

            if (father.Equals(supposedChild))
                return true;

            using (var ctx = new BusinessContext())
            {
                var query = from z in ctx.GeographicZones
                            where z.Id.Equals(supposedChild)
                            select z;
                var count = query.Count();

                if (count > 0)
                {
                    var res = query.First();
                    if (res.Father.Equals(father))
                        return true;
                    else
                        return IsWithinScope(father, res.Father);


                }
                else
                    return false;

            }
        }

        public void AddGeoZoneToContract(Guid contractId, Guid zoneId)
        {
            using(var ctx = new BusinessContext())
            {
                var query = from c in ctx.Contracts
                            where c.Id.Equals(contractId)
                            select c;
                Contract contrat = query.First();
                var geo = ctx.GeographicZones.Where(e => e.Id.Equals(zoneId)).First();
                
                var x = ctx.GeographicZones.ToList().Where(g => IsWithinScope(zoneId, g.Id));
                if(contrat.GeographicZones == null)
                {
                    contrat.GeographicZones = new List<GeographicZone>();
                }
                foreach (var item in x)
                {
                    contrat.GeographicZones.Add(item);
                    //ctx.GeograpicScopes.Add(new GeographicScope() { Contract = contractId, Zone = item.Id });
                }
                contrat.GeographicZones.Add(geo);
                ctx.Entry(contrat).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}
