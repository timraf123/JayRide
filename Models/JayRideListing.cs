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

        public void PrintJayRideListing()
        {
            Console.Write(this.from);
            Console.Write(this.to);


            foreach (var j in listings)
            {
                Console.Write(j.pricePerPassenger);
                Console.Write(j.name);
                Console.Write(j.vehicleType);

            }
        }


        /// <summary>
        ///  filter out listings that don’t support the number of passengers. With the remaining listings, calculate the total price and return the results sorted by total price.
        ///  ttoal price is price per passenger * numPassengers
        /// </summary>
        /// <returns></returns>
        public double CalcTotalPrice(int numPassengers)
        {
            Console.Write(this.from);
            Console.Write(this.to);

            int passengers = 3;
            double totalPrice = 0;
            List<Listing> listingsResult = new List<Listing>();  
            // filter car type has max passengers
            foreach (var j in listings)
            {
                if (j.vehicleType.maxPassengers >= passengers)
                {
                    j.totalPrice = numPassengers * j.pricePerPassenger;
                    listingsResult.Add(j);
                }
            }
 
            listingsResult = (List<Listing>)listingsResult.OrderBy(x => x.totalPrice).ToList();
 
            return totalPrice;
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
            //this.name = "Listing";
            //this.pricePerPassenger = 23.1;
            //this.vehicleType = new VehicleType("Sedan", 3);
        }
    }
}