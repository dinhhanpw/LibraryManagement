using FluentValidation;
using LibraryManagement.Model;
using System;

namespace LibraryManagement.ViewModel.Validator
{
    public class ReaderValidator : AbstractValidator<DocGia>
    {
        private static string notEmpty_ErrMessage = "không được để trống";
        private static string mustGreater_ErrMessage = "phải lớn hơn";
        private static string mustLess_ErrMessage = "phải nhỏ hơn";
        private static DateTime currentDate = DateTime.Now;

        public int MinLength { get; set; } = 5;
        public ReaderValidator()
        {

            RuleFor(reader => reader.Ten).NotNull().WithMessage($"Tên {notEmpty_ErrMessage}")
                .NotEmpty().WithMessage($"Tên {notEmpty_ErrMessage}")
                .MinimumLength(MinLength).WithMessage($"Độ dài của chuỗi {mustGreater_ErrMessage} {MinLength}");

            RuleFor(reader => reader.NgaySinh)
                .LessThan(currentDate.AddYears(-18)).WithMessage($"Đọc giả {mustGreater_ErrMessage} 18 tuổi")
                .GreaterThan(currentDate.AddYears(-35)).WithMessage($"Đọc giả {mustLess_ErrMessage} 35 tuổi");

        }
    }

}
