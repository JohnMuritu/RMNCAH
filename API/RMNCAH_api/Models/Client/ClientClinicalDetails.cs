﻿using RMNCAH_api.Models.Security;
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
        public string BabyName { get; set; }
        public DateTime? anc1 { get; set; }
        public DateTime? anc2 { get; set; }
        public DateTime? anc3 { get; set; }
        public DateTime? anc4 { get; set; }
        public DateTime? anc5 { get; set; }
        public DateTime? edd { get; set; }
        public DateTime? sba { get; set; }
        public DateTime? penta1 { get; set; }
        public DateTime? penta2 { get; set; }
        public DateTime? penta3 { get; set; }
        public DateTime? mr1 { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
