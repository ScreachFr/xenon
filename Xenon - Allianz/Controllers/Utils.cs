using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xenon___Allianz.Models;
using Xenon.BusinessLogic.Models;
using Xenon___Allianz.DataAccess;

namespace Xenon___Allianz.Controllers
{
    public class Utils
    {
        public static List<GeographicZoneModel> ToGeographicZoneModel(List<GeographicZone> l)
        {
            List<GeographicZoneModel> gzm = new List<GeographicZoneModel>();
            foreach (var item in l)
            {
                GeographicZone gz = DataAccessAction.geographicZone.GetGeographicZoneById(item.Father);
                gzm.Add(new GeographicZoneModel
                {
                    Id = item.Id,
                    Father = item.Father,
                    Name = item.Name,
                    FatherName = (gz!=null)?gz.Name:"",
                });
            }
            return gzm;
        }
        public static List<ContractModel> ToContractModel(List<Contract> l)
        {
            List<ContractModel> cm = new List<ContractModel>();
            foreach (var item in l)
            {
                Guid geoid = DataAccessAction.geographicZone.GetGeographicZoneByContractId(item.Id);
                cm.Add(new ContractModel
                {
                    Id = item.Id,
                    Start = item.Start.ToString(),
                    End = item.End.ToString(),
                    Cover = item.Cover,
                    Negociable = item.Negociable,
                    Prime = item.Prime,
                    Rompu = item.Rompu,
                    Company = item.Company,
                    Wallet = item.Wallet,
                    WalletName = DataAccessAction.wallet.GetWalletById(item.Wallet).Service,
                    Value = item.Value,
                    GeographicZoneId = geoid,
                    GeographicZoneName = DataAccessAction.geographicZone.GetGeographicZoneById(geoid).Name,
                    Position = 1,
                });
            }
            return cm;
        }

        public static string GeneratePassword()
        {
            return "pass";
        }
        public static string GenerateMail(string username)
        {
            return username + "@xenonallianz.com";
        }
        public static Guid RandomGeographicZone()
        {
            Random r = new Random();
            var x = DataAccessAction.geographicZone.GetAllAvailableGeographicZones();
            int i = r.Next(0, x.Count);
            return x[i].Id;
        }
    }
}