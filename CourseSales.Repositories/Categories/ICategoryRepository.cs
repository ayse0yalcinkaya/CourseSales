using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSales.Repositories.Categories
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Task<Category?> GetCategoryWithCoursesAsync(int id);
        IQueryable<Category?> GetCategoryByCoursesAsync();
    }
}
