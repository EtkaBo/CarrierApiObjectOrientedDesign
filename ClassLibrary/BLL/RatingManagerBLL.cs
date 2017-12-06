using ClassLibrary.ImplementationsOfCarriers;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.BLL
{
    public interface IRatingManagerBLL
    {
        List<RedHeadsRate> GetRatesFromActiveApis(CarrierRatesRequest request);
    }

    public class RatingManagerBLL : IRatingManagerBLL
    {
        List<ReadHeadsCarrier> activeCarriers = new List<ReadHeadsCarrier>
            {
                new RedHeadsFedex(), new RedHeadsUPS(), // new carrier api
            };


        public List<RedHeadsRate> GetRatesFromActiveApis(CarrierRatesRequest request)
        {
            List<RedHeadsRate> allRates = new List<RedHeadsRate>();
            foreach (var carrier in activeCarriers)
            {
                var from = carrier.CreateAddress("1 N Indian Hill Rd", "Winnetka");
                var to = carrier.CreateAddress("8520 Fernald Ave", "Morton Grove");

                var shipment = carrier.CreateShipment(from, to);
                var rates = carrier.GetRates(shipment);
                allRates.AddRange(rates);

                Console.WriteLine();

                Console.ReadLine();
            }
            return allRates;
        }
    }
}
