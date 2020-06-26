using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModel
{
    public class ReaderViewModel : BaseViewModel
    {
        public ObservableCollection<DocGia> Readers { get; set; }
        public DocGia Holder { get; set; }

        public ReaderViewModel()
        {
            Readers = new ObservableCollection<DocGia>(DataProvider.Instance.DocGias);
            Holder = new DocGia();
        }
    }
}
