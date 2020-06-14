using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw11_WebApplication.Models;
using Cw11_WebApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Cw11_WebApplication.Controllers
{
	[Route("api/doctors")]
	[ApiController]
	public class DoctorsController : ControllerBase
	{
	    private IConfiguration Configuration { get; set; }
        private IDbService _dbService;

        public DoctorsController(IDbService dbService, IConfiguration configuration)
        {
            _dbService = dbService;
            Configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_dbService.GetDoctors());
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctor(string id)
        {
            var _doctors = _dbService.GetDoctor(id);
            if (_doctors.Any())
                return Ok(_dbService.GetDoctor(id));
            else
                return NotFound();
        }

        [HttpPost] // add
        /* JSON bez ID doktora
         {
            "firstName": "Michał",
            "lastName": "Radomyski",
            "email": "mr@enelmed.pl",
            "prescriptions": null
            }
         */
        public IActionResult AddDoctor(Doctor doctor)
        {
            if (_dbService.AddDoctor(doctor))
                return Ok(doctor);
            else
                return BadRequest("Doktor już istnieje " + doctor.IdDoctor + " "  + doctor.FirstName + " " + doctor.LastName);
        }

        [HttpPut("{id}")] // update
        public IActionResult UpdateDoctor(string id)
        {
            if (_dbService.UpdateDoctor(id))
                return Ok("Aktualizacja doktora o id: " + id + " została zakończona");
            else
                return NotFound("Nie znaleziono doktora o id: " + id);
        }

        [HttpDelete("{id}")] // delete
        public IActionResult DeleteDoctor(string id)
        {
            var doctor = _dbService.GetDoctors().Where(d => d.IdDoctor.ToString() == id).FirstOrDefault();
            if (doctor != null) 
            {
                _dbService.DeleteDoctor(doctor);
                return Ok("Usunięto doktora o id: " + id);
            }
            else
            {
                return NotFound("Nie znaleziono doktora o id: " + id);
            }
        }

	}
}
