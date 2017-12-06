using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class CarrierRatesRequest
    {
        public string fromAddress { get; set; }
        public string fromCity { get; set; }
        public string toStreet { get; set; }
        public string toCity { get; set; }
    }
}
