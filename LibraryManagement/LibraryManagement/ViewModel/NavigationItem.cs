using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModel
{
    class NavigationItem
    {
        public string Title { get; set; }
        public string IconGlyph { get; set; }
        public BaseViewModel ViewContent { get; set; }
    }
}
