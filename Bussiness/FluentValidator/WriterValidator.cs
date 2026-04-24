using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.FluentValidator
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator() {

            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazarı adını boş geçemezsin!");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazarı soyadını boş geçemezsin!");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kismini boş geçemezsin!!");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriş yapın!..");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen en az 50 karakter'den fazla değer giriş yapmayınız.");
        }
    }
}
