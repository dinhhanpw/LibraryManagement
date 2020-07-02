using LibraryManagement.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace LibraryManagement.ViewModel
{
    public class ReaderViewModel : BaseViewModel
    {
        private DocGia _holder;
        private DocGia _selectedReader;
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand EditOnTableDataCommand { get; set; }
        public ObservableCollection<DocGia> Readers { get; set; }
        public DocGia SelectedReader { get { return _selectedReader; }
            set
            {
                if (value == null) return;
                _selectedReader = value;

                Holder.Ten = SelectedReader.Ten;
                Holder.NgaySinh = SelectedReader.NgaySinh;
                Holder.IdLoai = SelectedReader.IdLoai;
                Holder.NgayLap = SelectedReader.NgayLap;
                Holder.Email = SelectedReader.Email;
                Holder.DiaChi = SelectedReader.DiaChi;

            }
        }
        public DocGia Holder
        {
            get { return _holder; }
            set
            {
                    SetBindableProperty(ref _holder, value);
            }
        }

        public ObservableCollection<LoaiDocGia> ReaderTypes { get; set; }

        public ReaderViewModel()
        {
            AddCommand = new RelayCommand<DocGia>(CanAdd, OnAdd);
            EditCommand = new RelayCommand<DocGia>(CanEdit, OnEdit);
            EditOnTableDataCommand = new RelayCommand<GridViewRowEditEndedEventArgs>(argument => argument != null, OnEdit);
            Readers = new ObservableCollection<DocGia>(DataProvider.Instance.DataBase.DocGias);
            ReaderTypes = new ObservableCollection<LoaiDocGia>(DataProvider.Instance.DataBase.LoaiDocGias);
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

            DataProvider.Instance.DataBase.DocGias.Add(docGia);
            DataProvider.Instance.DataBase.SaveChanges();

            Readers.Add(docGia);
        }

        void OnEdit(DocGia reader)
        {

            //DocGia selectedReader = DataProvider.Instance.DataBase.DocGias.First(p => p.Id == Holder.Id);

            SelectedReader.Ten = Holder.Ten;
            SelectedReader.NgaySinh = Holder.NgaySinh;
            SelectedReader.IdLoai = Holder.IdLoai;
            SelectedReader.NgayLap = Holder.NgayLap;
            SelectedReader.Email = Holder.Email;
            SelectedReader.DiaChi = Holder.DiaChi;

            DataProvider.Instance.DataBase.SaveChanges();
        }

       void OnEdit(GridViewRowEditEndedEventArgs args)
        {
            if (args.EditAction == GridViewEditAction.Cancel) return;

            if(args.EditOperationType == GridViewEditOperationType.Edit)
            {
                DataProvider.Instance.DataBase.SaveChanges();
            }
        }

    }
}
