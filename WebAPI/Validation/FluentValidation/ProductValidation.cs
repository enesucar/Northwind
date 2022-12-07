using FluentValidation;
using WebAPI.Entities;

namespace WebAPI.Validation.FluentValidation
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(x => x.ProductName).MinimumLength(6).WithMessage("İsim en az 6 karakter olmalıdır.");
        }
    }
}
