using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagement.ViewModel
{
    public class ReaderViewModel : BaseViewModel
    {
        private DocGia _holder;
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ObservableCollection<DocGia> Readers { get; set; }
        public DocGia Holder
        {
            get { return _holder; }
            set
            {
                if (value != null)
                    SetBindableProperty(ref _holder, value);
            }
        }


        public ObservableCollection<LoaiDocGia> ReaderTypes { get; set; }

        public ReaderViewModel()
        {
            AddCommand = new RelayCommand<DocGia>(CanAdd, OnAdd);
            EditCommand = new RelayCommand<DocGia>(CanEdit, OnEdit);
            Readers = new ObservableCollection<DocGia>(DataProvider.Instance.DocGias);
            ReaderTypes = new ObservableCollection<LoaiDocGia>(DataProvider.Instance.LoaiDocGias);
            Holder = new DocGia();
            Holder.LoaiDocGia = new LoaiDocGia();
        }

        bool CanAdd(DocGia reader)
        {
            if (Holder == null) return false;

            return !Holder.HasErrors;
        }

        bool CanEdit(DocGia selectedReader)
        {
            return selectedReader != null && !Holder.HasErrors;
        }

        void OnAdd(DocGia reader)
        {
            DocGia docGia = new DocGia()
            {
                Ten = Holder.Ten,
                IdLoai = Holder.LoaiDocGia.Id,
                NgaySinh = Holder.NgaySinh,
                DiaChi = Holder.DiaChi,
                Email = Holder.Email,
                NgayLap = Holder.NgayLap,
            };

            DataProvider.Instance.DocGias.Add(docGia);
            DataProvider.Instance.SaveChanges();

            Readers.Add(docGia);
        }

        void OnEdit(DocGia reader)
        {
            DocGia selectedReader = DataProvider.Instance.DocGias.First(p => p.Id == Holder.Id);

            DataProvider.Instance.SaveChanges();
        }
    }
}
