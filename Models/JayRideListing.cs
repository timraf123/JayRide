using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class JayRideListing
    {
        public string from { get; set; }

        public string to { get; set; }
        public List<Listing> listings { get; set; }
       
    public JayRideListing()
        { 
        
        }


        /// <summary>
        ///  filter out listings that don’t support the number of passengers. With the remaining listings, calculate the total price and return the results sorted by total price.
        ///  ttoal price is price per passenger * numPassengers
        /// </summary>
        /// <returns></returns>
        public List<Listing> CalcTotalPrices(int numPassengers, ref double lowestPrice)
        {
            Console.Write(this.from);
            Console.Write(this.to);
            List<Listing> listingsResult = new List<Listing>();  
 
            foreach (var j in listings)
            {
                if (j.vehicleType.maxPassengers >= numPassengers)
                {
                    j.totalPrice = numPassengers * j.pricePerPassenger;
                    listingsResult.Add(j);
                }
            }
 
            listingsResult = (List<Listing>)listingsResult.OrderBy(x => x.totalPrice).ToList();
            lowestPrice = listingsResult[0].totalPrice; ;

            return listingsResult;
        }


    }

        public class Listing
    {
        public string name { get; set; }
        public double  pricePerPassenger { get; set; }
        public double totalPrice { get; set; }
        public VehicleType vehicleType { get; set; }

        public Listing(string v, double p , VehicleType vt)
        {
            this.name = v;
            this.pricePerPassenger = p;
           this.vehicleType = vt;
            this.totalPrice = 0;
        }

        public class VehicleType
        {

            public string name;
            public int maxPassengers;


            public VehicleType(string v, int p)
            {
                this.name   = v;
                this.maxPassengers = p;
            }
        }
        public Listing()
        {

        }
    }
}