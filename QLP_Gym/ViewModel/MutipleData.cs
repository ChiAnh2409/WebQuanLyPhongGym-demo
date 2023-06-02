using QLP_Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLP_Gym.ViewModel
{


    public class MultipleData
    {
        // Các thuộc tính tương ứng với các bảng dữ liệu
        public IEnumerable<Account> Account { get; set; }
        public IEnumerable<Roles> Roles { get; set; }
        public IEnumerable<HoiVien> hoiViens { get; set; }
        public IEnumerable<ThanhVien> thanhViens { get; set; }
        public IEnumerable<GoiTap> goiTap { get; set; }
        public IEnumerable<ChiTietDK_GoiTap> chiTietDK_goiTap { get; set; }
        public IEnumerable<BaoCaoDoanhThu> baoCaoDoanhThus { get; set; }
        public IEnumerable<ChiTietBaoCao> chiTietBaoCaos { get; set; }
    }
}