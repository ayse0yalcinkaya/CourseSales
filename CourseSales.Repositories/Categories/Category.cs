using CourseSales.Repositories.Courses;

namespace CourseSales.Repositories.Categories
{
    public class Category:BaseEntity<int>,IAuditEntity
    {
        public string Name { get; set; } = default!;
        public List<Course>? Courses { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string CreatedBy { get; set; } = default!;
        public string? UpdatedBy { get; set; }
    }
}
