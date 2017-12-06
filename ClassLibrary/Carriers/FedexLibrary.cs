using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    // we don't own these libraries
    public class FedexLibrary
    {
        public FedexAddress CreateAddress(string street, string city)
        {
            return new FedexAddress
            {
                Street = street,
                City = city
            };
        }

        public FedexShipment CreateShipment(FedexAddress from, FedexAddress to)
        {
            return new FedexShipment
            {
                From = from,
                To = to
            };
        }

        public List<FedexRate> GetRates(FedexShipment Shipment)
        {
            return new List<FedexRate>
            {
                new FedexRate
                {
                    Service= "Overnight",
                    Amount = 43.00
                },
                new FedexRate
                {
                    Service = "2 Day Shippin'",
                    Amount = 14.00
                },
                new FedexRate
                {
                    Service = "Normal",
                    Amount = 3.00
                }
            };

        }

        public void BuyRate(FedexRate rate) {
            // fedex actually calls their apis to buy that rate to create a tracking number
        }
    }

    public class FedexAddress
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Street { get; set; }
        public string City { get; set; }
    }

    public class FedexShipment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public FedexAddress From { get; set; }
        public FedexAddress To { get; set; }
    }

    public class FedexRate
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Service { get; set; }
        public double Amount { get; set; }
    }
}
