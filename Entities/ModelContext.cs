using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

#nullable disable

namespace DIIS.PersonApp.Entities
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DevLoanType> DevLoanTypes { get; set; }
        public virtual DbSet<DevSample> DevSamples { get; set; }
        public virtual DbSet<VWeekDay> VWeekDays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.102.178)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=NORA178.PSU.AC.TH)));User Id=DEVDEMO;Password=abc123**;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("DEVDEMO")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CUSTOMER");

                entity.Property(e => e.CustName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CUST_NAME");

                entity.Property(e => e.CustSname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CUST_SNAME");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID");
            });

            modelBuilder.Entity<DevLoanType>(entity =>
            {
                entity.HasKey(e => e.LoanTypeId)
                    .HasName("DEV_LOAN_TYPE_PK");

                entity.ToTable("DEV_LOAN_TYPE");

                entity.Property(e => e.LoanTypeId)
                    .HasPrecision(3)
                    .HasColumnName("LOAN_TYPE_ID");

                entity.Property(e => e.Active)
                    .HasPrecision(1)
                    .HasColumnName("ACTIVE");

                entity.Property(e => e.LoanInterate)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("LOAN_INTERATE");

                entity.Property(e => e.LoanMaxAmount)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("LOAN_MAX_AMOUNT");

                entity.Property(e => e.LoanParentId)
                    .HasPrecision(3)
                    .HasColumnName("LOAN_PARENT_ID");

                entity.Property(e => e.LoanParentName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("LOAN_PARENT_NAME");

                entity.Property(e => e.LoanPeriod)
                    .HasPrecision(2)
                    .HasColumnName("LOAN_PERIOD");

                entity.Property(e => e.LoanTypeName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("LOAN_TYPE_NAME");

                entity.Property(e => e.Remark)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("REMARK");
            });

            modelBuilder.Entity<DevSample>(entity =>
            {
                entity.ToTable("DEV_SAMPLE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("DATE")
                    .HasColumnName("BIRTH_DATE");

                entity.Property(e => e.CustFirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CUST_FIRST_NAME");

                entity.Property(e => e.CustLastName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CUST_LAST_NAME");
            });

            modelBuilder.Entity<VWeekDay>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_WEEK_DAY");

                entity.Property(e => e.CountNumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COUNT_NUMBER");

                entity.Property(e => e.WeekDay)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("WEEK_DAY");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
