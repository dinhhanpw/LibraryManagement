using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagement.ViewModel
{
    public class ReaderViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; set; }
        public ObservableCollection<DocGia> Readers { get; set; }
        public DocGia Holder { get; set; }
        public ObservableCollection<LoaiDocGia> ReaderTypes { get; set; }

        public ReaderViewModel()
        {
            AddCommand = new RelayCommand<DocGia>(CanAdd, OnAdd);
            Readers = new ObservableCollection<DocGia>(DataProvider.Instance.DocGias);
            ReaderTypes = new ObservableCollection<LoaiDocGia>(DataProvider.Instance.LoaiDocGias);
            Holder = new DocGia();
            Holder.LoaiDocGia = new LoaiDocGia();
        }

        bool CanAdd(DocGia reader)
        {
            //if (reader != null) return false;

            return !Holder.HasErrors;
        }

        void OnAdd(DocGia reader)
        {
            DocGia docGia = new DocGia()
            {
                Ten = Holder.Ten,
                IdLoai = Holder.IdLoai,
                NgaySinh = Holder.NgaySinh,
                DiaChi = Holder.DiaChi,
                Email = Holder.Email,
                NgayLap = Holder.NgayLap,
            };

            Readers.Add(docGia);
        }
    }
}
