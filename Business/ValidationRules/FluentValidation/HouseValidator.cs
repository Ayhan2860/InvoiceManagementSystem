using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class HouseValidator:AbstractValidator<House>
    {
        public HouseValidator()
        {
            RuleFor(x => x.ApartmentId).NotNull().WithMessage("Apartman bilgisi boş bırakılamaz");
            RuleFor(x => x.TypeInfo).NotNull().WithMessage("Daire Tipi bilgisi boş bırakılamaz");
            RuleFor(x => x.TypeInfo).MinimumLength(2).WithMessage("Daire Tipi bilgisi minimum 2 karakter olmalıdır");
            RuleFor(x => x.FloorNumber).NotNull().WithMessage("Kata numarası bilgisi boş bırakılamaz");
            RuleFor(x => x.DoorNumber).NotNull().WithMessage("Kapı numarası bilgisi boş bırakılamaz");
        }
    }
}