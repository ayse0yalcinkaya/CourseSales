using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSales.Repositories.Courses
{
    public interface ICourseRepository:IGenericRepository<Course>
    {
        public Task<List<Course>> GetTopPriceCourseAsync(int count);
    }
        
    
}
