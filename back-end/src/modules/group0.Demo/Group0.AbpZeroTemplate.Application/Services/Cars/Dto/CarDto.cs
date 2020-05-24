
using System;

namespace Group0.AbpZeroTemplate.Application.Share.Cars.Dto
{
    /// <summary>
    /// <model cref="Car"></model>
    /// </summary>
    public class CarDto
    {
        public int Ma { get; set; }
        public string Xe_Ma { get; set; }
        public string Xe_Ten { get; set; }
        public int? Xe_LoaiXe { get; set; }
        public int? Xe_Gia { get; set; }
        public string Xe_Mau { get; set; }
        public DateTime? Xe_NgayTao { get; set; }
        public DateTime? Xe_NgayApprove { get; set; }
        public string Xe_TrangThai { get; set; }
        public string Xe_NguoiTao { get; set; }
        public int? Xe_PhieuDKDuongBo { get; set; }
        public int? Xe_PhieuDangKiem { get; set; }
        public int? Xe_BaoHiem { get; set; }
        public int? Xe_BaoHiemTuNguyen { get; set; }


    }
}
