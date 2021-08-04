using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFGenerate
{
   public class ProductInfoAdapter
    {
        public int _SL_no;
        public string _ProductName;
        public int _Quantity;
        public int _UnitPrice;
        public int _Discount;
        public int _Mrp;
        public int _Total;
        public string _Description;



        public int SL_No
        {
            get
            {
                return this._SL_no;
            }
            set
            {
                this._SL_no = value;
            }

        }

        public string ProductName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                this._ProductName = value;
            }

        }
        public int Quantity
        {
            get
            {
                return this._Quantity;
            }
            set
            {
                this._Quantity = value;
            }

        }
        public int UnitPrice
        {
            get
            {
                return this._UnitPrice;
            }
            set
            {
                this._UnitPrice = value;
            }

        }

        public int Discount
        {
            get
            {
                return this._Discount;
            }
            set
            {
                this._Discount = value;
            }

        }


        public int MRP
        {
            get
            {
                return this._Mrp;
            }
            set
            {
                this._Mrp = value;
            }

        }

        public int Total
        {
            get
            {
                return this._Total;
            }
            set
            {
                this._Total = value;
            }

        }

        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
            }

        }


        public ProductInfoAdapter()
        {

        }
        public ProductInfoAdapter(int sl_no, string name)
        {
            this.SL_No = sl_no;
            this.ProductName = name;
        }

        public ProductInfoAdapter(int sl_no, string name, int quantity, int unitprice, int discount, int mrp)
        {
            this.SL_No = sl_no;
            this.ProductName = name;
            this.Quantity = quantity;
            this.UnitPrice = unitprice;
            this.Discount = discount;
            this.MRP = mrp;

        }

        public ProductInfoAdapter(int sl_no, string name, int quantity, int mrp, int total, string description)
        {
            this.SL_No = sl_no;
            this.ProductName = name;
            this.Quantity = quantity;
            this.MRP = mrp;
            this.Total = total;
            this.Description = description;

        }


        public static List<ProductInfoAdapter> ProductInfoAdapterList()
        {
            List<ProductInfoAdapter> productInfoAdapters = new List<ProductInfoAdapter>();

            
            productInfoAdapters.Add(new ProductInfoAdapter(1, "LARGE VANILLA CUP 75ML", 1,  280,280, "large vanilla Description1,large vanilla Description2,large vanilla Description3"));
           productInfoAdapters.Add(new ProductInfoAdapter(2, "CANDY STRAWBERRY 70ML",3,  210,630, "CANDY Strawberry Description1"));
           productInfoAdapters.Add(new ProductInfoAdapter(3, "STRAWBERRY DUET 70ML", 2, 320, 640, "Strawberry Description"));
            productInfoAdapters.Add(new ProductInfoAdapter(4, "VANILLA CONE 50ML", 1, 10, 10, "vanilla cone Description"));

            productInfoAdapters.Add(new ProductInfoAdapter(5, "LARGE VANILLA CUP 75ML", 1, 280, 280, "large vanilla Description1,large vanilla Description2,large vanilla Description3,large vanilla Description4,"));
            productInfoAdapters.Add(new ProductInfoAdapter(2, "CANDY STRAWBERRY 70ML", 3, 210, 630, "CANDY Strawberry Description1"));
            productInfoAdapters.Add(new ProductInfoAdapter(3, "STRAWBERRY DUET 70ML", 2, 320, 640, "Strawberry Description"));
            //productInfoAdapters.Add(new ProductInfoAdapter(4, "VANILLA CONE 50ML", 1, 10, 10, "vanilla cone Description"));

            return productInfoAdapters;
        }

    }
}
