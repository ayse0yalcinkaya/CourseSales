namespace CourseSales.Service.Courses.Update;

public record UpdateCourseRequest(string Name, decimal Price, int Stock, string Description, int CategoryId);

