using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using TopGirl.DataAccessLayer;

namespace TopGirl.BusinessLogicLayer
{

    /// <summary>
    /// MiniSite 的摘要描述
    /// </summary>
    public class MiniSite
    {
        private int _id;
     
        private string _url;
        private bool _isDisplay;
        private int _sortId;

        public MiniSite(int ID, string URL, bool IsDisplay , int SortID)
        {
            this.ID = ID;
            this.URL = URL;
            this.IsDisplay = IsDisplay;
            this.SortID = SortID;
   
        }
        public MiniSite()
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
        public string URL
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
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

                return DALLayer.UpdateMiniSite(this.ID, this.URL, this.IsDisplay, this.SortID);
            }
            else
            {
                ID = DALLayer.InsertMiniSite(this.URL, this.IsDisplay, this.SortID);
                return (ID > 0);
            }

        }

        /*** METHOD STATIC ***/
        public static bool Remove(int ID)
        {
            if (ID > 0)
            {
                DataAccess DALLayer = DataAccessHelper.GetDataAccess();
                return DALLayer.RemoveMiniSite(ID);
            }
            else
                return false;
        }

        public static MiniSite GetMiniSiteById(int ID)
        {
            if (ID <= 0)
                return (null);

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetMiniSiteById(ID));
        }

        public static List<MiniSite> GetMiniSite()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetMiniSite());
        }
        public static List<MiniSite> GetMiniSite(string sortParameter)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();

            List<MiniSite> recordList = DALLayer.GetMiniSite();

            if (!String.IsNullOrEmpty(sortParameter))
                recordList.Sort(new MiniSiteComparer(sortParameter));

            return (recordList);
        }
 
        public static List<MiniSite> GetDisplayMiniSite()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetDisplayMiniSite());
        }
        
    }
}