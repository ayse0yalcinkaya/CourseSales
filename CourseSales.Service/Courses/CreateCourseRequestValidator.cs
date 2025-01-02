using System.Security.Cryptography.X509Certificates;
using CourseSales.Repositories.Courses;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CourseSales.Service.Courses
{
    public class CreateCourseRequestValidator: AbstractValidator<CreateCourseRequest>
    {
        private readonly ICourseRepository _courseRepository;
        public CreateCourseRequestValidator(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kurs ismi gereklidir")
                .Length(3, 60).WithMessage("Kurs ismi 3 ile 60 karakter arasında olmalıdır")
                .MustAsync(MustUniqueCourseNameAsync).WithMessage("Kurs ismi veritabanında bulunmaktadır");
                //.Must(MustUniqueCourseNameAsync).WithMessage("Kurs ismi veritabanında bulunmaktadır");

            RuleFor(x => x.Price)     
                .GreaterThan(0).WithMessage("Kurs fiyatı 0'dan büyük olmalıdır");

            RuleFor(x => x.Stock)
                .InclusiveBetween(1, 100).WithMessage("Kurs stok adedi 1 ile 100 arasında olmalıdır //sınıfa kayıt olan kişi");
        }

        private async Task<bool> MustUniqueCourseNameAsync(string name, CancellationToken cancellationToken)
        {
            return !await _courseRepository.Where(x => x.Name == name).AnyAsync(cancellationToken);
        }
        //senkron olan validation
        //private bool MustUniqueCourseName(string name)
        //{
        //    return !_courseRepository.Where(x => x.Name == name).Any();
        //}

    }
}
