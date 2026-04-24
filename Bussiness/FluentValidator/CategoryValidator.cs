using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.FluentValidator
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator() {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adına boş geçemezsin!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçemezsin!");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriş yapınız..");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Lütfen en az 20 karakter'den fazla değer giriş yapmayınız.");
        }
    }
}
