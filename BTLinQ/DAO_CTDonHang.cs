using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BTLinQ
{
    class DAO_CTDonHang
    {
        NWDataContext db;
        public DAO_CTDonHang()
        {
            db = new NWDataContext();
        }

        public dynamic HienThiCTDH(int maDH)
        {
            dynamic ds;

            ds = db.Order_Details.Where(s => s.OrderID == maDH)
                .Select(s => new
                {
                    s.OrderID,
                    s.ProductID,
                    s.UnitPrice,
                    s.Quantity,
                    s.Discount
                });

            return ds;
        }

        public bool ThemDanhSachCTDH(List<Order_Detail> ds)
        {
            bool tinhTrang = true;
            try
            {
                db.Order_Details.InsertAllOnSubmit(ds);
                db.SubmitChanges();

                tinhTrang = true;
            }
            catch (Exception)
            {
                tinhTrang = false;
                throw;
            }

            return tinhTrang;
        }

        public bool SuaCTDH(Order_Detail d)
        {
            bool tinhTrang = false;
            try
            {
                Order_Detail ct = db.Order_Details.First(s => s.OrderID == d.OrderID && s.ProductID == d.ProductID);

                ct.Quantity = d.Quantity;
                ct.UnitPrice = d.UnitPrice;
                ct.Discount = d.Discount;

                db.SubmitChanges();
                tinhTrang = true;
            }
            catch (Exception)
            {
                tinhTrang = false;
            }
            return tinhTrang;
        }

        public bool XoaCTDH(int maDH, int maSP)
        {
            bool tinhTrang = true;
            try
            {
                // Xoa chi tiet don hang co OrderID = maDH va ProductID = maSP
                Order_Detail d = db.Order_Details.Single(s => s.OrderID == maDH && s.ProductID == maSP);
                db.Order_Details.DeleteOnSubmit(d);
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
