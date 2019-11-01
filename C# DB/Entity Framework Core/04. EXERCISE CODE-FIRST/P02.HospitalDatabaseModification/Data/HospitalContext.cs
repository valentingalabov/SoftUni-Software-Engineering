using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {

        }

        public HospitalContext(DbContextOptions options)
            : base(options)
        {

        }


        public DbSet<Patient> Patients { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<PatientMedicament> Prescriptions { get; set; }

        public DbSet<Doctor> Doctors { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.connectionString);
            }


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity
                .HasKey(p => p.PatientId);

                entity
                .Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);

                entity
                .Property(p => p.LastName)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(false);


                entity
                .Property(p => p.Address)
                .HasMaxLength(250)
                .IsUnicode(true)
                .IsRequired(true);

                entity
                .Property(p => p.Email)
                .HasMaxLength(80)
                .IsUnicode(true)
                .IsRequired(true);

            });

            modelBuilder.Entity<Visitation>(entity =>
            {
                entity.HasKey(v => v.VisitationId);

                entity
                .Property(v => v.Comments)
                .HasMaxLength(250)
                .IsUnicode(true)
                .IsRequired(false);

                entity
                .HasOne(e => e.Patient)
                .WithMany(p => p.Visitations)
                .HasForeignKey(e => e.PatientId);

                entity.HasOne(v=>v.Doctor)
                .WithMany(p=>p.Visitations)
                .HasForeignKey(v=>v.DoctorId);
                               

            });


            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity
                .HasKey(d => d.DiagnoseId);

                entity
                .Property(d => d.Name)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);

                entity
                .Property(d => d.Comments)
                .HasMaxLength(250)
                .IsUnicode(true)
                .IsRequired(false);

                entity
                .HasOne(e => e.Patient)
                .WithMany(p => p.Diagnoses)
                .HasForeignKey(e => e.DiagnoseId);



            });

            modelBuilder.Entity<Medicament>(entity =>
            {

                entity.HasKey(m => m.MedicamentId);

                entity
                .Property(m => m.Name)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);

            });

            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(e => new { e.PatientId, e.MedicamentId });

                entity.HasOne(e => e.Patient)
                   .WithMany(p => p.Prescriptions)
                   .HasForeignKey(e => e.PatientId);

                entity.HasOne(e => e.Medicament)
                    .WithMany(m => m.Prescriptions)
                    .HasForeignKey(e => e.MedicamentId);

            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(d => d.DoctorId);

                entity
                .Property(d => d.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(100);

                entity
                .Property(d => d.Specialty)
                .IsRequired(true)
                .IsUnicode()
                .HasMaxLength(100);



            });

        }

    }
}
