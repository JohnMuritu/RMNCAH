using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RMNCAH_api.Data;
using RMNCAH_api.Models.Client;
using RMNCAH_api.Models.Reports;
using RMNCAH_api.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMNCAH_api.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportsController : ControllerBase
    {
        private readonly ApplicationDBContext _applicationDbContext;
        private readonly UserManager<User> _userManager;

        public ReportsController(ApplicationDBContext applicationDbContext, UserManager<User> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
        }

        [HttpGet("clientLongitudinalList")]
        public List<ClientDetailsAndClinicalData> getClientDetails()
        {
            using (_applicationDbContext)
            {
                string sqlQuery = "select client_clinical_details_id, cd.chv_name, dept_client_id, full_names, " +
                    "ROUND((DATE_PART('day', CURRENT_DATE - DOB)/365.25)::NUMERIC, 2) Age, dob, village, phone_number, " +
                    "alternative_phone_number, hf.facility_name \"hf_linked\", other_hf_attended, " +
                    "baby_name, anc1, anc2, anc3, anc4, anc5, edd, sba, penta1, penta2, penta3, mr1, remarks " +
                    "from public.client_details cd " +
                    "inner join public.client_clinical_details ccd on cd.client_id = ccd.client_id " +
                    "inner join public.health_facilities hf on cd.mfl_code = hf.mfl_code";

                return _applicationDbContext.ClientDetailsAndClinicalReportData.FromSqlRaw(sqlQuery).ToList();
            }
        }

        [HttpGet("clinicalAggregatedSummary")]
        public List<ClinicalAggregatedSummary> getClinicalAggregatedSummary()
        {
            using (_applicationDbContext)
            {
                string sqlQuery = "select count(anc1) total_anc1, count(anc2) total_anc2, count(anc3) total_anc3, count(anc4) total_anc4, " +
                    "count(anc5) total_anc5, count(edd) total_edd, count(sba) total_sba, count(penta1) total_penta1, count(penta2) total_penta2, " +
                    "count(penta3) total_penta3, count(mr1) total_mr1 " +
                    "from public.client_details cd " +
                    "inner join public.client_clinical_details ccd on cd.client_id = ccd.client_id " +
                    "inner join public.health_facilities hf on cd.mfl_code = hf.mfl_code";

                return _applicationDbContext.ClinicalAggregatedSummary.FromSqlRaw(sqlQuery).ToList();
            }
        }
    }
}
