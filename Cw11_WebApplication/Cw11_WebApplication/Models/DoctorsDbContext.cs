using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11_WebApplication.Models
{
	public class DoctorsDbContext: DbContext
	{
		public DbSet<Doctor> Doctors { get; set; }

		public DbSet<Medicament> Medicaments { get; set; }

		public DbSet<Patient> Patients { get; set; }

		public DbSet<Prescription> Prescriptions { get; set; }

		public DbSet<Prescription_Medicament> Prescriptions_Medicaments {get;set;}


		public DoctorsDbContext()
		{

		}

		public DoctorsDbContext(DbContextOptions options ) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder) 
		{
			base.OnModelCreating(modelBuilder);

			//FluentAPI
			modelBuilder.Entity<Medicament>()
						.HasKey(e => e.IdMedicament);
			modelBuilder.Entity<Medicament>()
						.Property(e => e.Name)
						.HasMaxLength(100)
						.IsRequired();

			modelBuilder.Entity<Medicament>()
						.Property(e => e.Description)
						.HasMaxLength(100)
						.IsRequired();

			modelBuilder.Entity<Medicament>()
						.Property(e => e.Type)
						.HasMaxLength(100)
						.IsRequired();

			modelBuilder.Entity<Medicament>()
						.HasKey(e => e.IdMedicament);						
			
			modelBuilder.Entity<Prescription_Medicament>()
						.HasKey(e => new {e.IdMedicament,e.IdPrescription}); // composition key


			//DOCTORS
			var dataDoctors = new List<Doctor>();
			dataDoctors.Add(new Doctor { IdDoctor = 1, FirstName="Jan", LastName="Kowalski", Email="jk@gmail.com"});
			dataDoctors.Add(new Doctor { IdDoctor = 2, FirstName="Anna", LastName="Nowak", Email="an@gmail.com"});
			dataDoctors.Add(new Doctor { IdDoctor = 3, FirstName="Barbara", LastName="Zawadzka", Email="bz@gmail.com"});
			dataDoctors.Add(new Doctor { IdDoctor = 4, FirstName="Danuta", LastName="Wasikowska", Email="dw@medicover.com"});
			dataDoctors.Add(new Doctor { IdDoctor = 5, FirstName="Tomasz", LastName="Lewandowski", Email="tomasz@onet.pl"});

			modelBuilder.Entity<Doctor>()
				.HasData(dataDoctors);

			//PATIENTS
			var dataPatients = new List<Patient>();
			dataPatients.Add(new Patient { IdPatient = 1, FirstName="Maria", LastName="Nowak", BirthDate = DateTime.Parse("1985-04-18")});
			dataPatients.Add(new Patient { IdPatient = 2, FirstName="Antonina", LastName="Michalak", BirthDate = DateTime.Parse("1943-01-02")});
			dataPatients.Add(new Patient { IdPatient = 3, FirstName="Eugeniusz", LastName="Kamiński", BirthDate = DateTime.Parse("1965-11-18")});

			modelBuilder.Entity<Patient>()
				.HasData(dataPatients);

			//MEDICAMENTS
			var dataMedicaments = new List<Medicament>();
			dataMedicaments.Add(new Medicament { IdMedicament = 1, Name="APAP", Description="aaaa", Type = "OTC"});
			dataMedicaments.Add(new Medicament { IdMedicament = 2, Name="Antybiotyk", Description="bbbb", Type = "na receptę"});
			dataMedicaments.Add(new Medicament { IdMedicament = 3, Name="Witamina C", Description="cccc", Type = "OTC"});

			modelBuilder.Entity<Medicament>()
				.HasData(dataMedicaments);

			//PRESCRIPTIONS
			var dataPrescriptions = new List<Prescription>();
			dataPrescriptions.Add(new Prescription { IdPrescription = 1, Date=DateTime.Parse("2020-04-01"), DueDate=DateTime.Parse("2020-05-01"), IdPatient = 1, IdDoctor = 1});
			dataPrescriptions.Add(new Prescription { IdPrescription = 2, Date=DateTime.Parse("2020-04-01"), DueDate=DateTime.Parse("2020-05-01"), IdPatient = 2, IdDoctor = 2});
			dataPrescriptions.Add(new Prescription { IdPrescription = 3, Date=DateTime.Parse("2020-01-31"), DueDate=DateTime.Parse("2020-03-01"), IdPatient = 2, IdDoctor = 2});
			dataPrescriptions.Add(new Prescription { IdPrescription = 4, Date=DateTime.Parse("2020-04-01"), DueDate=DateTime.Parse("2020-05-01"), IdPatient = 3, IdDoctor = 3});
			dataPrescriptions.Add(new Prescription { IdPrescription = 5, Date=DateTime.Parse("2020-01-13"), DueDate=DateTime.Parse("2020-07-31"), IdPatient = 3, IdDoctor = 4});

			modelBuilder.Entity<Prescription>()
				.HasData(dataPrescriptions);			

			//PRESCRIPTIONS_MEDICAMENTS
			var dataPrescriptions_Medicaments = new List<Prescription_Medicament>();
			dataPrescriptions_Medicaments.Add(new Prescription_Medicament { IdMedicament = 1, IdPrescription = 1, Dose = 1, Details = "1 x dziennie na czczo"});
			dataPrescriptions_Medicaments.Add(new Prescription_Medicament { IdMedicament = 1, IdPrescription = 2, Dose = 2, Details = "2 x dziennie (rano i wieczorem)"});
			dataPrescriptions_Medicaments.Add(new Prescription_Medicament { IdMedicament = 2, IdPrescription = 3, Dose = 1, Details = "razem z jedzeniem"});
			dataPrescriptions_Medicaments.Add(new Prescription_Medicament { IdMedicament = 3, IdPrescription = 4, Dose = 1, Details = "wieczorem "});
			dataPrescriptions_Medicaments.Add(new Prescription_Medicament { IdMedicament = 3, IdPrescription = 5, Dose = 1, Details = "1 x dziennie przez 7 dni"});
			dataPrescriptions_Medicaments.Add(new Prescription_Medicament { IdMedicament = 2, IdPrescription = 1, Dose = 1, Details = "dowolnie"});

			modelBuilder.Entity<Prescription_Medicament>()
				.HasData(dataPrescriptions_Medicaments);					
				//modelBuilder.ApplyConfiguration(new StudiesEfConfiguration());


		}
		
	}
}
