using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieWebApp.Models;
using System.ComponentModel.DataAnnotations;


namespace MovieWebApp.Dtos
{
    
    public class CustomerDto
    {

        [Required(ErrorMessage = "Please enter the customer's name")]
        [StringLength(255)]
        public string Name { get; set; }


       // [Min18YearsIfAMember]
        public DateTime BirthDate { get; set; }

        public int Id { get; set; }

        public bool IsSubscribed { get; set; }

                
        public byte MemberShipTypeId { get; set; } // the compiler will recognize this as a foreign key to MemberShipTypeId in the Database
         
        public MembershipTypeDto MemberShipType { get; set; }


 
       
    }
}