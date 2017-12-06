using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.ImplementationsOfCarriers
{
    public class RedHeadsFedex : ReadHeadsCarrier
    {
        public FedexLibrary _fedexLib { get; set; }

        public RedHeadsFedex()
        {
            _fedexLib = new FedexLibrary();
        }
        public override RedHeadsAddress CreateAddress(string street, string city)
        {
            FedexAddress fedexAddress = _fedexLib.CreateAddress(street, city);
            return mapFedexAddressToRH(fedexAddress);
        }

        public override RedHeadsShipment CreateShipment(RedHeadsAddress from, RedHeadsAddress to)
        {
            // these are mappings
            var fFrom = mapRhAddressToFedex(from);
            var fTo = mapRhAddressToFedex(to);

            // logic is here
            var fShipment = _fedexLib.CreateShipment(fFrom, fTo);

            // map back to RH model
            return mapFedexShipmentToRH(fShipment);
        }

        public override List<RedHeadsRate> GetRates(RedHeadsShipment shipment)
        {
            // map to fedex to use api
            var fedexShipment = mapRHShipmentToFedex(shipment);

            // call api with 
            var fRates = _fedexLib.GetRates(fedexShipment);

            // map fedex rates to RH 
            return fRates.Select(mapFedexRatesToRH).ToList();
        }

        public override void BuyRate(RedHeadsRate rate)
        {
            var fRate = mapRHRatesToFedex(rate);

            _fedexLib.BuyRate(fRate);
        }

        #region Mappers
        public static Func<FedexAddress, RedHeadsAddress> mapFedexAddressToRH = x =>
          new RedHeadsAddress
          {
              Id = x.Id.ToString(),
              Street = x.Street,
              City = x.City
          };

        public static Func<RedHeadsAddress, FedexAddress> mapRhAddressToFedex = x =>
          new FedexAddress
          {
              Id = Guid.Parse(x.Id),
              Street = x.Street,
              City = x.City
          };

        public static Func<FedexShipment, RedHeadsShipment> mapFedexShipmentToRH = x =>
          new RedHeadsShipment
          {
              Id = x.Id.ToString(),
              From = mapFedexAddressToRH(x.From),
              To = mapFedexAddressToRH(x.To)
          };

        public static Func<RedHeadsShipment, FedexShipment> mapRHShipmentToFedex = x =>
            new FedexShipment
            {
                Id = Guid.Parse(x.Id),
                From = mapRhAddressToFedex(x.From),
                To = mapRhAddressToFedex(x.To)
            };

        public static Func<FedexRate, RedHeadsRate> mapFedexRatesToRH = x =>
          new RedHeadsRate
          {
              Id = x.Id.ToString(),
              Amount = x.Amount,
              Service = x.Service
          };

        public static Func<RedHeadsRate, FedexRate> mapRHRatesToFedex = x =>
         new FedexRate
         {
             Id = Guid.Parse(x.Id),
             Amount = x.Amount,
             Service = x.Service
         };

        #endregion

    }
}
