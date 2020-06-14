using Cw11_WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11_WebApplication.Services
{
	public interface IDbService
    {
        IEnumerable<Doctor> GetDoctors();

        Boolean AddDoctor(Doctor doctor);

        Boolean UpdateDoctor(String id);

        Boolean DeleteDoctor(Doctor doctor);

        IEnumerable<Doctor> GetDoctor(string id);

	}
}
