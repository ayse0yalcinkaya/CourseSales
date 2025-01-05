using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSales.Service.Authentication.Dto
{
    public record LoginRequestDto(string Email, string Password);
}
