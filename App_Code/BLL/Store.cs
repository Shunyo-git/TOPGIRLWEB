using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using TopGirl.DataAccessLayer;

namespace TopGirl.BusinessLogicLayer
{

    /// <summary>
    /// Store 的摘要描述
    /// </summary>
    public class Store
    {

        private int _id;
        private int _areaID;
        private string _areaName;
        private string _name;
        private string _tel;
        private string _address;
        private bool _isDisplay;
        private int _sortID;
        public Store(int ID, int AreaID, string StoreName, string Tel, string Address,bool IsDisplay )
        {
            this.ID = ID;
            this.AreaID = AreaID;
            this.StoreName = StoreName;
            this.Tel = Tel;
            this.Address = Address;
            this.IsDisplay = IsDisplay;
        }

        public Store()
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

        public int AreaID
        {
            get
            {
                return _areaID;
            }
            set
            {
                _areaID = value;
            }
        }
        public int SortID
        {
            get
            {
                return _sortID;
            }
            set
            {
                _sortID = value;
            }
        }
        

        public string StoreName
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

        public string Tel
        {
            get
            {
                return _tel;
            }
            set
            {
                _tel = value;
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }

        public string AreaName
        {
            get
            {
                return _areaName;
            }
            set
            {
                _areaName = value;
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

                return DALLayer.UpdateStore(this.ID, this.AreaID, this.StoreName, this.Tel, this.Address, this.IsDisplay);
            }
            else
            {
                ID = DALLayer.InsertStore(this.AreaID, this.StoreName, this.Tel, this.Address, this.IsDisplay);
                return (ID > 0);
            }

        }

        /*** METHOD STATIC ***/
        public static bool Remove(int ID)
        {
            if (ID > 0)
            {
                DataAccess DALLayer = DataAccessHelper.GetDataAccess();
                return DALLayer.RemoveStore(ID);
            }
            else
                return false;
        }

        public static Store GetStoreById(int ID)
        {
            if (ID <= 0)
                return (null);

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetStoreById(ID));
        }
        
        public static List<Store> GetStore()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetStore());
        }

        public static List<Store> GetStore(string sortParameter)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();

            List<Store> storeList = DALLayer.GetStore();

            if (!String.IsNullOrEmpty(sortParameter))
                storeList.Sort(new StoreComparer(sortParameter));

            return (storeList);
        }
    
        public static List<Store> GetDisplayStore()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetDisplayStore());
        }
        public static List<Store> GetDisplayStoreByArea(int AreaID)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetDisplayStoreByArea(AreaID));
        }
    }
}