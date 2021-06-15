using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BTLinQ
{
    class DAO_NhanVien
    {
        NWDataContext db;
        public DAO_NhanVien()
        {
            db = new NWDataContext();
        }
        
        public dynamic LayDSNV()
        {
            var ds = db.Employees.Select(s => new
            {
                s.EmployeeID,
                s.LastName,
                s.FirstName,
                s.BirthDate,
                s.Address,
                s.HomePhone
            });

            return ds;
        }

        public bool ThemNhanVien(Employee e)
        {
            bool tinhTrang = false;
            try
            {
                db.Employees.InsertOnSubmit(e);
                db.SubmitChanges();
                tinhTrang = true;
            }
            catch (Exception)
            {
                tinhTrang = false;
            }

            return tinhTrang;
        }

        public bool SuaNhanVien(Employee e)
        {
            bool tinhTrang = false;
            try
            {
                Employee nv = db.Employees.First(s => s.EmployeeID == e.EmployeeID);

                nv.FirstName = e.FirstName;
                nv.LastName = e.LastName;
                nv.HomePhone = e.HomePhone;
                nv.BirthDate = e.BirthDate;
                nv.Address = e.Address;

                db.SubmitChanges();
                tinhTrang = true;
            }
            catch (Exception)
            {
                tinhTrang = false;
            }

            return tinhTrang;
        }

        public bool XoaNhanVien(int maNV)
        {
            bool tinhTrang = true;
            try
            {
                Employee nv = db.Employees.Single(s => s.EmployeeID == maNV);
                db.Employees.DeleteOnSubmit(nv);
                db.SubmitChanges();

                tinhTrang = true;
            }
            catch (Exception)
            {
                tinhTrang = false;
            }

            return tinhTrang;
        }
    }
}
