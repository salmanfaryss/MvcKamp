using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.FluentValidator
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator() {

            
            RuleFor(x => x.Receiver).NotEmpty().WithMessage("Alıcı kismina boş geçemezsin!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Mesaj konu boş geçemezsin!!");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Mesaj içeriğini boş geçemezsin!..");

            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 2 karakter girmelisin");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen 50 karakter dan fazla giremezsin");
           
        }
    }
}
