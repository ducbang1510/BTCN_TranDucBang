using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BTLinQ
{
    class BUS_CTDonHang
    {
        DAO_CTDonHang da;

        DAO_SanPham ds;
        public BUS_CTDonHang()
        {
            da = new DAO_CTDonHang();
            ds = new DAO_SanPham();
        }

        private DataTable InitDG()
        {
            DataTable dtCTDH = new DataTable();

            dtCTDH.Columns.Add("OrderID");
            dtCTDH.Columns.Add("ProductID");
            dtCTDH.Columns.Add("UnitPrice");
            dtCTDH.Columns.Add("Quantity");
            dtCTDH.Columns.Add("Discount");

            return dtCTDH;
        }

        // Phần xử lý sản phẩm
        public void LayDSSP(ComboBox cb)
        {
            cb.DataSource = ds.LayDSSanPham();
            cb.DisplayMember = "ProductName";
            cb.ValueMember = "ProductID";
        }

        public Product HienThiDSSP2(int maSP)   // Hiển thị danh sách sản phẩm theo Product mặc định
        {
            var s = ds.LayThongTinSanPham2(maSP);

            return s;
        }

        public ProductModel HienThiDSSP(int maSP)   // Hiển thị danh sách sản phẩm theo ProductModel tự định nghĩa
        {
            var s = ds.LayThongTinSanPham(maSP);

            return s;
        }

        // Phần xử lý CTDH
        public void HienThiCTDH(DataGridView dg, int maDH)
        {
            var ds = da.HienThiCTDH(maDH);
            if (ds != null)
            {
                dg.DataSource = da.HienThiCTDH(maDH);
            }
            else
            {
                dg.DataSource = InitDG();
            }
        }

        public void ThemDanhSachCTDH(List<Order_Detail> list)
        {
            if (da.ThemDanhSachCTDH(list))
            {
                MessageBox.Show("Đặt hàng thành công");
            }
            else
            {
                MessageBox.Show("Đặt hàng không thành công");
            }
        }

        public void SuaCTDH(Order_Detail d)
        {
            if (da.SuaCTDH(d))
            {
                MessageBox.Show("Sửa chi tiết đơn hàng thành công");
            }
            else
            {
                MessageBox.Show("Không thấy chi tiết đơn hàng để sửa");
            }
        }

        public void XoaCTDH(int maDH, int maSP)
        {
            if (da.XoaCTDH(maDH, maSP))
            {
                MessageBox.Show("Xóa CTDH thành công");
            }
            else
            {
                MessageBox.Show("Xóa CTDH không thành công");
            }
        }
    }
}
