using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace MovieWebApp.Models
{
    public class Customer
    {
       
        [Required(ErrorMessage =  "Please enter the customer's name")]
        [StringLength(255)]
        public string Name { get; set; }


        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime BirthDate { get; set; }

        public int Id { get; set; }

        public bool IsSubscribed { get; set; }

        public MemberShipType MemberShipType { get; set; } // access to the object MemberShipType

        [Display(Name =  "Membership Types")]
        public byte MemberShipTypeId { get; set; } // the compiler will recognize this as a foreign key to MemberShipTypeId in the Database

       

        
    }
}