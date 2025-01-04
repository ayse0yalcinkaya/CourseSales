using CourseSales.Repositories.Categories;

namespace CourseSales.Repositories.Courses
{
    public class Course:BaseEntity<int>, IAuditEntity
    {
        
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
