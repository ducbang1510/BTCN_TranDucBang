using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BTLinQ
{
    class BUS_NhanVien
    {
        DAO_NhanVien da;
        public BUS_NhanVien()
        {
            da = new DAO_NhanVien();
        }

        public void LayDSNV(DataGridView dg)
        {
            dg.DataSource = da.LayDSNV();
        }

        public void ThemNhanVien(Employee e)
        {
            if(da.ThemNhanVien(e))
            {
                MessageBox.Show("Thêm nhân viên thành công");
            }
            else
            {
                MessageBox.Show("Thêm nhân viên không thành công");
            }
        }

        public void SuaNhanVien(Employee e)
        {
            if (da.SuaNhanVien(e))
            {
                MessageBox.Show("Sửa thông tin nhân viên thành công");
            }
            else
            {
                MessageBox.Show("Sửa thông tin nhân viên không thành công");
            }
        }

        public void XoaNhanVien(int maNV)
        {
            if (da.XoaNhanVien(maNV))
            {
                MessageBox.Show("Xóa nhân viên thành công");
            }
            else
            {
                MessageBox.Show("Xóa nhân viên không thành công");
            }
        }
    }
}
