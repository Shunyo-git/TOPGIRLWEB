using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using TopGirl.BusinessLogicLayer;

namespace TopGirl.DataAccessLayer
{
    /// <summary>
    /// DataAccess 的摘要描述
    /// </summary>
    public abstract class DataAccess
    {
        /*** PROPERTIES ***/
        protected string ConnectionString
        {
            get

            {

                string dataAccessStringType = ConfigurationManager.AppSettings["DataAccessLayerType"];
                string connectionString =   ConfigurationManager.ConnectionStrings["TopGirlConnectionString"].ConnectionString;
                
                if (connectionString == null)
                    throw (new NullReferenceException("ConnectionString configuration is missing from you web.config. It should contain  <connectionStrings> <add key=\"TopGirlConnectionString\" value=\"Data Source=.\\SQLExpress;Integrated Security=True;User Instance=True;AttachDBFilename=|DataDirectory|(DatabaseName)\" </connectionStrings>"));
 
                if (String.IsNullOrEmpty(connectionString))
                    throw (new NullReferenceException("ConnectionString configuration is missing from you web.config. It should contain  <connectionStrings> <add key=\"TopGirlConnectionString\" value=\"Server=(local);Integrated Security=True;Database=(DatabaseName)\" </connectionStrings>"));
                else
                    return (connectionString);
            }
        }


        /*** Event ***/
        public abstract Event GetEventById(int ID);
        public abstract Event GetLastDisplayEvent();
        public abstract List<Event> GetEvent();
        public abstract List<Event> GetEventByGroupID(int GroupID);
        public abstract List<Event> GetDisplayEvent();
        public abstract List<Event> GetDisplayEventByGroupID(int GroupID);
        public abstract List<Event> GetDisplayEventByHomePageAreaID(int HomePageAreaID);
        public abstract int InsertEvent(int GroupID, string Title, string SubTitle, string ReleaseDate, string Content, int HomePageAreaID, bool IsDisplay, string FileName);
        public abstract bool UpdateEvent(int ID, int GroupID, string Title, string SubTitle, string ReleaseDate, string Content, int HomePageAreaID, bool IsDisplay, string FileName);
        public abstract bool RemoveEvent(int ID);

        /*** Product ***/
        public abstract Product GetProductById(int ID);
        public abstract Product GetLastDisplayProduct();
        public abstract List<Product> GetProduct();
        public abstract List<Product> GetProductByCategoryID(int CategoryID);
        public abstract List<Product> GetDisplayProduct();
        public abstract List<Product> GetDisplayProductByCategoryID(int CategoryID);
        public abstract int InsertProduct(int CategoryID, string SKU, bool IsDisplay, string FileName_Main, string FileName_Thumb);
        public abstract bool UpdateProduct(int ID, int CategoryID, string SKU, bool IsDisplay, string FileName_Main, string FileName_Thumb);
        public abstract bool RemoveProduct(int ID);

        /*** Category ***/
        public abstract Category GetCategoryById(int ID);
        public abstract Category GetFirstDisplayCategory();
        public abstract List<Category> GetCategory();
        public abstract List<Category> GetDisplayCategory();
        public abstract List<Category> GetHomePageDisplayCategory();
        public abstract int InsertCategory(string Name, bool IsDisplay, bool IsHomePageDisplay, int SortID);
        public abstract bool UpdateCategory(int ID, string Name, bool IsDisplay, bool IsHomePageDisplay, int SortID);
        public abstract bool RemoveCategory(int ID);

        /*** Store ***/
        public abstract Store GetStoreById(int ID);
        public abstract List<Store> GetStore();
        public abstract List<Store> GetDisplayStore();
        public abstract List<Store> GetDisplayStoreByArea(int AreaID);
        public abstract int InsertStore( int AreaID, string StoreName, string Tel, string Address, bool IsDisplay);
        public abstract bool UpdateStore(int ID, int AreaID, string StoreName, string Tel, string Address, bool IsDisplay);
        public abstract bool RemoveStore(int ID);

        /*** MiniSite ***/
        public abstract MiniSite GetMiniSiteById(int ID);

        public abstract List<MiniSite> GetMiniSite();
        public abstract List<MiniSite> GetDisplayMiniSite();

        public abstract int InsertMiniSite(string URL, bool IsDisplay, int SortID);
        public abstract bool UpdateMiniSite(int ID, string URL, bool IsDisplay,  int SortID);
        public abstract bool RemoveMiniSite(int ID);
    }
}