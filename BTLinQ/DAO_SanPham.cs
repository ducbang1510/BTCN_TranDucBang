using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BTLinQ
{
    class DAO_SanPham
    {
        NWDataContext db;
        public DAO_SanPham()
        {
            db = new NWDataContext();
        }

        public dynamic LayDSLSP()
        {
            var ds = db.Categories.Select(s => new
            {
                s.CategoryID,
                s.CategoryName
            });

            return ds;
        }

        public dynamic LayDSNCC()
        {
            var ds = db.Suppliers.Select(s => new
            {
                s.SupplierID,
                s.CompanyName
            });

            return ds;
        }

        public dynamic LayDSSanPham()
        {
            var ds = db.Products.Select(s => new
            {
                s.ProductID,
                s.ProductName,
                s.UnitPrice,
                s.UnitsInStock,
                s.Category.CategoryName,
                s.Supplier.CompanyName
            });

            return ds;
        }

        public bool ThemSP(Product p)
        {
            bool tinhTrang = false;
            try
            {
                db.Products.InsertOnSubmit(p);
                db.SubmitChanges();
                tinhTrang = true;
            }
            catch (Exception)
            {
                tinhTrang = false;
            }

            return tinhTrang;
        }

        public bool SuaSP(Product p)
        {
            bool tinhTrang = false;
            try
            {
                Product product = db.Products.First(s => s.ProductID == p.ProductID);

                product.ProductName = p.ProductName;
                product.UnitsInStock = p.UnitsInStock;
                product.UnitPrice = p.UnitPrice;
                product.CategoryID = p.CategoryID;
                product.SupplierID = p.SupplierID;

                db.SubmitChanges();
                tinhTrang = true;
            }
            catch (Exception)
            {
                tinhTrang = false;
            }

            return tinhTrang;
        }

        public bool XoaSP(int maSP)
        {
            bool tinhTrang = true;
            try
            {
                Product p = db.Products.Single(s => s.ProductID == maSP);
                db.Products.DeleteOnSubmit(p);
                db.SubmitChanges();

                tinhTrang = true;
            }
            catch (Exception)
            {
                tinhTrang = false;
            }

            return tinhTrang;
        }

        // Lấy thông tin sản phẩm theo model tự định nghĩa
        public ProductModel LayThongTinSanPham(int maSP)
        {
            ProductModel sp = db.Products
                .Where(s => s.ProductID == maSP)
                .Select(s => new ProductModel()
                {
                    ProductID = s.ProductID,
                    ProductName = s.ProductName,
                    UnitPrice = s.UnitPrice,
                    CategoryName = s.Category.CategoryName,
                    CompanyName = s.Supplier.CompanyName
                }).FirstOrDefault();

            return sp;
        }

        // Lấy thông tin sản phẩm theo model Product mặc định
        public Product LayThongTinSanPham2(int maSP)
        {
            Product sp = db.Products.FirstOrDefault(s => s.ProductID == maSP);

            return sp;
        }
    }
}

// class ProductModel tự định nghĩa
public class ProductModel
{
    private int productID;
    private string productName;
    private System.Nullable<decimal> unitPrice;
    private string categoryName;
    private string companyName;

    public decimal? UnitPrice { get => unitPrice; set => unitPrice = value; }
    public string CategoryName { get => categoryName; set => categoryName = value; }
    public string CompanyName { get => companyName; set => companyName = value; }
    public int ProductID { get => productID; set => productID = value; }
    public string ProductName { get => productName; set => productName = value; }
}