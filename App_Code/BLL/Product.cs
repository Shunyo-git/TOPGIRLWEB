using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using TopGirl.DataAccessLayer;

namespace TopGirl.BusinessLogicLayer
{
    /// <summary>
    /// Product 的摘要描述
    /// </summary>
    public class Product
    {
        private int _id;
        private int _categoryID;
        private string _sku;
        private bool _isDisplay;
        private string _fileName_main;
        private string _fileName_thumb;

        public Product(int ID,int CategoryID,string SKU,bool IsDisplay ,string FileName_Main,string FileName_Thumb)

        {
            this.ID = ID;
            this.CategoryID = CategoryID;
            this.SKU = SKU;
            this.IsDisplay = IsDisplay;
            this.FileName_Main = FileName_Main;
            this.FileName_Thumb = FileName_Thumb;
        }
        public Product( )
        {
     
        }
        
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public int CategoryID
        {
            get
            {
                return _categoryID;
            }
            set
            {
                _categoryID = value;
            }
        }

        public string SKU
        {
            get
            {
                return _sku;
            }
            set
            {
                _sku = value;
            }
        }

        public bool IsDisplay
        {
            get
            {
                return _isDisplay;
            }
            set
            {
                _isDisplay = value;
            }
        }

        public string FileName_Main
        {
            get
            {
                return _fileName_main;
            }
            set
            {
                _fileName_main = value;
            }
        }

        public string FileName_Thumb
        {
            get
            {
                return _fileName_thumb;
            }
            set
            {
                _fileName_thumb = value;
            }
        }


        /*** METHODS  ***/
        public bool Remove()
        {

            return Remove(this.ID);
        }

        public bool Save()
        {

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            if (ID > 0)
            {

                return DALLayer.UpdateProduct(this.ID,this.CategoryID,this.SKU,this.IsDisplay,this.FileName_Main,this.FileName_Thumb);
            }
            else
            {
                ID = DALLayer.InsertProduct(this.CategoryID, this.SKU, this.IsDisplay, this.FileName_Main, this.FileName_Thumb);
                return (ID > 0);
            }

        }

        /*** METHOD STATIC ***/
        public static bool Remove(int ID)
        {
            if (ID > 0)
            {
                DataAccess DALLayer = DataAccessHelper.GetDataAccess();
                return DALLayer.RemoveProduct(ID);
            }
            else
                return false;
        }

        public static Product GetProductById(int ID)
        {
            if (ID <= 0)
                return (null);

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetProductById(ID));
        }
        public static Product GetLastDisplayProduct()
        {

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetLastDisplayProduct());
        }
        public static List<Product> GetProduct()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetProduct());
        }
        public static List<Product> GetProduct(string sortParameter)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();

            List<Product> productList = DALLayer.GetProduct();

            if (!String.IsNullOrEmpty(sortParameter))
                productList.Sort(new ProductComparer(sortParameter));

            return (productList);
        }

      

        public static List<Product> GetProductByCategoryID(int CategoryID)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetProductByCategoryID(CategoryID));
        }
        public static List<Product> GetDisplayProduct()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetDisplayProduct());
        }
        public static List<Product> GetDisplayProductByCategoryID(int CategoryID)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetDisplayProductByCategoryID(CategoryID));
        }
        
    }
}