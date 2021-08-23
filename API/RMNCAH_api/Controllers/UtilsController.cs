using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RMNCAH_api.Data;
using RMNCAH_api.Models.Security;
using RMNCAH_api.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMNCAH_api.Controllers
{
    [ApiController]
    [Route("api/utils")]
    public class UtilsController : ControllerBase
    {
        private readonly ApplicationDBContext _applicationDbContext;

        public UtilsController(ApplicationDBContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [Authorize(Policy = Policies.User)]
        [HttpGet("deliveryoptions")]
        public List<DeliveryOptions> getDeliveryOptions()
        {
            using (_applicationDbContext)
            {
                return _applicationDbContext.DeliveryOptions.ToList();
            }
        }

        [Authorize(Policy = Policies.User)]
        [HttpGet("adultremarks")]
        public List<AdultRemarksOptions> getAdultRemarksOptions()
        {
            using (_applicationDbContext)
            {
                return _applicationDbContext.AdultRemarksOptions.ToList();
            }
        }

        [Authorize(Policy = Policies.User)]
        [HttpGet("childremarks")]
        public List<ChildRemarksOptions> getChildRemarksOptions()
        {
            using (_applicationDbContext)
            {
                return _applicationDbContext.ChildRemarksOptions.ToList();
            }
        }
    }
}
