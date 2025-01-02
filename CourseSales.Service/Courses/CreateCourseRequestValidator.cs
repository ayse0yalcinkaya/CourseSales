using FluentValidation;

namespace CourseSales.Service.Courses
{
    public class CreateCourseRequestValidator: AbstractValidator<CreateCourseRequest>
    {
        public CreateCourseRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Kurs ismi gereklidir.")
                .NotEmpty().WithMessage("Kurs ismi gereklidir")
                .Length(3, 60).WithMessage("Kurs ismi 3 ile 60 karakter arasında olmalıdır");
            
            RuleFor(x => x.Price)     
                .GreaterThan(0).WithMessage("Kurs fiyatı 0'dan büyük olmalıdır");

            RuleFor(x => x.Stock)
                .InclusiveBetween(1, 100).WithMessage("Kurs stok adedi 1 ile 100 arasında olmalıdır //sınıfa kayıt olan kişi");
        }

    }
}
