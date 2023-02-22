using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
namespace WebApplication6.Models
{
    public class JayRideModel  
    {
        private JayRideDataModel jayRideDataModel;


        private string name;
         public string Name   // property
        {
            get { return name; }   // get method
            set { name = value; }  // set method
        }
        private string phone;
        public string Phone   // property
        {
            get { return phone; }   // get method
            set { phone = value; }  // set method
        }

        private string ipAddress;

        public string IpAddress   // property
        {
            get { return ipAddress; }   // get method
            set { ipAddress = value; }  // set method
        }

        private string location;

        public string Location   // property
        {
            get { return location; }   // get method
            set { location = value; }  // set method
        }


        private int numPassengers;

        public int NumPassengers   // property
        {
            get { return numPassengers; }   // get method
            set { numPassengers = value; }  // set method
        }

        private List<Listing> listingsResult;
        public  List<Listing> ListingsResult
        {
            get { return listingsResult; }   // get method
            set { listingsResult = value; }  // set method
        }

        public JayRideModel()
        {

          //  LoadData();
            this.name = "J.Smith";
            this.phone = "04123456";
            this.ipAddress = "49.199.8.210";
            this.numPassengers = 3;
            jayRideDataModel = new JayRideDataModel();
            this.location =  jayRideDataModel.GetLocation(ipAddress);
            this.listingsResult =  jayRideDataModel.FilterListings(numPassengers);

             
        }

 

  
    }
}