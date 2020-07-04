using Aspose.Cells;
using LibraryManagement.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
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
        public ICommand ExportCommand { get; set; }
        public ObservableCollection<DocGia> Readers { get; set; }
        public DocGia SelectedReader
        {
            get { return _selectedReader; }
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
            ExportCommand = new RelayCommand<Object>(obj => true, OnExport);
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
                Ten = reader.Ten,
                IdLoai = reader.Id,
                NgaySinh = reader.NgaySinh,
                DiaChi = reader.DiaChi,
                Email = reader.Email,
                NgayLap = reader.NgayLap,
            };

            DataProvider.Instance.DataBase.DocGias.Add(docGia);
            DataProvider.Instance.DataBase.SaveChanges();

            Readers.Add(docGia);
        }

        void OnEdit(DocGia reader)
        {
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

            if (args.EditOperationType == GridViewEditOperationType.Insert)
            {
                DataProvider.Instance.DataBase.DocGias.Add(args.NewData as DocGia);
                DataProvider.Instance.DataBase.SaveChanges();
            }
            else if (args.EditOperationType == GridViewEditOperationType.Edit)
            {
                DataProvider.Instance.DataBase.SaveChanges();
            }
        }

        void OnExport(Object obj)
        {
            int count = Readers.Count;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel file (*.xlsx)|*.xlsx";
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Workbook workbook = new Workbook();
                Worksheet worksheet = workbook.Worksheets[0];

                SetHeader(worksheet);

                for (int i = 0; i < count; ++i)
                {
                    SetValueOnRowWorksheet(worksheet, Readers[i], i + 3);
                }

                workbook.Save(dialog.FileName, SaveFormat.Xlsx);
            }
        }

        private void SetHeader(Worksheet worksheet)
        {
            char startCol = 'A';
            int row = 2;

            Cell cell = worksheet.Cells[$"{startCol}{row}"];
            cell.PutValue("STT");
            cell = worksheet.Cells[$"{(char)(startCol + 1)}{row}"];
            cell.PutValue("Họ Và Tên");
            cell = worksheet.Cells[$"{(char)(startCol + 2)}{row}"];
            cell.PutValue("Loại Đọc Giả");
            cell = worksheet.Cells[$"{(char)(startCol + 3)}{row}"];
            cell.PutValue("Ngày Sinh");
            cell = worksheet.Cells[$"{(char)(startCol + 4)}{row}"];
            cell.PutValue("Địa Chỉ");
            cell = worksheet.Cells[$"{(char)(startCol + 5)}{row}"];
            cell.PutValue("Email");
            cell = worksheet.Cells[$"{(char)(startCol + 6)}{row}"];
            cell.PutValue("Ngày Lập Thẻ");
        }

        private void SetValueOnRowWorksheet(Worksheet worksheet, DocGia reader, int row, char startCol = 'A')
        {
            Cell cell = worksheet.Cells[$"{(char)(startCol)}{row}"];
            cell.PutValue(row - 2);
            cell = worksheet.Cells[$"{(char)(startCol + 1)}{row}"];
            cell.PutValue(reader.Ten);
            cell = worksheet.Cells[$"{(char)(startCol + 2)}{row}"];
            cell.PutValue(reader.LoaiDocGia.Ten);
            cell = worksheet.Cells[$"{(char)(startCol + 3)}{row}"];
            cell.PutValue(reader.NgaySinh.ToString("MM/dd/yyyy"));
            cell = worksheet.Cells[$"{(char)(startCol + 4)}{row}"];
            cell.PutValue(reader.DiaChi);
            cell = worksheet.Cells[$"{(char)(startCol + 5)}{row}"];
            cell.PutValue(reader.Email);
            cell = worksheet.Cells[$"{(char)(startCol + 6)}{row}"];
            cell.PutValue(reader.NgayLap.ToString("MM/dd/yyyy"));
        }

    }
}
