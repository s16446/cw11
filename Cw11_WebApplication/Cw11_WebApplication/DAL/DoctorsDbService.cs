using Cw11_WebApplication.Models;
using Cw11_WebApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11_WebApplication.DAL
{	
	public class DoctorsDbService : IDbService
	{
		private readonly DoctorsDbContext _context;

		public DoctorsDbService(DoctorsDbContext context)
        {
           _context = context;
        }

		public bool AddDoctor(Doctor doctor)
		{
			if (!_context.Doctors.Contains(doctor)) {
				_context.Doctors.Add(doctor);
				_context.SaveChanges();
				return true;
            }
            else
                return false;
		}

		public bool DeleteDoctor(Doctor doctor)
		{
			if (_context.Doctors.Contains(doctor)) {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
		}

		public IEnumerable<Doctor> GetDoctor(string id)
		{
			var _doctors = _context.Doctors.Where(p => p.IdDoctor.ToString() == id).Select(p => new Doctor() 
				{ 
					  IdDoctor = p.IdDoctor
					, FirstName  = p.FirstName
					, LastName = p.LastName
					, Email = p.Email
				}).ToList();
            
            return _doctors;
		}

		public IEnumerable<Doctor> GetDoctors()
		{
			var _doctors = _context.Doctors.Select(p => new Doctor() 
				{ 
					  IdDoctor = p.IdDoctor
					, FirstName  = p.FirstName
					, LastName = p.LastName
					, Email = p.Email
				}).ToList();

            return _doctors;
		}

		public bool UpdateDoctor(string id)
		{
			var _doctor = _context.Doctors.Where(s => s.IdDoctor.ToString() == id).FirstOrDefault();
            if (_context.Doctors.Contains(_doctor)) {
                _context.Doctors.Update(_doctor);
                _context.SaveChanges();
                return true;
             }
             else
                return false;
		}

	}
}
