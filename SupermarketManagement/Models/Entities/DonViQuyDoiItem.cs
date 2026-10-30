using System;

namespace SupermarketManagement.Models
{
    public class DonViQuyDoiItem
    {
        public string MaDVT { get; set; }
        public string TenDV { get; set; }
        public int SoLuongQuyDoi { get; set; }
        public decimal DonGiaNhapLe { get; set; }
        public decimal DonGiaBanLe { get; set; }

        public bool IsCoBan => SoLuongQuyDoi <= 1;

        public DonViQuyDoiItem()
        {
            SoLuongQuyDoi = 1;
        }

        public DonViQuyDoiItem(string maDVT, string tenDV, int soLuongQuyDoi, decimal donGiaNhapLe, decimal donGiaBanLe)
        {
            MaDVT = maDVT;
            TenDV = tenDV;
            SoLuongQuyDoi = soLuongQuyDoi <= 0 ? 1 : soLuongQuyDoi;
            DonGiaNhapLe = donGiaNhapLe;
            DonGiaBanLe = donGiaBanLe;
        }
    }
}
