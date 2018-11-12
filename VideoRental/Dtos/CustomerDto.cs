using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VideoRental.Models;

namespace VideoRental.Dtos
{
    public class CustomerDbo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
                      
        public byte MembershipTypeId { get; set; }
       
        [Min18YearsIfAMember]  
        public DateTime? BirthDate { get; set; }
    }
}
