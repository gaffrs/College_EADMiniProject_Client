using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeHire.Models
{
    public class Hire
    {
        public int HireID { get; set; }
        public int BikeID { get; set; }                     //FK

        public String FirstName { get; set; }

        public String Surname { get; set; }

        public String Address { get; set; }

        /*//Other Phone attribute option
		[Required(ErrorMessage = "Number must not be blank")] //Not null or empty string
        // string 10 characters long & no shorter than 10 characters
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Number must be 10 digits long")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Number must be 10 digits long")]
        [Display(Name = "Phone Number")]             
        public String PhoneNumber { get; set; }
		*/

        public String PhoneNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        //Navigation Property
        //public Bike Bike { get; set; }
        public virtual Bike Bike { get; set; }        //using "virtual" causes and Circular References errors, used DTO

        public override string ToString()
        {
            return "HireID: " + HireID + ", FirstName: " + FirstName + ", Surname: " + Surname +
                            ", Address: " + Address + ", PhoneNumber: " + PhoneNumber +
                            ", StartDate: " + StartDate.ToShortDateString() + ", FinishDate: " + FinishDate.ToShortDateString();
        }

        /*  Here we are considering a One - Many relationship between Bike and Hires (Customers)
            Assumption that; 
                Hire (Customer) has 1 Bike
                Bike has Many Hires (Customers) */

        //Property to Calculate Rental Days
        public double RentalDays        //Read ONLY property    
        {
            get
            {
                return ((FinishDate - StartDate).TotalDays);
            }
        }
        /*  
               //Property to Calculate Rental Cost
               [Display(Name = "Rental Charge € ")]
               public double RentalCharge        //Read ONLY property    
               {
                   get
                   {

                       if (Bike.RentalChargePerDay != 0)
                       {
                           return RentalDays * Bike.RentalChargePerDay;
                       }
                       else
                       {
                           return Bike.RentalChargePerDay = 0;
                       }

                   }
               }


       */




        /*
                //Property to Calculate Rental Cost
                [Display(Name = "Rental Cost: € ")]
                public double RentalCost        //Read ONLY property    
                {
                    get
                    {
                        return ((FinishDate - StartDate).TotalDays) * Bike.RentalChargePerDay;
                    }
                }
        */
    }
}