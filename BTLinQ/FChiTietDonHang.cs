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
    public partial class FChiTietDonHang : Form
    {
        public int maDonHang;
        private BUS_CTDonHang busCTDH; 
        public FChiTietDonHang()
        {
            InitializeComponent();
            busCTDH = new BUS_CTDonHang();
        }
        

        private void HieuChinhDG()
        {
            gVCTDH.Columns[0].Width = (int)(0.15 * gVCTDH.Width);
            gVCTDH.Columns[1].Width = (int)(0.15 * gVCTDH.Width);
            gVCTDH.Columns[2].Width = (int)(0.2 * gVCTDH.Width);
            gVCTDH.Columns[3].Width = (int)(0.2 * gVCTDH.Width);
            gVCTDH.Columns[4].Width = (int)(0.2 * gVCTDH.Width);
        }

        private void CTDH_Load(object sender, EventArgs e)
        {
            txtMaDH.Text = maDonHang.ToString();

            busCTDH.HienThiCTDH(gVCTDH, maDonHang);
            HieuChinhDG();
        }

        private void gVCTDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVCTDH.Rows.Count)
            {
                txtMaDH.Text = gVCTDH.Rows[e.RowIndex].Cells["OrderID"].Value.ToString();
                txtMaSP.Text = gVCTDH.Rows[e.RowIndex].Cells["ProductID"].Value.ToString();
                txtDonGia.Text = gVCTDH.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString();
                txtSoLuong.Text = gVCTDH.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
                txtDiscount.Text = gVCTDH.Rows[e.RowIndex].Cells["Discount"].Value.ToString();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int maDH = int.Parse(gVCTDH.CurrentRow.Cells["OrderID"].Value.ToString());
            int maSP = int.Parse(gVCTDH.CurrentRow.Cells["ProductID"].Value.ToString());
            busCTDH.XoaCTDH(maDH, maSP);
            // load lại data
            gVCTDH.Columns.Clear();
            busCTDH.HienThiCTDH(gVCTDH, maDonHang);
            HieuChinhDG();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            Order_Detail d = new Order_Detail();

            d.OrderID = int.Parse(txtMaDH.Text);
            d.ProductID = int.Parse(txtMaSP.Text);
            d.Quantity = short.Parse(txtSoLuong.Text);
            d.UnitPrice = decimal.Parse(txtDonGia.Text);
            d.Discount = float.Parse(txtDiscount.Text);

            busCTDH.SuaCTDH(d);

            gVCTDH.Columns.Clear();
            busCTDH.HienThiCTDH(gVCTDH, maDonHang);
            HieuChinhDG();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
