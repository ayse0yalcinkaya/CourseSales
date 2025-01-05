using CourseSales.Repositories.Courses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSales.Repositories.Orders
{
    internal class OrderRepository(CourseSalesDbContext context) : GenericRepository<Order, int>(context), IOrderRepository
    {
        
    }
}
