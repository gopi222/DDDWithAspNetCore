using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EmployeeManagement.Infrastructure.Data.EntityConfigurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");
            builder.HasKey(emp => emp.StudentId);
            builder.Property(emp => emp.StudentName).HasMaxLength(50).IsRequired();
            builder.HasOne(emp => emp.Country).WithMany().HasForeignKey(emp => emp.CountryId).IsRequired();
            builder.Property(emp => emp.DateOfBirth).HasColumnType("date");
            builder.Property(emp => emp.Email).HasMaxLength(50).IsRequired();
            builder.Property(emp => emp.PhoneNumber).HasMaxLength(15).IsRequired();
            builder.Property(emp => emp.SpokenLanguage).HasMaxLength(100).IsRequired();
        }
    }
}
