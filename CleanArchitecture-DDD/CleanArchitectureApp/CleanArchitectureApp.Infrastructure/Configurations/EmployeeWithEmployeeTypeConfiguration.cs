using CleanArchitectureApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Infrastructure.Configurations;

internal sealed class EmployeeWithEmployeeTypeConfiguration : IEntityTypeConfiguration<EmployeeWithEmployeeType>
{
    public void Configure(EntityTypeBuilder<EmployeeWithEmployeeType> builder)
    {
        builder.ToTable("EmployeeWithEmployeeTypes");
        builder.HasKey(p => new { p.EmployeeId, p.EmployeeType });
    }
}