using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RMNCAH_api.Data;
using RMNCAH_api.Models.Client;
using RMNCAH_api.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RMNCAH_api.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly ApplicationDBContext _applicationDbContext;
        private readonly UserManager<User> _userManager;

        public ClientController(ApplicationDBContext applicationDbContext, UserManager<User> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
        }

        [HttpPost("AddClientDetails")]
        public ClientDetails AddClientDetails(ClientDetails cd)
        {
            using (_applicationDbContext)
            {
                cd.CreatedBy = _userManager.GetUserId(User);
                cd.CreatedDate = DateTime.Now;

                _applicationDbContext.ClientDetails.Add(cd);
                _applicationDbContext.SaveChanges();
                return _applicationDbContext.ClientDetails.Where(_r => _r.ClientId == cd.ClientId).FirstOrDefault();
            }
        }

        [HttpPost("UpdateClientDetails")]
        public ClientDetails UpdateClientDetails(ClientDetails cd)
        {
            using (_applicationDbContext)
            {
                ClientDetails details = _applicationDbContext.ClientDetails
                    .Where(r => r.ClientId == cd.ClientId)
                    .FirstOrDefault();
                details.FullNames = cd.FullNames;
                details.DOB = cd.DOB;
                details.Village = cd.Village;
                details.PhoneNumber = cd.PhoneNumber;
                details.AlternativePhoneNumber = cd.AlternativePhoneNumber;
                details.HFLinked = cd.HFLinked;
                details.OtherHFAttended = cd.OtherHFAttended;
                details.UpdatedBy = _userManager.GetUserId(User);
                details.UpdatedDate = DateTime.Now;

                _applicationDbContext.SaveChanges();
                return _applicationDbContext.ClientDetails.Where(_r => _r.ClientId == cd.ClientId).FirstOrDefault();
            }
        }

        [HttpPost("AddClientClinicalDetails")]
        public ClientClinicalDetails AddClientClinicalDetails(ClientClinicalDetails cd)
        {
            using (_applicationDbContext)
            {
                cd.CreatedBy = _userManager.GetUserId(User);
                cd.CreatedDate = DateTime.Now;

                _applicationDbContext.ClientClinicalDetails.Add(cd);
                _applicationDbContext.SaveChanges();
                return _applicationDbContext.ClientClinicalDetails.Where(_r => _r.ClientClinicalDetailsId == cd.ClientClinicalDetailsId).FirstOrDefault();
            }
        }
    }
}
