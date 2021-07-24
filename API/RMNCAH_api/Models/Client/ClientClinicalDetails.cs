using RMNCAH_api.Models.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RMNCAH_api.Models.Client
{
    public class ClientClinicalDetails
    {
        public ClientClinicalDetails()
        {
            ClientClinicalDetailsId = Guid.NewGuid();
        }

        [Key]
        public Guid ClientClinicalDetailsId { get; set; }
        public Guid ClientId { get; set; }
        public DateTime? ANC1 { get; set; }
        public DateTime? ANC2 { get; set; }
        public DateTime? ANC3 { get; set; }
        public DateTime? ANC4 { get; set; }
        public DateTime? ANC5 { get; set; }
        public DateTime? EDD { get; set; }
        public DateTime? SBA { get; set; }
        public DateTime? PENTA1 { get; set; }
        public DateTime? PENTA2 { get; set; }
        public DateTime? PENTA3 { get; set; }
        public DateTime? MR1 { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
