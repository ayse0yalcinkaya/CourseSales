using CourseSales.Repositories.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CourseSales.Repositories.Users
{
    public class User: IdentityUser
    {
        public string City { get; set; } 

    }
}
