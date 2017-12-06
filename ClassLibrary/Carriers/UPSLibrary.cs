using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class UPSLibrary
    {

        public UPSAddress CreateAddress(string street, string city)
        {

            return new UPSAddress
            {
                Street = street,
                City = city
            };
        }

        public UPSShipment CreateShipment(UPSAddress from, UPSAddress to)
        {
            return new UPSShipment { From = from, To = to };

        }

        public List<UPSRate> GetRates(UPSShipment Shipment)
        {
            return new List<UPSRate>
            {
                new UPSRate()
                { Service = "Ground", Amount = 3.00 },
                new UPSRate()
                {
                    Service = "2dayShipment", Amount = 13.32
                },
                new UPSRate()
                {
                    Service = "Overnight",
                    Amount = 33.55
                }

            };
        }

        public void BuyRate(UPSRate rate)
        {
            // ups buys the rate
        }
    }

    public class UPSRate
    {
        public int Id { get; set; } = new Random().Next(1000);
        public string Service { get; set; }

        public double Amount { get; set; }

    }

    public class UPSShipment
    {
        public int Id { get; set; } = new Random().Next(1000);
        public UPSAddress From { get; set; }
        public UPSAddress To { get; set; }
    }

    public class UPSAddress
    {
        public int Id { get; set; } = new Random().Next(1000);
        public string Street { get; set; }
        public string City { get; set; }
    }
}
