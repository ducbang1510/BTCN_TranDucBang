using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BTLinQ
{
    class BUS_DonHang
    {
        DAO_DonHang da;
        public BUS_DonHang()
        {
            da = new DAO_DonHang();
        }

        // Phần xử lý khách hàng
        public void LayDSKH(ComboBox cb)
        {
            cb.DisplayMember = "CompanyName";
            cb.ValueMember = "CustomerID";
            cb.DataSource = da.LayDSKH();
        }

        // Phần xử lý nhân viên
        public void LayDSNV(ComboBox cb)
        {
            cb.DisplayMember = "LastName";
            cb.ValueMember = "EmployeeID";
            cb.DataSource = da.LayDSNV();
        }

        // Phần xử lý đơn hàng
        public void LayDSDH(DataGridView dg)
        {
            dg.DataSource = da.LayDSDH();
        }

        public void ThemDH(Order d)
        {
            try
            {
                da.ThemDH(d);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void SuaDH(Order donHang)
        {
            if (da.SuaDH(donHang))
            {
                MessageBox.Show("Sửa đơn hàng thành công");
            }
            else
            {
                MessageBox.Show("Không thấy đơn hàng để sửa");
            }
        }

        public void XoaDH(int maDH)
        {
            if (da.XoaDH(maDH))
            {
                MessageBox.Show("Xóa đơn hàng thành công");
            }
            else
            {
                MessageBox.Show("Không thấy đơn hàng để xóa");
            }
        }
    }
}
