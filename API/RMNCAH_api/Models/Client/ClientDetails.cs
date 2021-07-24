using RMNCAH_api.Models.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RMNCAH_api.Models.Client
{
    public class ClientDetails
    {
        public ClientDetails()
        {
            ClientId = Guid.NewGuid();
        }

        [Key]
        public Guid ClientId { get; set; }
        public string FullNames { get; set; }
        public DateTime DOB { get; set; }
        public string Village { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternativePhoneNumber { get; set; }
        public string HFLinked { get; set; }
        public string OtherHFAttended { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
