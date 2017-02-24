using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace aspnet.Models
{
    public class Customer
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Customer name")]

        public string name { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime? birthday { get; set; }

        public bool isSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}