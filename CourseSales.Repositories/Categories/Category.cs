using CourseSales.Repositories.Courses;

namespace CourseSales.Repositories.Categories
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course>? Courses { get; set; }
    }
}
