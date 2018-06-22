using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieWebApp.Models
{
    public class CustomerFormViewModel
    {
        public List<MemberShipType> MemberShipTypes { get; set; }

        public Customer Customer { get; set; }
    }
}