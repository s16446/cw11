using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw11_WebApplication.DAL;
using Cw11_WebApplication.Models;
using Cw11_WebApplication.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cw11_WebApplication
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
		Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//services.AddScoped<IDbService, SqlServerDoctorDbService>();
			services.AddDbContext<DoctorsDbContext>(options => 
			{
				options.UseSqlServer("Data Source=db-mssql;Initial Catalog=s16446;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
			}
			
			);
			services.AddScoped<IDbService, DoctorsDbService>();
			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}

		app.UseRouting();

		app.UseAuthorization();

		app.UseEndpoints(endpoints =>
		{
		endpoints.MapControllers();
		});
		}
	}
}
