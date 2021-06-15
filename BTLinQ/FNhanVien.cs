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
    public partial class FNhanVien : Form
    {
        BUS_NhanVien busNV;
        public FNhanVien()
        {
            InitializeComponent();
            busNV = new BUS_NhanVien();
        }

        private void FNhanVien_Load(object sender, EventArgs e)
        {
            busNV.LayDSNV(dGNhanVien);
        }

        private void dGNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dGNhanVien.Rows.Count)
            {
                txtHoten.Text = dGNhanVien.Rows[e.RowIndex].Cells["LastName"].Value.ToString() + " " + dGNhanVien.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
                txtDiaChi.Text = dGNhanVien.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                txtDienThoai.Text = dGNhanVien.Rows[e.RowIndex].Cells["HomePhone"].Value.ToString();
                dtpNgaySinh.Text = dGNhanVien.Rows[e.RowIndex].Cells["BirthDate"].Value.ToString();
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            string[] name = txtHoten.Text.Split(' ');
            string firstname = "";

            for (int i = 1; i < name.Length; i++)
                firstname += name[i] + " ";

            Employee nv = new Employee();
            nv.FirstName = firstname.Trim();
            nv.LastName = name[0];
            nv.BirthDate = DateTime.Parse(dtpNgaySinh.Value.ToShortDateString());
            nv.HomePhone = txtDienThoai.Text;
            nv.Address = txtDiaChi.Text;

            busNV.ThemNhanVien(nv);
            dGNhanVien.Columns.Clear();
            busNV.LayDSNV(dGNhanVien);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            busNV.XoaNhanVien(int.Parse(dGNhanVien.Rows[dGNhanVien.CurrentRow.Index].Cells[0].Value.ToString()));
            dGNhanVien.Columns.Clear();
            busNV.LayDSNV(dGNhanVien);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string[] name = txtHoten.Text.Split(' ');
            string firstname = "";

            for (int i = 1; i < name.Length; i++)
                firstname += name[i] + " ";

            Employee nv = new Employee();
            nv.EmployeeID = int.Parse(dGNhanVien.Rows[dGNhanVien.CurrentRow.Index].Cells[0].Value.ToString());
            nv.FirstName = firstname.Trim();
            nv.LastName = name[0];
            nv.BirthDate = DateTime.Parse(dtpNgaySinh.Value.ToShortDateString());
            nv.HomePhone = txtDienThoai.Text;
            nv.Address = txtDiaChi.Text;

            busNV.SuaNhanVien(nv);
            dGNhanVien.Columns.Clear();
            busNV.LayDSNV(dGNhanVien);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
