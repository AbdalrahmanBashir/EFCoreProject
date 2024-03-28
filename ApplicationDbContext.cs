using EFCoreProject.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreProject.DAL;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Drug> Drugs { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PharmaceuticalCompany> PharmaceuticalCompanies { get; set; }

    public virtual DbSet<Pharmacy> Pharmacies { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Supervisor> Supervisors { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => new { e.PharmacyName, e.PharmaceuticalCompanyName }).HasName("contract_pkey");

            entity.ToTable("contract");

            entity.Property(e => e.PharmacyName)
                .HasMaxLength(255)
                .HasColumnName("pharmacy_name");
            entity.Property(e => e.PharmaceuticalCompanyName)
                .HasMaxLength(255)
                .HasColumnName("pharmaceutical_company_name");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.SupervisorId)
                .HasMaxLength(128)
                .HasColumnName("supervisor_id");
            entity.Property(e => e.Text).HasColumnName("text");

            entity.HasOne(d => d.PharmaceuticalCompanyNameNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.PharmaceuticalCompanyName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contract_pharmaceutical_company_name_fkey");

            entity.HasOne(d => d.PharmacyNameNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.PharmacyName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contract_pharmacy_name_fkey");

            entity.HasOne(d => d.Supervisor).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.SupervisorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contract_supervisor_id_fkey");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.PersonSsn).HasName("doctor_pkey");

            entity.ToTable("doctor");

            entity.Property(e => e.PersonSsn)
                .HasMaxLength(255)
                .HasColumnName("person_ssn");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.ExperienceYears).HasColumnName("experience_years");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.Speciality)
                .HasMaxLength(255)
                .HasColumnName("speciality");
        });

        modelBuilder.Entity<Drug>(entity =>
        {
            entity.HasKey(e => e.DrugTradeName).HasName("drug_pkey");

            entity.ToTable("drug");

            entity.Property(e => e.DrugTradeName)
                .HasMaxLength(255)
                .HasColumnName("drug_trade_name");
            entity.Property(e => e.Formula)
                .HasMaxLength(255)
                .HasColumnName("formula");
            entity.Property(e => e.PharmaceuticalCompanyName)
                .HasMaxLength(255)
                .HasColumnName("pharmaceutical_company_name");

            entity.HasOne(d => d.PharmaceuticalCompanyNameNavigation).WithMany(p => p.Drugs)
                .HasForeignKey(d => d.PharmaceuticalCompanyName)
                .HasConstraintName("drug_pharmaceutical_company_name_fkey");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PersonSsn).HasName("patient_pkey");

            entity.ToTable("patient");

            entity.Property(e => e.PersonSsn)
                .HasMaxLength(255)
                .HasColumnName("person_ssn");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.DoctorSsn)
                .HasMaxLength(255)
                .HasColumnName("doctor_ssn");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");

            entity.HasOne(d => d.DoctorSsnNavigation).WithMany(p => p.Patients)
                .HasForeignKey(d => d.DoctorSsn)
                .HasConstraintName("patient_doctor_ssn_fkey");
        });

        modelBuilder.Entity<PharmaceuticalCompany>(entity =>
        {
            entity.HasKey(e => e.PharmaceuticalCompanyName).HasName("pharmaceutical_company_pkey");

            entity.ToTable("pharmaceutical_company");

            entity.Property(e => e.PharmaceuticalCompanyName)
                .HasMaxLength(255)
                .HasColumnName("pharmaceutical_company_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
        });

        modelBuilder.Entity<Pharmacy>(entity =>
        {
            entity.HasKey(e => e.PharmacyName).HasName("pharmacy_pkey");

            entity.ToTable("pharmacy");

            entity.Property(e => e.PharmacyName)
                .HasMaxLength(255)
                .HasColumnName("pharmacy_name");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => new { e.DoctorSsn, e.PatientSsn, e.DrugTradeName }).HasName("prescription_pkey");

            entity.ToTable("prescription");

            entity.Property(e => e.DoctorSsn)
                .HasMaxLength(255)
                .HasColumnName("doctor_ssn");
            entity.Property(e => e.PatientSsn)
                .HasMaxLength(255)
                .HasColumnName("patient_ssn");
            entity.Property(e => e.DrugTradeName)
                .HasMaxLength(255)
                .HasColumnName("drug_trade_name");
            entity.Property(e => e.LatestDate).HasColumnName("latest_date");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.DoctorSsnNavigation).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.DoctorSsn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prescription_doctor_ssn_fkey");

            entity.HasOne(d => d.DrugTradeNameNavigation).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.DrugTradeName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prescription_drug_trade_name_fkey");

            entity.HasOne(d => d.PatientSsnNavigation).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.PatientSsn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prescription_patient_ssn_fkey");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => new { e.DrugTradeName, e.PharmacyName }).HasName("sale_pkey");

            entity.ToTable("sale");

            entity.Property(e => e.DrugTradeName)
                .HasMaxLength(255)
                .HasColumnName("drug_trade_name");
            entity.Property(e => e.PharmacyName)
                .HasMaxLength(255)
                .HasColumnName("pharmacy_name");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");

            entity.HasOne(d => d.DrugTradeNameNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.DrugTradeName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sale_drug_trade_name_fkey");

            entity.HasOne(d => d.PharmacyNameNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.PharmacyName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sale_pharmacy_name_fkey");
        });

        modelBuilder.Entity<Supervisor>(entity =>
        {
            entity.HasKey(e => e.SupervisorId).HasName("supervisor_pkey");

            entity.ToTable("supervisor");

            entity.Property(e => e.SupervisorId)
                .HasMaxLength(128)
                .HasColumnName("supervisor_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
