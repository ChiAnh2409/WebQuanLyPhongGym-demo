//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLP_Gym.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietBaoCao
    {
        public int id_CTBC { get; set; }
        public Nullable<int> id_BC { get; set; }
        public Nullable<int> id_HV { get; set; }
        public Nullable<int> id_GT { get; set; }
        public Nullable<decimal> TongTien { get; set; }
    
        public virtual BaoCaoDoanhThu BaoCaoDoanhThu { get; set; }
        public virtual GoiTap GoiTap { get; set; }
        public virtual HoiVien HoiVien { get; set; }
    }
}