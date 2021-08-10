using RMNCAH_api.Models.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RMNCAH_api.Models.Client
{
    public class ClientDetails
    {
        public ClientDetails()
        {
            ClientId = Guid.NewGuid();
            //DOB = DateTime.ParseExact(DOB.Date.ToString("dd-MM-yyyy"), "dd-MM-yyyy", CultureInfo.CurrentCulture);
            //DOB = DOB.Date;
            //dobDate = DOB.ToString("yyyy-MM-dd");
        }

        [Key]
        public Guid ClientId { get; set; }
        public string FullNames { get; set; }

        /*[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]*/
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
