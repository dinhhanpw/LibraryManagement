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
    
    public partial class CTPhieuMuon
    {
        public int IdPhieuMuon { get; set; }
        public int IdSach { get; set; }
        public Nullable<System.DateTime> NgayTra { get; set; }
    
        public virtual PhieuMuon PhieuMuon { get; set; }
        public virtual Sach Sach { get; set; }
    }
}
