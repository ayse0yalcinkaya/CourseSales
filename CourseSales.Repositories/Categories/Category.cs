using CourseSales.Repositories.Courses;

namespace CourseSales.Repositories.Categories
{
    public class Category:IAuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course>? Courses { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
