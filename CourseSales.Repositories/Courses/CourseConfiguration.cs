﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseSales.Repositories.Courses;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
        builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(x => x.Stock).IsRequired();
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.UserId).IsRequired().HasMaxLength(200);


    }
}

