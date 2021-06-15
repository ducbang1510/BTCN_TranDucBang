using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BTLinQ
{
    class BUS_SanPham
    {
        DAO_SanPham da;
        public BUS_SanPham()
        {
            da = new DAO_SanPham();
        }

        public void LayDSLSP(ComboBox cb)
        {
            cb.DataSource = da.LayDSLSP();
            cb.DisplayMember = "CategoryName";
            cb.ValueMember = "CategoryID";
        }

        public void LayDSNCC(ComboBox cb)
        {
            cb.DataSource = da.LayDSNCC();
            cb.DisplayMember = "CompanyName";
            cb.ValueMember = "SupplierID";
        }

        public void LayDSSP(DataGridView dg)
        {
            dg.DataSource = da.LayDSSanPham();
        }

        public void ThemSP(Product p)
        {
            if (da.ThemSP(p))
            {
                MessageBox.Show("Thêm sản phẩm thành công");
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm không thành công");
            }
        }

        public void SuaSP(Product p)
        {
            if (da.SuaSP(p))
            {
                MessageBox.Show("Sửa thông tin sản phẩm thành công");
            }
            else
            {
                MessageBox.Show("Sửa thông tin sản phẩm không thành công");
            }
        }

        public void XoaSP(int maSP)
        {
            if (da.XoaSP(maSP))
            {
                MessageBox.Show("Xóa sản phẩm thành công");
            }
            else
            {
                MessageBox.Show("Xóa sản phẩm không thành công");
            }
        }
    }
}
