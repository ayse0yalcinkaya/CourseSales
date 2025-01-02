﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSales.Service.Courses.Create
{
    public record CourseDto(int Id, string Name, decimal Price, int Stock);
    //{
    //    public int Id { get; init; }
    //    public string Name { get; init; }
    //    public decimal Price { get; init; }
    //    public int Stock { get; init; }
    //}
}
