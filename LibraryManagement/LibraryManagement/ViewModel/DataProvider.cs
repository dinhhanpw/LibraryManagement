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
        private static DataProvider _instance;


        public QLThuVienEntities DataBase { get; set; }

        public static DataProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DataProvider();

                return _instance;
            }
        }

        private DataProvider()
        {
            DataBase = new QLThuVienEntities();
        }
    }
}
