using System.Collections.ObjectModel;

namespace LibraryManagement.ViewModel
{
    class MainViewModel
    {
        public ObservableCollection<NavigationItem> Items { get; set; } = new ObservableCollection<NavigationItem>();

        public MainViewModel()
        {
            Items.Add(new NavigationItem() { Title = "Quản Lý Đọc Giả", IconGlyph = "&#xe801", Content = null });
            Items.Add(new NavigationItem() { Title = "Quản Lý Sách", IconGlyph = "&#xe651", Content = null });
            Items.Add(new NavigationItem() { Title = "Quản Lý Mượn Trả Sách", IconGlyph = "&#xe649", Content = null });
            Items.Add(new NavigationItem() { Title = "Quy Định", IconGlyph = "&#xe401", Content = null });
        }
    }
}
