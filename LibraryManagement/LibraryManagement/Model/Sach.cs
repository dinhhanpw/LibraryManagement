//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryManagement.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            this.CTPhieuMuons = new HashSet<CTPhieuMuon>();
        }
    
        public int Id { get; set; }
        public string Ten { get; set; }
        public Nullable<int> IdLoai { get; set; }
        public string TacGia { get; set; }
        public Nullable<int> NamXB { get; set; }
        public string NhaXB { get; set; }
        public Nullable<System.DateTime> NgayNhap { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<int> Gia { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPhieuMuon> CTPhieuMuons { get; set; }
        public virtual LoaiSach LoaiSach { get; set; }
    }
}
