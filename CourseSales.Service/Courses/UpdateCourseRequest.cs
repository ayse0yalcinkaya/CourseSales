namespace CourseSales.Service.Courses;

public record UpdateCourseRequest(int Id, string Name, decimal Price, int Stock);

