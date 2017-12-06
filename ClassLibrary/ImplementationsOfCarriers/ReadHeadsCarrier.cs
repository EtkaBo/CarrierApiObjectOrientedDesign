using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public abstract class ReadHeadsCarrier
    {
        public abstract RedHeadsAddress CreateAddress(string street, string city);
        public abstract RedHeadsShipment CreateShipment(RedHeadsAddress from, RedHeadsAddress to);
        public abstract List<RedHeadsRate> GetRates(RedHeadsShipment Shipment);

        // use common code from implementations
        public virtual RedHeadsRate GetLowest(List<RedHeadsRate> rates)
        {
            return rates.OrderBy(d => d.Amount).FirstOrDefault();
        }
        public abstract void BuyRate(RedHeadsRate rate);
    }

    public class RedHeadsAddress
    {
        public string Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
    }

    public class RedHeadsShipment
    {
        public string Id { get; set; }
        public RedHeadsAddress From { get; set; }
        public RedHeadsAddress To { get; set; }
    }

    public class RedHeadsRate
    {
        public string Id { get; set; }
        public string Service { get; set; }
        public double Amount { get; set; }
    }

}
