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
    public partial class FSanPham : Form
    {
        BUS_SanPham busSP;
        public FSanPham()
        {
            InitializeComponent();
            busSP = new BUS_SanPham();
        }

        private void FSanPham_Load(object sender, EventArgs e)
        {
            busSP.LayDSLSP(cbLoaiSP);
            busSP.LayDSNCC(cbNCC);
            busSP.LayDSSP(dGSP);
        }

        private void dGSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dGSP.Rows.Count)
            {
                txtTenSP.Text = dGSP.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                txtSoLuong.Text = dGSP.Rows[e.RowIndex].Cells["UnitsInStock"].Value.ToString();
                txtDonGia.Text = dGSP.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString();
                cbLoaiSP.Text = dGSP.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();
                cbNCC.Text = dGSP.Rows[e.RowIndex].Cells["CompanyName"].Value.ToString();
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Product p = new Product();

            p.ProductName = txtTenSP.Text;
            p.UnitsInStock = short.Parse(txtSoLuong.Text);
            p.UnitPrice = decimal.Parse(txtDonGia.Text);
            p.CategoryID = int.Parse(cbLoaiSP.SelectedValue.ToString());
            p.SupplierID = int.Parse(cbNCC.SelectedValue.ToString());

            busSP.ThemSP(p);
            dGSP.Columns.Clear();
            busSP.LayDSSP(dGSP);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            busSP.XoaSP(int.Parse(dGSP.Rows[dGSP.CurrentRow.Index].Cells[0].Value.ToString()));
            dGSP.Columns.Clear();
            busSP.LayDSSP(dGSP);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
             Product p = new Product();

            p.ProductID = int.Parse(dGSP.Rows[dGSP.CurrentRow.Index].Cells[0].Value.ToString());
            p.ProductName = txtTenSP.Text;
            p.UnitsInStock = short.Parse(txtSoLuong.Text);
            p.UnitPrice = decimal.Parse(txtDonGia.Text);
            p.CategoryID = int.Parse(cbLoaiSP.SelectedValue.ToString());
            p.SupplierID = int.Parse(cbNCC.SelectedValue.ToString());

            busSP.SuaSP(p);
            dGSP.Columns.Clear();
            busSP.LayDSSP(dGSP);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
