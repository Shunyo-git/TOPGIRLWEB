using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using TopGirl.DataAccessLayer;

namespace TopGirl.BusinessLogicLayer
{

    /// <summary>
    /// Category 的摘要描述
    /// </summary>
    public class Category
    {
        private int _id;
        private string _name;
        private bool _isDisplay;
        private bool _isHomePageDisplay;
        private int _sortId;
        public Category(int ID, string Name, bool IsDisplay, bool IsHomePageDisplay, int SortID)
        {
            this.ID = ID;
            this.Name = Name;
            this.IsDisplay = IsDisplay;
            this.IsHomePageDisplay = IsHomePageDisplay;
            this.SortID = SortID;
        }
        public Category()
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
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
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
        public bool IsHomePageDisplay
        {
            get
            {
                return _isHomePageDisplay;
            }
            set
            {
                _isHomePageDisplay = value;
            }
        }
         public int SortID
        {
            get
            {
                return _sortId;
            }
            set
            {
                _sortId = value;
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

                return DALLayer.UpdateCategory(this.ID, this.Name,  this.IsDisplay, this.IsHomePageDisplay ,this.SortID);
            }
            else
            {
                ID = DALLayer.InsertCategory(this.Name, this.IsDisplay, this.IsHomePageDisplay, this.SortID);
                return (ID > 0);
            }

        }

        /*** METHOD STATIC ***/
        public static bool Remove(int ID)
        {
            if (ID > 0)
            {
                DataAccess DALLayer = DataAccessHelper.GetDataAccess();
                return DALLayer.RemoveCategory(ID);
            }
            else
                return false;
        }

        public static Category GetCategoryById(int ID)
        {
            if (ID <= 0)
                return (null);

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetCategoryById(ID));
        }
        public static Category GetFirstDisplayCategory()
        {

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetFirstDisplayCategory());
        }
        public static List<Category> GetCategory()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetCategory());
        }
        public static List<Category> GetCategory(string sortParameter)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();

            List<Category> categoryList = DALLayer.GetCategory();

            if (!String.IsNullOrEmpty(sortParameter))
                categoryList.Sort(new CategoryComparer(sortParameter));

            return (categoryList);
        }

       

        public static List<Category> GetDisplayCategory()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetDisplayCategory());
        }
        public static List<Category> GetHomePageDisplayCategory()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetHomePageDisplayCategory());
        }
    }
}