using System.Collections.ObjectModel;

namespace LibraryManagement.ViewModel
{
    class MainViewModel
    {
        public ObservableCollection<NavigationItem> Items { get; set; } = new ObservableCollection<NavigationItem>();

        public MainViewModel()
        {
            Items.Add(new NavigationItem() { Title = "Quản Lý Đọc Giả", IconGlyph = "&#xe801", ViewContent = new ReaderViewModel() });
            Items.Add(new NavigationItem() { Title = "Quản Lý Sách", IconGlyph = "&#xe651", ViewContent = null });
            Items.Add(new NavigationItem() { Title = "Quản Lý Mượn Trả Sách", IconGlyph = "&#xe649", ViewContent = null });
            Items.Add(new NavigationItem() { Title = "Quy Định", IconGlyph = "&#xe401", ViewContent = null });
        }
    }
}
