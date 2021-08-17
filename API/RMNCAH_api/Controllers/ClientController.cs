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

        [HttpGet("ClientDetails")]
        public List<ClientDetails> getClientDetails()
        {
            using (_applicationDbContext)
            {
                return _applicationDbContext.ClientDetails.Include(h => h.HFLinked).OrderBy(c => c.FullNames).ToList();
            }
        }

        [HttpPost("AddClientDetails")]
        public ClientDetails AddClientDetails(ClientDetails cd)
        {
            using (_applicationDbContext)
            {              
                cd.CreatedBy = _userManager.GetUserId(User);
                cd.CreatedDate = DateTime.Now;

                _applicationDbContext.HealthFacility.Attach(cd.HFLinked);
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
                details.chvName = cd.chvName;
                details.deptClientId = cd.deptClientId;
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

        [HttpGet("ClientClinicalDetails/{clientId}")]
        public List<ClientClinicalDetails> getClientClinicaltDetails(Guid clientId)
        {
            using (_applicationDbContext)
            {
                return _applicationDbContext.ClientClinicalDetails.Where(a => a.ClientId == clientId).ToList();
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

        [HttpPost("UpdateClientClinicalDetails")]
        public ClientClinicalDetails UpdateClientClinicalDetails(ClientClinicalDetails cd)
        {
            using (_applicationDbContext)
            {
                ClientClinicalDetails details = _applicationDbContext.ClientClinicalDetails
                    .Where(r => r.ClientClinicalDetailsId == cd.ClientClinicalDetailsId)
                    .FirstOrDefault();
                details.BabyName = cd.BabyName;
                details.anc1 = cd.anc1;
                details.anc2 = cd.anc2;
                details.anc3 = cd.anc3;
                details.anc4 = cd.anc4;
                details.anc5 = cd.anc5;
                details.edd = cd.edd;
                details.sba = cd.sba;
                details.penta1 = cd.penta1;
                details.penta2 = cd.penta2;
                details.penta3 = cd.penta3;
                details.mr1 = cd.mr1;
                details.Remarks = cd.Remarks;
                details.UpdatedBy = _userManager.GetUserId(User);
                details.UpdatedDate = DateTime.Now;

                _applicationDbContext.SaveChanges();
                return _applicationDbContext.ClientClinicalDetails.Where(_r => _r.ClientClinicalDetailsId == cd.ClientClinicalDetailsId).FirstOrDefault();
            }
        }
    }
}
