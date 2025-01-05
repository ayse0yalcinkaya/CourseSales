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
        public string CreatedBy { get; set; } = default!; 
        public string? UpdatedBy { get; set; }

        public string UserId { get; set; } = default!;





    }
}
