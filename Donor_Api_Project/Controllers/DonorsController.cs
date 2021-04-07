using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Donor_Api_Project.Models;
using Donor_Api_Project.Repository;

namespace Donor_Api_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorsController : ControllerBase
    {
        private readonly IDonorRepo _context;

        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(DonorsController));

        public DonorsController(IDonorRepo context)
        {
            _context = context;
        }

        // GET: api/Donars
        [HttpGet]
        public  IEnumerable<Donor> GetAllDonors()
        {
            return  _context.GetAllDonors();
        }

        [HttpPost]
        [Route("DonorRegister")]
        public async Task<ActionResult<Donor>> DonorRegister(Donor donor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var donorRegistered = await _context.DonorRegister(donor);



            return Ok(donorRegistered);
        }


        [HttpGet]
        [Route("GetDonor/{bid}")]
        public IActionResult GetDonorbyId(int bid)
        {
            try
            {
                return Ok(_context.GetDonorbyId(bid));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

        [HttpPut]
        [Route("EditDonor")]
        public void DonorEdit(int id, Donor don)
        {
             _context.DonorEdit(id,don);

        }

        [HttpDelete]
        [Route("DeletebyId/{id}")]
        public void DeletebyId(int id)
        {

            _context.DeletebyId(id);

        }


    }
}
