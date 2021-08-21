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
    [Route("api/utils")]
    public class UtilsController : ControllerBase
    {
        private readonly ApplicationDBContext _applicationDbContext;

        public UtilsController(ApplicationDBContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet("deliveryoptions")]
        public List<DeliveryOptions> getDeliveryOptions()
        {
            using (_applicationDbContext)
            {
                return _applicationDbContext.DeliveryOptions.ToList();
            }
        }

        [HttpGet("adultremarks")]
        public List<AdultRemarksOptions> getAdultRemarksOptions()
        {
            using (_applicationDbContext)
            {
                return _applicationDbContext.AdultRemarksOptions.ToList();
            }
        }

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
