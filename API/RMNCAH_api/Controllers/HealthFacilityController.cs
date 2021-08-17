using Microsoft.AspNetCore.Mvc;
using RMNCAH_api.Data;
using RMNCAH_api.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMNCAH_api.Controllers
{
    [ApiController]
    [Route("api/healthfacility")]
    public class HealthFacilityController : ControllerBase
    {
        private readonly ApplicationDBContext _applicationDbContext;

        public HealthFacilityController(ApplicationDBContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public List<HealthFacilities> getHealthFacilities()
        {
            using (_applicationDbContext)
            {
                return _applicationDbContext.HealthFacility.OrderBy(c => c.FacilityName).ToList();
            }
        }
    }
}
