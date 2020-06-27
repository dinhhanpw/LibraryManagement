using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModel.Validator
{
    class ValidationHelper
    {
        public static string notEmpty_ErrMessage = "không được để trống";
        public static string mustGreater_ErrMessage = "phải lớn hơn";
        public static string mustLess_ErrMessage = "phải nhỏ hơn";
        public static string mustLeast_ErrMessage = "phải có ít nhất";
        public static string MustRange_ErrMessage (int from, int to)
        {
            return $"phải từ {from} đến {to}";
        }
        public static DateTime currentDate = DateTime.Now;

    }
}
