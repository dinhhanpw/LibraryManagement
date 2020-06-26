using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModel
{
    class DataProvider
    {
        private static QLThuVienEntities _instance;
        public static QLThuVienEntities Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new QLThuVienEntities();

                return _instance;
            }
        }

        private DataProvider()
        {
            _instance = new QLThuVienEntities();
        }
    }
}
