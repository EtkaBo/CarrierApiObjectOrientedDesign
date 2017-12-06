using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.ImplementationsOfCarriers
{
    public class RedHeadsUPS : ReadHeadsCarrier
    {
        public UPSLibrary _upsLib { get; set; }
        public RedHeadsUPS()
        {
            _upsLib = new UPSLibrary();
        }

        public override RedHeadsAddress CreateAddress(string street, string city)
        {
            UPSAddress upsAddress = _upsLib.CreateAddress(street, city);

            return mapUPSAddressToRH(upsAddress);
        }

        public override RedHeadsShipment CreateShipment(RedHeadsAddress from, RedHeadsAddress to)
        {
            UPSShipment upsShipment = _upsLib.CreateShipment(mapRHAddresstoUPS(from), mapRHAddresstoUPS(to));

            return mapUPSShipmentToRH(upsShipment);

        }

        public override List<RedHeadsRate> GetRates(RedHeadsShipment Shipment)
        {
            var rhrate = mapRHShimentToUPS(Shipment);

            var rhsipment = _upsLib.GetRates(rhrate);

            return rhsipment.Select(mapUPSRatetoRHRate).ToList();
        }
        public override void BuyRate(RedHeadsRate rate)
        {
        }


        #region mappers

        private static Func<RedHeadsAddress, UPSAddress> mapRHAddresstoUPS = x => new UPSAddress
        {
            City = x.City,
            Street = x.Street
        };

        private static Func<UPSAddress, RedHeadsAddress> mapUPSAddressToRH = x => new RedHeadsAddress
        {
            Id = x.Id.ToString(),
            City = x.City,
            Street = x.Street
        };

        private static Func<UPSShipment, RedHeadsShipment> mapUPSShipmentToRH = x => new RedHeadsShipment
        {
            Id = x.Id.ToString(),
            From = mapUPSAddressToRH(x.From),
            To = mapUPSAddressToRH(x.To)
        };

        private static Func<RedHeadsShipment, UPSShipment> mapRHShimentToUPS = x => new UPSShipment
        {
            From = mapRHAddresstoUPS(x.From),
            To = mapRHAddresstoUPS(x.To)
        };

        private static Func<RedHeadsRate, UPSRate> mapRHRateToUPSRate = x => new UPSRate
        {
            Amount = x.Amount,
            Service = x.Service
        };

        private static Func<UPSRate, RedHeadsRate> mapUPSRatetoRHRate = x => new RedHeadsRate
        {
            Id = x.Id.ToString(),
            Amount = x.Amount,
            Service = x.Service
        };

        #endregion
    }
}
