using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BTLinQ
{
    class DAO_DonHang
    {
        NWDataContext db;
        public DAO_DonHang()
        {
            db = new NWDataContext();
        }
        
        // Xử lý Customer
        public dynamic LayDSKH()
        {
            dynamic ds = db.Customers.Select(s => new { s.CustomerID, s.CompanyName}).ToList();
            return ds;
        }

        // Xử lý Employee
        public dynamic LayDSNV()
        {
            var ds = db.Employees.Select(s => new { s.EmployeeID, s.LastName, s.FirstName }).ToList();
            return ds;
        }

        // Xử lý Order
        public dynamic LayDSDH()
        {
            dynamic ds = db.Orders.Select(s => new
            {
                s.OrderID,
                s.OrderDate,
                s.Customer.CompanyName,
                s.Employee.LastName
            }
                                            ).ToList();
            return ds;
        }

        public void ThemDH(Order d)
        {
            db.Orders.InsertOnSubmit(d);
            db.SubmitChanges();
        }

        public bool SuaDH(Order donHang)
        {
            bool tinhTrang = false;
            try
            {
                Order d = db.Orders.First(s => s.OrderID == donHang.OrderID);

                d.OrderDate = donHang.OrderDate;
                d.CustomerID = donHang.CustomerID;
                d.EmployeeID = donHang.EmployeeID;

                db.SubmitChanges();
                tinhTrang = true;
            }
            catch (Exception)
            {
                tinhTrang = false;
            }
            
            return tinhTrang;
        }

        public bool XoaDH(int maDH)
        {
            bool tinhTrang = true;
            try
            {
                // Xoa tat ca chi tiet don hang co OrderID = maDH
                var ds = db.Order_Details.Where(s => s.OrderID == maDH).Select(s => s);
                db.Order_Details.DeleteAllOnSubmit(ds);
                db.SubmitChanges();

                // Xoa don hang co OrderID = maDH
                Order d = db.Orders.Single(s => s.OrderID == maDH);
                db.Orders.DeleteOnSubmit(d);
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
