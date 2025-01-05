using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSales.Repositories.Orders
{
    public interface IOrderRepository:IGenericRepository<Order, int> 
    {
    }
}
