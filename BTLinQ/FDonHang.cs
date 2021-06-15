using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BTLinQ
{
    public partial class FDonHang : Form
    {
        BUS_DonHang busDH;
        public FDonHang()
        {
            InitializeComponent();
            busDH = new BUS_DonHang();
        }

        private void FDonHang_Load(object sender, EventArgs e)
        {
            CapNhatDG();

            busDH.LayDSKH(cbKhachHang);
            busDH.LayDSNV(cbNhanVien);
        }

        private void CapNhatDG()
        {
            busDH.LayDSDH(gVDH);
            gVDH.Columns[0].Width = (int)(0.2 * gVDH.Width);
            gVDH.Columns[1].Width = (int)(0.2 * gVDH.Width);
            gVDH.Columns[2].Width = (int)(0.25 * gVDH.Width);
            gVDH.Columns[3].Width = (int)(0.25 * gVDH.Width);
        }

        private void gVDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVDH.Rows.Count)
            {
                txtMaDH.Text = gVDH.Rows[e.RowIndex].Cells["OrderID"].Value.ToString();
                dtpNgayDH.Text = gVDH.Rows[e.RowIndex].Cells["OrderDate"].Value.ToString();
                cbKhachHang.Text = gVDH.Rows[e.RowIndex].Cells["CompanyName"].Value.ToString();
                cbNhanVien.Text = gVDH.Rows[e.RowIndex].Cells["LastName"].Value.ToString();
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Order d = new Order();

            d.OrderDate = dtpNgayDH.Value;
            d.CustomerID = cbKhachHang.SelectedValue.ToString();
            d.EmployeeID = int.Parse(cbNhanVien.SelectedValue.ToString());

            busDH.ThemDH(d);

            gVDH.Columns.Clear();
            CapNhatDG();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            Order d = new Order();

            d.OrderID = int.Parse(txtMaDH.Text);
            d.OrderDate = dtpNgayDH.Value;
            d.CustomerID = cbKhachHang.SelectedValue.ToString();
            d.EmployeeID = int.Parse(cbNhanVien.SelectedValue.ToString());

            busDH.SuaDH(d);

            gVDH.Columns.Clear();
            CapNhatDG();
        }

        private void gVDH_DoubleClick(object sender, EventArgs e)
        {
            int maDH;
            maDH = int.Parse(gVDH.CurrentRow.Cells["OrderID"].Value.ToString());
            //goi Form
            FChiTietDonHang c = new FChiTietDonHang();
            //truyen bien
            c.maDonHang = maDH;
            c.ShowDialog();
        }

        private void ThemCTDH_Click(object sender, EventArgs e)
        {
            FDatHang f = new FDatHang();
            f.maDH = int.Parse(gVDH.CurrentRow.Cells[0].Value.ToString());
            f.ShowDialog();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if(txtMaDH.Text != "")
            {
                busDH.XoaDH(int.Parse(txtMaDH.Text));
                gVDH.Columns.Clear();
                CapNhatDG();
            }
            else
            {
                MessageBox.Show("Chưa chọn đơn hàng để xóa");
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FSanPham f = new FSanPham();
            f.ShowDialog();
        }

        private void quanLyNhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FNhanVien f = new FNhanVien();
            f.ShowDialog();
        }
    }
}
