using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BikeHire.Models
{
    public class Bike
    {
        public int BikeID { get; set; }
        public String Make { get; set; }
        public String Model { get; set; }
        public double RentalChargePerDay { get; set; }
        public bool BikeAvailable { get; set; }


        //Navigation Property
        public virtual List<Hire> hires { get; set; }
        //public ICollection<Hire> hires { get; set; }

        /*  Here we are considering a One - Many relationship between Bike and Hires (Customers)
            Assumption that; 
                Hire (Customer) has 1 Bike
                Bike has Many Hires (Customers) */


        public override string ToString()
        {
            return         "BikeID: "+ BikeID + ", Make: " + Make + ", Model: " +  Model + 
                            ", Rental Charge Per Day: " + RentalChargePerDay + ", Bike Available: " + BikeAvailable ;
        }
    }
}