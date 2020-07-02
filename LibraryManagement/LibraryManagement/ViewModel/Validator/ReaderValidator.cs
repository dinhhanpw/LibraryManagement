using FluentValidation;
using LibraryManagement.Model;
using System;

namespace LibraryManagement.ViewModel.Validator
{
    public class ReaderValidator : AbstractValidator<DocGia>
    {

        private int MinLength { get; set; } = 5;

        public ReaderValidator()
        {

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleSet("Ten", () =>
            {
                RuleFor(reader => reader.Ten)
                .NotNull().WithMessage($"Tên {ValidationHelper.notEmpty_ErrMessage}")
                .NotEmpty().WithMessage($"Tên {ValidationHelper.notEmpty_ErrMessage}")
                .MinimumLength(MinLength).WithMessage($"Tên {ValidationHelper.mustLeast_ErrMessage} {MinLength} kí tự");
            });

            RuleSet("NgaySinh", () =>
            {
                RuleFor(reader => reader.NgaySinh)
                .Must((reader, val) =>
                {
                    if (val <= reader.NgayLap.AddYears(-18) && val > reader.NgayLap.AddYears(-36)) return true;

                    return false;

                }).WithMessage($"Đọc giả phải {ValidationHelper.MustRange_ErrMessage(18, 35)} tuổi");
            });

            RuleSet("DiaChi", () =>
            {
                RuleFor(reader => reader.DiaChi)
                .NotNull().WithMessage($"Tên {ValidationHelper.notEmpty_ErrMessage}")
                .NotEmpty().WithMessage($"Tên {ValidationHelper.notEmpty_ErrMessage}")
                .MinimumLength(MinLength).WithMessage($"Địa chỉ {ValidationHelper.mustLeast_ErrMessage} {MinLength} kí tự");
            });

            RuleSet("Email", () =>
            {
                RuleFor(reader => reader.Email)
                .NotEmpty().WithMessage($"Email {ValidationHelper.notEmpty_ErrMessage}")
                .EmailAddress().WithMessage("Email không hợp lệ");
            });

            RuleSet("NgayLap", () =>
            {
                RuleFor(reader => reader.NgayLap)
                .Must((reader, val) =>
                {
                    if (val >= reader.NgaySinh.AddYears(18) && val < reader.NgaySinh.AddYears(36)) return true;
                    return false;

                }).WithMessage($"Đọc giả phải {ValidationHelper.MustRange_ErrMessage(18, 35)} tuổi");
            });


        }
    }

}
