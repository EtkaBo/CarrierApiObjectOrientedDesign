using ClassLibrary;
using ClassLibrary.BLL;
using ClassLibrary.ImplementationsOfCarriers;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingApiConsole
{
    class Program
    {

        static void Main(string[] args)
        {

            IRatingManagerBLL bll = new RatingManagerBLL();

            var rates = bll.GetRatesFromActiveApis(new CarrierRatesRequest
            {
                fromAddress = "1 N Indian Hill Rd",
                fromCity = "Winnetka",
                toStreet = "8520 Fernald Ave",
                toCity = "Morton Grove"
            });

            Console.WriteLine();
        }
    }
}
