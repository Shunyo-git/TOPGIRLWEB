using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;

using TopGirl.BusinessLogicLayer;


namespace TopGirl.DataAccessLayer
{
    /// <summary>
    /// EventProvider 的摘要描述
    /// </summary>
    public class SQLDataAccessProvider : DataAccess
    {
        /*** DELEGATE ***/

        private delegate void TGenerateListFromReader<T>(SqlDataReader returnData, ref List<T> tempList);


        /*****************************  BASE CLASS IMPLEMENTATION *****************************/

        #region Event METHODS
        //Static constants
        private const string SQL_SELECT_EVENT = "SELECT E.ID,E.GroupID,E.Title,E.SubTitle,E.ReleaseDate,E.Content,E.HomePageAreaID,E.IsDisplay,E.FileName FROM tg_Event E   WHERE (E.ID = @ID)";
        private const string SQL_SELECT_LAST_DISPLAY_EVENT = "SELECT TOP 1 E.ID,E.GroupID,E.Title,E.SubTitle,E.ReleaseDate,E.Content,E.HomePageAreaID,E.IsDisplay,E.FileName FROM tg_Event E   WHERE (E.IsDelete = 0) AND (IsDisplay = 1) ORDER BY E.ReleaseDate DESC,E.ID Desc";
        private const string SQL_SELECT_ALL_EVENT = "SELECT E.ID,E.GroupID,E.Title,E.SubTitle,E.ReleaseDate,E.Content,E.HomePageAreaID,E.IsDisplay,E.FileName FROM tg_Event E   WHERE (E.IsDelete = 0) ORDER BY E.ID Desc";
        private const string SQL_SELECT_ALL_EVENT_BY_GROUPID = "SELECT E.ID,E.GroupID,E.Title,E.SubTitle,E.ReleaseDate,E.Content,E.HomePageAreaID,E.IsDisplay,E.FileName FROM tg_Event E   WHERE (E.IsDelete = 0) AND (E.GroupID = @GroupID) ORDER BY E.ID Desc";
        private const string SQL_SELECT_ALL_DISPLAY_EVENT = "SELECT E.ID,E.GroupID,E.Title,E.SubTitle,E.ReleaseDate,E.Content,E.HomePageAreaID,E.IsDisplay,E.FileName FROM tg_Event E   WHERE (E.IsDelete = 0) AND (E.IsDisplay = 1) ORDER BY E.ReleaseDate DESC,E.ID Desc";
        private const string SQL_SELECT_ALL_DISPLAY_EVENT_BY_GROUPID = "SELECT E.ID,E.GroupID,E.Title,E.SubTitle,E.ReleaseDate,E.Content,E.HomePageAreaID,E.IsDisplay,E.FileName FROM tg_Event E   WHERE (E.IsDelete = 0) AND (E.IsDisplay = 1) AND (E.GroupID = @GroupID) ORDER BY E.ID Desc";
        private const string SQL_SELECT_ALL_DISPLAY_EVENT_BY_HOMEPAGEAREAID = "SELECT E.ID,E.GroupID,E.Title,E.SubTitle,E.ReleaseDate,E.Content,E.HomePageAreaID,E.IsDisplay,E.FileName FROM tg_Event E   WHERE (E.IsDelete = 0) AND (E.IsDisplay = 1) AND (E.HomePageAreaID = @HomePageAreaID) ORDER BY E.ReleaseDate DESC,E.ID Desc";
        private const string SQL_INSERT_EVENT = " INSERT INTO tg_Event (GroupID,Title,SubTitle,ReleaseDate,Content,HomePageAreaID,IsDisplay,FileName) VALUES(@GroupID,@Title,@SubTitle,@ReleaseDate,@Content,@HomePageAreaID,@IsDisplay,@FileName); SELECT @ID=@@IDENTITY; SELECT @ID ";
        private const string SQL_UPDATE_EVENT = "  UPDATE tg_Event SET GroupID=@GroupID,Title=@Title,SubTitle=@SubTitle,ReleaseDate=@ReleaseDate,Content=@Content,HomePageAreaID=@HomePageAreaID,IsDisplay=@IsDisplay,FileName=@FileName  WHERE ID=@ID; SET @ERR=@@ERROR; SELECT @ERR";
        private const string SQL_REMOVE_EVENT = "  UPDATE tg_Event SET IsDelete=1,DeletedDate=GetDate() WHERE ID=@ID; SELECT @ERR=@@ERROR;SELECT @ERR";
    
        public override Event GetEventById(int ID)
        {
            if (ID <= 0)
            {
                throw (new ArgumentOutOfRangeException("ID"));
            }
            SqlCommand sqlCmd = new SqlCommand();
            AddParamToSQLCmd(sqlCmd, "@ID", SqlDbType.Int, 0, ParameterDirection.Input, ID);
            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_EVENT);
            List<Event> eventList = new List<Event>();
            TExecuteReaderCmd<Event>(sqlCmd, TGenerateEventListFromReader<Event>, ref eventList);
            if (eventList.Count > 0)
                return eventList[0];
            else
                return null;
        }
        public override Event GetLastDisplayEvent( )
        {
            
            SqlCommand sqlCmd = new SqlCommand();

            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_LAST_DISPLAY_EVENT);
            List<Event> eventList = new List<Event>();
            TExecuteReaderCmd<Event>(sqlCmd, TGenerateEventListFromReader<Event>, ref eventList);
            if (eventList.Count > 0)
                return eventList[0];
            else
                return null;
        }
        public override List<Event> GetEvent()
        {
            SqlCommand sqlCmd = new SqlCommand();
            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_ALL_EVENT);
            List<Event> eventList = new List<Event>();
            TExecuteReaderCmd<Event>(sqlCmd, TGenerateEventListFromReader<Event>, ref eventList);
            return eventList;
        }
        public override List<Event> GetEventByGroupID(int GroupID)
        {

            if (GroupID <= 0)
            {
                throw (new ArgumentOutOfRangeException("GroupID"));
            }
            SqlCommand sqlCmd = new SqlCommand();
            AddParamToSQLCmd(sqlCmd, "@GroupID", SqlDbType.Int, 0, ParameterDirection.Input, GroupID);
            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_ALL_EVENT_BY_GROUPID);
            List<Event> eventList = new List<Event>();
            TExecuteReaderCmd<Event>(sqlCmd, TGenerateEventListFromReader<Event>, ref eventList);
            return eventList;
        }
        public override List<Event> GetDisplayEvent()
        {
            SqlCommand sqlCmd = new SqlCommand();
            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_ALL_DISPLAY_EVENT);
            List<Event> eventList = new List<Event>();
            TExecuteReaderCmd<Event>(sqlCmd, TGenerateEventListFromReader<Event>, ref eventList);
            return eventList;
        }
        public override List<Event> GetDisplayEventByGroupID(int GroupID)
        {

            if (GroupID <= 0)
            {
                throw (new ArgumentOutOfRangeException("GroupID"));
            }
            SqlCommand sqlCmd = new SqlCommand();
            AddParamToSQLCmd(sqlCmd, "@GroupID", SqlDbType.Int, 0, ParameterDirection.Input, GroupID);
            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_ALL_DISPLAY_EVENT_BY_GROUPID);
            List<Event> eventList = new List<Event>();
            TExecuteReaderCmd<Event>(sqlCmd, TGenerateEventListFromReader<Event>, ref eventList);
            return eventList;
        }
        public override List<Event> GetDisplayEventByHomePageAreaID(int HomePageAreaID)
        {

            if (HomePageAreaID <= 0)
            {
                throw (new ArgumentOutOfRangeException("HomePageAreaID"));
            }
            SqlCommand sqlCmd = new SqlCommand();
            AddParamToSQLCmd(sqlCmd, "@HomePageAreaID", SqlDbType.Int, 0, ParameterDirection.Input, HomePageAreaID);
            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_ALL_DISPLAY_EVENT_BY_HOMEPAGEAREAID);
            List<Event> eventList = new List<Event>();
            TExecuteReaderCmd<Event>(sqlCmd, TGenerateEventListFromReader<Event>, ref eventList);
            return eventList;
        }
        public override int InsertEvent(int GroupID, string Title, string SubTitle, string ReleaseDate, string Content, int HomePageAreaID, bool IsDisplay, string FileName)
        {

            SqlCommand sqlCmd = new SqlCommand();

            //AddParamToSQLCmd(sqlCmd, "@ERR", SqlDbType.Int, 0, ParameterDirection.Output, null);
            AddParamToSQLCmd(sqlCmd, "@ID", SqlDbType.Int, 0, ParameterDirection.Output, null);

            AddParamToSQLCmd(sqlCmd, "@GroupID", SqlDbType.Int, 0, ParameterDirection.Input, GroupID);
            AddParamToSQLCmd(sqlCmd, "@Title", SqlDbType.NVarChar, 50, ParameterDirection.Input, Title);
            AddParamToSQLCmd(sqlCmd, "@SubTitle", SqlDbType.NVarChar, 200, ParameterDirection.Input, SubTitle);
            AddParamToSQLCmd(sqlCmd, "@ReleaseDate", SqlDbType.NVarChar, 50, ParameterDirection.Input, ReleaseDate);
            AddParamToSQLCmd(sqlCmd, "@Content", SqlDbType.NText,0, ParameterDirection.Input, Content);
            AddParamToSQLCmd(sqlCmd, "@HomePageAreaID", SqlDbType.Int, 0, ParameterDirection.Input, HomePageAreaID);
            AddParamToSQLCmd(sqlCmd, "@IsDisplay", SqlDbType.Bit, 1, ParameterDirection.Input, IsDisplay);
            AddParamToSQLCmd(sqlCmd, "@FileName", SqlDbType.NVarChar, 50, ParameterDirection.Input, FileName);
           
            SetCommandType(sqlCmd, CommandType.Text, SQL_INSERT_EVENT);
            ExecuteScalarCmd(sqlCmd);

            int ID = (int)sqlCmd.Parameters["@ID"].Value;
            //int ReturnValue = (int)sqlCmd.Parameters["@ERR"].Value;
            //if (ReturnValue != 0)
            //{
            //    throw new ApplicationException("DATA INTEGRITY ERROR ON Event INSERT - ROLLBACK ISSUED");
            //}
            return (ID);

        }
        public override bool UpdateEvent(int ID, int GroupID, string Title, string SubTitle, string ReleaseDate, string Content, int HomePageAreaID, bool IsDisplay, string FileName)
        {

            SqlCommand sqlCmd = new SqlCommand();

            AddParamToSQLCmd(sqlCmd, "@ERR", SqlDbType.Int, 0, ParameterDirection.Output, null);

            AddParamToSQLCmd(sqlCmd, "@ID", SqlDbType.Int, 0, ParameterDirection.Input, ID);
            AddParamToSQLCmd(sqlCmd, "@GroupID", SqlDbType.Int, 0, ParameterDirection.Input, GroupID);
            AddParamToSQLCmd(sqlCmd, "@Title", SqlDbType.NVarChar, 50, ParameterDirection.Input, Title);
            AddParamToSQLCmd(sqlCmd, "@SubTitle", SqlDbType.NVarChar, 200, ParameterDirection.Input, SubTitle);
            AddParamToSQLCmd(sqlCmd, "@ReleaseDate", SqlDbType.NVarChar, 50, ParameterDirection.Input, ReleaseDate);
            AddParamToSQLCmd(sqlCmd, "@Content", SqlDbType.NText, 0, ParameterDirection.Input, Content);
            AddParamToSQLCmd(sqlCmd, "@HomePageAreaID", SqlDbType.Int, 0, ParameterDirection.Input, HomePageAreaID);
            AddParamToSQLCmd(sqlCmd, "@IsDisplay", SqlDbType.Bit, 1, ParameterDirection.Input, IsDisplay);
            AddParamToSQLCmd(sqlCmd, "@FileName", SqlDbType.NVarChar, 50, ParameterDirection.Input, FileName);



            SetCommandType(sqlCmd, CommandType.Text, SQL_UPDATE_EVENT);
            ExecuteScalarCmd(sqlCmd);

            int returnValue = (int)sqlCmd.Parameters["@ERR"].Value;
            if (returnValue != 0)
            {
                throw new ApplicationException("DATA INTEGRITY ERROR ON Event UPDATE - ROLLBACK ISSUED");
            }
            return (returnValue == 0 ? true : false);

  
           
        

        }
        public override bool RemoveEvent(int ID)
        {

            if (ID <= 0)
                throw (new ArgumentOutOfRangeException("ID"));

            SqlCommand sqlCmd = new SqlCommand();

            AddParamToSQLCmd(sqlCmd, "@ERR", SqlDbType.Int, 0, ParameterDirection.Output, null);
            AddParamToSQLCmd(sqlCmd, "@ID", SqlDbType.Int, 0, ParameterDirection.Input, ID);

            SetCommandType(sqlCmd, CommandType.Text, SQL_REMOVE_EVENT);
            ExecuteScalarCmd(sqlCmd);

            int returnValue = (int)sqlCmd.Parameters["@ERR"].Value;

            return (returnValue == 0 ? true : false);

        }
        #endregion

        #region Category METHODS
        //Static constants 
        private const string SQL_SELECT_CATEGORY = "SELECT  ID,NAME,IsDisplay,IsHomePageDisplay,SortID FROM tg_Category WHERE (ID = @ID)";
        private const string SQL_SELECT_FIRST_DISPLAY_CATEGORY = "SELECT TOP 1 ID,NAME,IsDisplay,IsHomePageDisplay,SortID FROM tg_Category WHERE (IsDelete = 0) AND (IsDisplay = 1) ORDER BY SortID ";
        private const string SQL_SELECT_ALL_CATEGORY = "SELECT ID,NAME,IsDisplay,IsHomePageDisplay,SortID FROM tg_Category  WHERE (IsDelete = 0) ORDER BY  SortID";
        private const string SQL_SELECT_ALL_DISPLAY_CATEGORY = "SELECT ID,NAME,IsDisplay,IsHomePageDisplay,SortID FROM  tg_Category WHERE (IsDelete = 0) AND (IsDisplay = 1) ORDER BY SortID";
        private const string SQL_SELECT_ALL_HOMEPAGE_DISPLAY_CATEGORY = "SELECT ID,NAME,IsDisplay,IsHomePageDisplay,SortID FROM  tg_Category WHERE (IsDelete = 0) AND (IsDisplay = 1) AND (IsHomePageDisplay=1) ORDER BY SortID";

        private const string SQL_INSERT_CATEGORY = "INSERT INTO tg_Category (Name,IsDisplay,IsHomePageDisplay,SortID) VALUES(@Name,@IsDisplay,@IsHomePageDisplay,@SortID); SELECT @ID=@@IDENTITY; SELECT @ReturnValue=@@ERROR;SELECT @ID, @ReturnValue;";
        private const string SQL_UPDATE_CATEGORY = " UPDATE tg_Category SET Name=@Name,IsDisplay=@IsDisplay,IsHomePageDisplay=@IsHomePageDisplay,SortID=@SortID WHERE ID=@ID; SELECT @ReturnValue=@@ERROR;SELECT @ReturnValue;";
        private const string SQL_REMOVE_CATEGORY = " UPDATE tg_Category SET IsDelete=1,DeletedDate=GetDate() WHERE ID=@ID; SELECT @ReturnValue=@@ERROR;SELECT @ReturnValue;";

        public override Category GetCategoryById(int ID)
        {
            if (ID <= 0)
            {
                throw (new ArgumentOutOfRangeException("ID"));
            }
            SqlCommand sqlCmd = new SqlCommand();
            AddParamToSQLCmd(sqlCmd, "@ID", SqlDbType.Int, 0, ParameterDirection.Input, ID);
            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_CATEGORY);
            List<Category> CategoryList = new List<Category>();
            TExecuteReaderCmd<Category>(sqlCmd, TGenerateCategoryListFromReader<Category>, ref CategoryList);
            if (CategoryList.Count > 0)
                return CategoryList[0];
            else
                return null;
        }
        public override Category GetFirstDisplayCategory()
        {

            SqlCommand sqlCmd = new SqlCommand();

            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_FIRST_DISPLAY_CATEGORY);
            List<Category> CategoryList = new List<Category>();
            TExecuteReaderCmd<Category>(sqlCmd, TGenerateCategoryListFromReader<Category>, ref CategoryList);
            if (CategoryList.Count > 0)
                return CategoryList[0];
            else
                return null;
        }
        public override List<Category> GetCategory()
        {
            SqlCommand sqlCmd = new SqlCommand();
            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_ALL_CATEGORY);
            List<Category> CategoryList = new List<Category>();
            TExecuteReaderCmd<Category>(sqlCmd, TGenerateCategoryListFromReader<Category>, ref CategoryList);
            return CategoryList;
        }
        public override List<Category> GetDisplayCategory()
        {
            SqlCommand sqlCmd = new SqlCommand();
            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_ALL_DISPLAY_CATEGORY);
            List<Category> CategoryList = new List<Category>();
            TExecuteReaderCmd<Category>(sqlCmd, TGenerateCategoryListFromReader<Category>, ref CategoryList);
            return CategoryList;
        }
        public override List<Category> GetHomePageDisplayCategory()
        {
            SqlCommand sqlCmd = new SqlCommand();
            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_ALL_HOMEPAGE_DISPLAY_CATEGORY);
            List<Category> CategoryList = new List<Category>();
            TExecuteReaderCmd<Category>(sqlCmd, TGenerateCategoryListFromReader<Category>, ref CategoryList);
            return CategoryList;
        }
        public override int InsertCategory(string Name, bool IsDisplay, bool IsHomePageDisplay,int SortID)
        {

            SqlCommand sqlCmd = new SqlCommand();

            AddParamToSQLCmd(sqlCmd, "@ReturnValue", SqlDbType.Int, 0, ParameterDirection.Output, null);
            AddParamToSQLCmd(sqlCmd, "@ID", SqlDbType.Int, 0, ParameterDirection.Output, null);
       
            AddParamToSQLCmd(sqlCmd, "@Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, Name);
            AddParamToSQLCmd(sqlCmd, "@IsDisplay", SqlDbType.Bit, 1, ParameterDirection.Input, IsDisplay);
            AddParamToSQLCmd(sqlCmd, "@IsHomePageDisplay", SqlDbType.Bit, 1, ParameterDirection.Input, IsHomePageDisplay);
            AddParamToSQLCmd(sqlCmd, "@SortID", SqlDbType.Int, 0, ParameterDirection.Input, SortID);

            SetCommandType(sqlCmd, CommandType.Text, SQL_INSERT_CATEGORY);
            ExecuteScalarCmd(sqlCmd);

            int ID = (int)sqlCmd.Parameters["@ID"].Value;
            int ReturnValue = (int)sqlCmd.Parameters["@ReturnValue"].Value;
            if (ReturnValue != 0)
            {
                throw new ApplicationException("DATA INTEGRITY ERROR ON Category INSERT - ROLLBACK ISSUED");
            }
            return (ID);

        }
        public override bool UpdateCategory(int ID, string Name, bool IsDisplay, bool IsHomePageDisplay, int SortID)
        {

            SqlCommand sqlCmd = new SqlCommand();

            AddParamToSQLCmd(sqlCmd, "@ReturnValue", SqlDbType.Int, 0, ParameterDirection.Output, null);

            AddParamToSQLCmd(sqlCmd, "@ID", SqlDbType.Int, 0, ParameterDirection.Input, ID);
            AddParamToSQLCmd(sqlCmd, "@Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, Name);
            AddParamToSQLCmd(sqlCmd, "@IsDisplay", SqlDbType.Bit, 1, ParameterDirection.Input, IsDisplay);
            AddParamToSQLCmd(sqlCmd, "@IsHomePageDisplay", SqlDbType.Bit, 1, ParameterDirection.Input, IsHomePageDisplay);
            AddParamToSQLCmd(sqlCmd, "@SortID", SqlDbType.Int, 0, ParameterDirection.Input, SortID);

            SetCommandType(sqlCmd, CommandType.Text, SQL_UPDATE_CATEGORY);
            ExecuteScalarCmd(sqlCmd);


            int returnValue = (int)sqlCmd.Parameters["@ReturnValue"].Value;
            if (returnValue != 0)
            {
                throw new ApplicationException("DATA INTEGRITY ERROR ON Category UPDATE - ROLLBACK ISSUED");
            }
            return (returnValue == 0 ? true : false);

        }
        public override bool RemoveCategory(int ID)
        {

            if (ID <= 0)
                throw (new ArgumentOutOfRangeException("ID"));

            SqlCommand sqlCmd = new SqlCommand();

            AddParamToSQLCmd(sqlCmd, "@ReturnValue", SqlDbType.Int, 0, ParameterDirection.Output, null);
            AddParamToSQLCmd(sqlCmd, "@ID", SqlDbType.Int, 0, ParameterDirection.Input, ID);

            SetCommandType(sqlCmd, CommandType.Text, SQL_REMOVE_CATEGORY);
            ExecuteScalarCmd(sqlCmd);

            int returnValue = (int)sqlCmd.Parameters["@ReturnValue"].Value;

            return (returnValue == 0 ? true : false);

        }
        #endregion

        #region Product METHODS
        //Static constants
        private const string SQL_SELECT_PRODUCT = "SELECT ID, CategoryID, SKU, IsDisplay , FileName_Main, FileName_Thumb FROM tg_Product     WHERE (ID = @ID)";
        private const string SQL_SELECT_LAST_DISPLAY_PRODUCT = "SELECT TOP 1 ID, CategoryID, SKU, IsDisplay , FileName_Main, FileName_Thumb FROM tg_Product     WHERE (IsDelete = 0) AND (IsDisplay = 1) ORDER BY SKU";
        private const string SQL_SELECT_ALL_PRODUCT = "SELECT ID, CategoryID, SKU, IsDisplay , FileName_Main, FileName_Thumb FROM tg_Product     WHERE (IsDelete = 0) ORDER BY SKU";
        private const string SQL_SELECT_ALL_PRODUCT_BY_GROUPID = "SELECT ID, CategoryID, SKU, IsDisplay , FileName_Main, FileName_Thumb FROM tg_Product     WHERE (IsDelete = 0) AND (CategoryID = @CategoryID) ORDER BY SKU";
        private const string SQL_SELECT_ALL_DISPLAY_PRODUCT = "SELECT ID, CategoryID, SKU, IsDisplay , FileName_Main, FileName_Thumb FROM tg_Product     WHERE (IsDelete = 0) AND (IsDisplay = 1) ORDER BY SKU";
        private const string SQL_SELECT_ALL_DISPLAY_PRODUCT_BY_GROUPID = "SELECT ID, CategoryID, SKU, IsDisplay , FileName_Main, FileName_Thumb FROM tg_Product     WHERE (IsDelete = 0) AND (IsDisplay = 1) AND (CategoryID = @CategoryID) ORDER BY  SKU";
        private const string SQL_INSERT_PRODUCT = " INSERT INTO tg_Product (CategoryID, SKU, IsDisplay , FileName_Main, FileName_Thumb) VALUES(@CategoryID, @SKU, @IsDisplay , @FileName_Main, @FileName_Thumb); SELECT @ID=@@IDENTITY; SELECT @ReturnValue=@@ERROR;SELECT @ID, @ReturnValue;";
        private const string SQL_UPDATE_PRODUCT = "  UPDATE tg_Product SET CategoryID=@CategoryID, SKU=@SKU, IsDisplay=@IsDisplay , FileName_Main=@FileName_Main, FileName_Thumb=@FileName_Thumb  WHERE ID=@ID; SELECT @ReturnValue=@@ERROR;SELECT @ReturnValue;";
        private const string SQL_REMOVE_PRODUCT = "  UPDATE tg_Product SET IsDelete=1,DeletedDate=GetDate() WHERE ID=@ID; SELECT @ReturnValue=@@ERROR;SELECT @ReturnValue;";

        public override Product GetProductById(int ID)
        {
            if (ID <= 0)
            {
                throw (new ArgumentOutOfRangeException("ID"));
            }
            SqlCommand sqlCmd = new SqlCommand();
            AddParamToSQLCmd(sqlCmd, "@ID", SqlDbType.Int, 0, ParameterDirection.Input, ID);
            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_PRODUCT);
            List<Product> productList = new List<Product>();
            TExecuteReaderCmd<Product>(sqlCmd, TGenerateProductListFromReader<Product>, ref productList);
            if (productList.Count > 0)
                return productList[0];
            else
                return null;
        }
        public override Product GetLastDisplayProduct()
        {

            SqlCommand sqlCmd = new SqlCommand();

            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_LAST_DISPLAY_PRODUCT);
            List<Product> productList = new List<Product>();
            TExecuteReaderCmd<Product>(sqlCmd, TGenerateProductListFromReader<Product>, ref productList);
            if (productList.Count > 0)
                return productList[0];
            else
                return null;
        }
        public override List<Product> GetProduct()
        {
            SqlCommand sqlCmd = new SqlCommand();
            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_ALL_PRODUCT);
            List<Product> productList = new List<Product>();
            TExecuteReaderCmd<Product>(sqlCmd, TGenerateProductListFromReader<Product>, ref productList);
            return productList;
        }
        public override List<Product> GetProductByCategoryID(int CategoryID)
        {

            if (CategoryID <= 0)
            {
                throw (new ArgumentOutOfRangeException("CategoryID"));
            }
            SqlCommand sqlCmd = new SqlCommand();
            AddParamToSQLCmd(sqlCmd, "@CategoryID", SqlDbType.Int, 0, ParameterDirection.Input, CategoryID);
            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_ALL_PRODUCT_BY_GROUPID);
            List<Product> productList = new List<Product>();
            TExecuteReaderCmd<Product>(sqlCmd, TGenerateProductListFromReader<Product>, ref productList);
            return productList;
        }
        public override List<Product> GetDisplayProduct()
        {
            SqlCommand sqlCmd = new SqlCommand();
            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_ALL_DISPLAY_PRODUCT);
            List<Product> productList = new List<Product>();
            TExecuteReaderCmd<Product>(sqlCmd, TGenerateProductListFromReader<Product>, ref productList);
            return productList;
        }
        public override List<Product> GetDisplayProductByCategoryID(int CategoryID)
        {

            if (CategoryID <= 0)
            {
                throw (new ArgumentOutOfRangeException("CategoryID"));
            }
            SqlCommand sqlCmd = new SqlCommand();
            AddParamToSQLCmd(sqlCmd, "@CategoryID", SqlDbType.Int, 0, ParameterDirection.Input, CategoryID);
            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_ALL_DISPLAY_PRODUCT_BY_GROUPID);
            List<Product> productList = new List<Product>();
            TExecuteReaderCmd<Product>(sqlCmd, TGenerateProductListFromReader<Product>, ref productList);
            return productList;
        }

        public override int InsertProduct(int CategoryID, string SKU, bool IsDisplay, string FileName_Main, string FileName_Thumb)
        {

            SqlCommand sqlCmd = new SqlCommand();

            AddParamToSQLCmd(sqlCmd, "@ReturnValue", SqlDbType.Int, 0, ParameterDirection.Output, null);
            AddParamToSQLCmd(sqlCmd, "@ID", SqlDbType.Int, 0, ParameterDirection.Output, null);

            AddParamToSQLCmd(sqlCmd, "@CategoryID", SqlDbType.Int, 0, ParameterDirection.Input, CategoryID);
            AddParamToSQLCmd(sqlCmd, "@SKU", SqlDbType.NVarChar, 50, ParameterDirection.Input, SKU);
            AddParamToSQLCmd(sqlCmd, "@IsDisplay", SqlDbType.Bit, 1, ParameterDirection.Input, IsDisplay);
            AddParamToSQLCmd(sqlCmd, "@FileName_Main", SqlDbType.NVarChar, 50, ParameterDirection.Input, FileName_Main);
            AddParamToSQLCmd(sqlCmd, "@FileName_Thumb", SqlDbType.NVarChar, 50, ParameterDirection.Input, FileName_Thumb);

            SetCommandType(sqlCmd, CommandType.Text, SQL_INSERT_PRODUCT);
            ExecuteScalarCmd(sqlCmd);

            int ID = (int)sqlCmd.Parameters["@ID"].Value;
            int ReturnValue = (int)sqlCmd.Parameters["@ReturnValue"].Value;
            if (ReturnValue != 0)
            {
                throw new ApplicationException("DATA INTEGRITY ERROR ON Product INSERT - ROLLBACK ISSUED");
            }
            return (ID);

        }
        public override bool UpdateProduct(int ID, int CategoryID, string SKU, bool IsDisplay, string FileName_Main, string FileName_Thumb)
        {

            SqlCommand sqlCmd = new SqlCommand();

            AddParamToSQLCmd(sqlCmd, "@ReturnValue", SqlDbType.Int, 0, ParameterDirection.Output, null);

            AddParamToSQLCmd(sqlCmd, "@ID", SqlDbType.Int, 0, ParameterDirection.Input, ID);
            AddParamToSQLCmd(sqlCmd, "@CategoryID", SqlDbType.Int, 0, ParameterDirection.Input, CategoryID);
            AddParamToSQLCmd(sqlCmd, "@SKU", SqlDbType.NVarChar, 50, ParameterDirection.Input, SKU);
            AddParamToSQLCmd(sqlCmd, "@IsDisplay", SqlDbType.Bit, 1, ParameterDirection.Input, IsDisplay);
            AddParamToSQLCmd(sqlCmd, "@FileName_Main", SqlDbType.NVarChar, 50, ParameterDirection.Input, FileName_Main);
            AddParamToSQLCmd(sqlCmd, "@FileName_Thumb", SqlDbType.NVarChar, 50, ParameterDirection.Input, FileName_Thumb);

            SetCommandType(sqlCmd, CommandType.Text, SQL_UPDATE_PRODUCT);
            ExecuteScalarCmd(sqlCmd);


            int returnValue = (int)sqlCmd.Parameters["@ReturnValue"].Value;
            if (returnValue != 0)
            {
                throw new ApplicationException("DATA INTEGRITY ERROR ON Product UPDATE - ROLLBACK ISSUED");
            }
            return (returnValue == 0 ? true : false);

        }
        public override bool RemoveProduct(int ID)
        {

            if (ID <= 0)
                throw (new ArgumentOutOfRangeException("ID"));

            SqlCommand sqlCmd = new SqlCommand();

            AddParamToSQLCmd(sqlCmd, "@ReturnValue", SqlDbType.Int, 0, ParameterDirection.Output, null);
            AddParamToSQLCmd(sqlCmd, "@ID", SqlDbType.Int, 0, ParameterDirection.Input, ID);

            SetCommandType(sqlCmd, CommandType.Text, SQL_REMOVE_PRODUCT);
            ExecuteScalarCmd(sqlCmd);

            int returnValue = (int)sqlCmd.Parameters["@ReturnValue"].Value;

            return (returnValue == 0 ? true : false);

        }
        #endregion

        #region Store METHODS
        //Static constants
        private const string SQL_SELECT_STORE = "SELECT S.ID, S.AreaID, S.StoreName, S.Tel,S.Address,S.IsDisplay,A.Name AS AreaName FROM tg_Store S INNER JOIN tg_StoreArea A  ON S.AreaID = A.ID  WHERE (S.ID = @ID)";
        private const string SQL_SELECT_ALL_STORE = "SELECT S.ID, S.AreaID, S.StoreName, S.Tel,S.Address,S.IsDisplay,A.Name AS AreaName FROM tg_Store S INNER JOIN tg_StoreArea A  ON S.AreaID = A.ID WHERE (IsDelete = 0) ORDER BY A.ID,S.ID";
        private const string SQL_SELECT_ALL_DISPLAY_STORE = "SELECT S.ID, S.AreaID, S.StoreName, S.Tel,S.Address,S.IsDisplay,A.Name AS AreaName FROM tg_Store S INNER JOIN tg_StoreArea A  ON S.AreaID = A.ID WHERE (IsDelete = 0) AND (IsDisplay = 1) ORDER BY A.ID,S.ID";
        private const string SQL_SELECT_ALL_DISPLAY_STORE_BY_AREAID = "SELECT S.ID, S.AreaID, S.StoreName, S.Tel,S.Address,S.IsDisplay,A.Name AS AreaName FROM tg_Store S INNER JOIN tg_StoreArea A  ON S.AreaID = A.ID WHERE (IsDelete = 0) AND (IsDisplay = 1) AND (AreaID = @AreaID) ORDER BY  A.ID,S.ID";
        private const string SQL_INSERT_STORE = "INSERT INTO tg_Store ( AreaID, StoreName, Tel,Address,IsDisplay) VALUES(  @AreaID, @StoreName, @Tel,@Address,@IsDisplay); SELECT @ID=@@IDENTITY; SELECT @ReturnValue=@@ERROR;SELECT @ID, @ReturnValue;";
        private const string SQL_UPDATE_STORE = "UPDATE tg_Store SET  AreaID=@AreaID, StoreName=@StoreName, Tel=@Tel,Address=@Address,IsDisplay=@IsDisplay  WHERE ID=@ID; SELECT @ReturnValue=@@ERROR;SELECT @ReturnValue;";
        private const string SQL_REMOVE_STORE = "UPDATE tg_Store SET IsDelete=1,DeletedDate=GetDate() WHERE ID=@ID; SELECT @ReturnValue=@@ERROR;SELECT @ReturnValue;";

        public override Store GetStoreById(int ID)
        {
            if (ID <= 0)
            {
                throw (new ArgumentOutOfRangeException("ID"));
            }
            SqlCommand sqlCmd = new SqlCommand();
            AddParamToSQLCmd(sqlCmd, "@ID", SqlDbType.Int, 0, ParameterDirection.Input, ID);
            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_STORE);
            List<Store> storeList = new List<Store>();
            TExecuteReaderCmd<Store>(sqlCmd, TGenerateStoreListFromReader<Store>, ref storeList);
            if (storeList.Count > 0)
                return storeList[0];
            else
                return null;
        }
        public override List<Store> GetStore()
        {
            SqlCommand sqlCmd = new SqlCommand();
            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_ALL_STORE);
            List<Store> storeList = new List<Store>();
            TExecuteReaderCmd<Store>(sqlCmd, TGenerateStoreListFromReader<Store>, ref storeList);
            return storeList;
        }
        public override List<Store> GetDisplayStore()
        {
            SqlCommand sqlCmd = new SqlCommand();
            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_ALL_DISPLAY_STORE);
            List<Store> storeList = new List<Store>();
            TExecuteReaderCmd<Store>(sqlCmd, TGenerateStoreListFromReader<Store>, ref storeList);
            return storeList;
        }
        public override List<Store> GetDisplayStoreByArea(int AreaID)
        {

            if (AreaID <= 0)
            {
                throw (new ArgumentOutOfRangeException("AreaID"));
            }
            SqlCommand sqlCmd = new SqlCommand();
            AddParamToSQLCmd(sqlCmd, "@AreaID", SqlDbType.Int, 0, ParameterDirection.Input, AreaID);
            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_ALL_DISPLAY_STORE_BY_AREAID);
            List<Store> storeList = new List<Store>();
            TExecuteReaderCmd<Store>(sqlCmd, TGenerateStoreListFromReader<Store>, ref storeList);
            return storeList;
        }
        public override int InsertStore(int AreaID, string StoreName, string Tel, string Address, bool IsDisplay)
        {

            SqlCommand sqlCmd = new SqlCommand();

            AddParamToSQLCmd(sqlCmd, "@ReturnValue", SqlDbType.Int, 0, ParameterDirection.Output, null);
            AddParamToSQLCmd(sqlCmd, "@ID", SqlDbType.Int, 0, ParameterDirection.Output, null);

            AddParamToSQLCmd(sqlCmd, "@AreaID", SqlDbType.Int, 0, ParameterDirection.Input, AreaID);
            AddParamToSQLCmd(sqlCmd, "@StoreName", SqlDbType.NVarChar, 50, ParameterDirection.Input, StoreName);
            AddParamToSQLCmd(sqlCmd, "@IsDisplay", SqlDbType.Bit, 1, ParameterDirection.Input, IsDisplay);
            AddParamToSQLCmd(sqlCmd, "@Tel", SqlDbType.NVarChar, 50, ParameterDirection.Input, Tel);
            AddParamToSQLCmd(sqlCmd, "@Address", SqlDbType.NVarChar, 300, ParameterDirection.Input, Address);

            SetCommandType(sqlCmd, CommandType.Text, SQL_INSERT_STORE);
            ExecuteScalarCmd(sqlCmd);

            int ID = (int)sqlCmd.Parameters["@ID"].Value;
            int ReturnValue = (int)sqlCmd.Parameters["@ReturnValue"].Value;
            if (ReturnValue != 0)
            {
                throw new ApplicationException("DATA INTEGRITY ERROR ON Store INSERT - ROLLBACK ISSUED");
            }
            return (ID);

        }
        public override bool UpdateStore(int ID, int AreaID, string StoreName, string Tel, string Address, bool IsDisplay)
        {

            SqlCommand sqlCmd = new SqlCommand();

            AddParamToSQLCmd(sqlCmd, "@ReturnValue", SqlDbType.Int, 0, ParameterDirection.Output, null);

            AddParamToSQLCmd(sqlCmd, "@ID", SqlDbType.Int, 0, ParameterDirection.Input, ID);
            AddParamToSQLCmd(sqlCmd, "@AreaID", SqlDbType.Int, 0, ParameterDirection.Input, AreaID);
            AddParamToSQLCmd(sqlCmd, "@StoreName", SqlDbType.NVarChar, 50, ParameterDirection.Input, StoreName);
            AddParamToSQLCmd(sqlCmd, "@IsDisplay", SqlDbType.Bit, 1, ParameterDirection.Input, IsDisplay);
            AddParamToSQLCmd(sqlCmd, "@Tel", SqlDbType.NVarChar, 50, ParameterDirection.Input, Tel);
            AddParamToSQLCmd(sqlCmd, "@Address", SqlDbType.NVarChar, 300, ParameterDirection.Input, Address);

            SetCommandType(sqlCmd, CommandType.Text, SQL_UPDATE_STORE);
            ExecuteScalarCmd(sqlCmd);


            int returnValue = (int)sqlCmd.Parameters["@ReturnValue"].Value;
            if (returnValue != 0)
            {
                throw new ApplicationException("DATA INTEGRITY ERROR ON Store UPDATE - ROLLBACK ISSUED");
            }
            return (returnValue == 0 ? true : false);

        }
        public override bool RemoveStore(int ID)
        {

            if (ID <= 0)
                throw (new ArgumentOutOfRangeException("ID"));

            SqlCommand sqlCmd = new SqlCommand();

            AddParamToSQLCmd(sqlCmd, "@ReturnValue", SqlDbType.Int, 0, ParameterDirection.Output, null);
            AddParamToSQLCmd(sqlCmd, "@ID", SqlDbType.Int, 0, ParameterDirection.Input, ID);

            SetCommandType(sqlCmd, CommandType.Text, SQL_REMOVE_STORE);
            ExecuteScalarCmd(sqlCmd);

            int returnValue = (int)sqlCmd.Parameters["@ReturnValue"].Value;

            return (returnValue == 0 ? true : false);

        }

        #endregion

        #region MiniSite METHODS
        //Static constants 
        private const string SQL_SELECT_MINISITE = "SELECT  ID,URL,IsDisplay,SortID FROM tg_Minisite WHERE (ID = @ID)";
        private const string SQL_SELECT_ALL_MINISITE = "SELECT ID,URL,IsDisplay,SortID FROM tg_Minisite  WHERE (IsDelete = 0) ORDER BY  SortID";
        private const string SQL_SELECT_ALL_DISPLAY_MINISITE = "SELECT ID,URL,IsDisplay,SortID FROM  tg_Minisite WHERE (IsDelete = 0) AND (IsDisplay = 1) ORDER BY SortID";

        private const string SQL_INSERT_MINISITE = "INSERT INTO tg_Minisite (URL,IsDisplay,SortID) VALUES(@URL,@IsDisplay,@SortID); SELECT @ID=@@IDENTITY; SELECT @ReturnValue=@@ERROR;SELECT @ID, @ReturnValue;";
        private const string SQL_UPDATE_MINISITE = " UPDATE tg_Minisite SET URL=@URL,IsDisplay=@IsDisplay,SortID=@SortID WHERE ID=@ID; SELECT @ReturnValue=@@ERROR;SELECT @ReturnValue;";
        private const string SQL_REMOVE_MINISITE = " UPDATE tg_Minisite SET IsDelete=1,DeletedDate=GetDate() WHERE ID=@ID; SELECT @ReturnValue=@@ERROR;SELECT @ReturnValue;";

        public override MiniSite GetMiniSiteById(int ID)
        {
            if (ID <= 0)
            {
                throw (new ArgumentOutOfRangeException("ID"));
            }
            SqlCommand sqlCmd = new SqlCommand();
            AddParamToSQLCmd(sqlCmd, "@ID", SqlDbType.Int, 0, ParameterDirection.Input, ID);
            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_MINISITE);
            List<MiniSite> dataList = new List<MiniSite>();
            TExecuteReaderCmd<MiniSite>(sqlCmd, TGenerateMiniSiteListFromReader<MiniSite>, ref dataList);
            if (dataList.Count > 0)
                return dataList[0];
            else
                return null;
        }
        public override List<MiniSite> GetMiniSite()
        {
            SqlCommand sqlCmd = new SqlCommand();
            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_ALL_MINISITE);
            List<MiniSite> dataList = new List<MiniSite>();
            TExecuteReaderCmd<MiniSite>(sqlCmd, TGenerateMiniSiteListFromReader<MiniSite>, ref dataList);
            return dataList;
        }
        public override List<MiniSite> GetDisplayMiniSite()
        {
            SqlCommand sqlCmd = new SqlCommand();
            SetCommandType(sqlCmd, CommandType.Text, SQL_SELECT_ALL_DISPLAY_MINISITE);
            List<MiniSite> dataList = new List<MiniSite>();
            TExecuteReaderCmd<MiniSite>(sqlCmd, TGenerateMiniSiteListFromReader<MiniSite>, ref dataList);
            return dataList;
        }
        public override int InsertMiniSite(string URL, bool IsDisplay, int SortID)
        {

            SqlCommand sqlCmd = new SqlCommand();

            AddParamToSQLCmd(sqlCmd, "@ReturnValue", SqlDbType.Int, 0, ParameterDirection.Output, null);
            AddParamToSQLCmd(sqlCmd, "@ID", SqlDbType.Int, 0, ParameterDirection.Output, null);

            AddParamToSQLCmd(sqlCmd, "@URL", SqlDbType.NVarChar, 200, ParameterDirection.Input, URL);
            AddParamToSQLCmd(sqlCmd, "@IsDisplay", SqlDbType.Bit, 1, ParameterDirection.Input, IsDisplay);
            AddParamToSQLCmd(sqlCmd, "@SortID", SqlDbType.Int, 0, ParameterDirection.Input, SortID);

            SetCommandType(sqlCmd, CommandType.Text, SQL_INSERT_MINISITE);
            ExecuteScalarCmd(sqlCmd);

            int ID = (int)sqlCmd.Parameters["@ID"].Value;
            int ReturnValue = (int)sqlCmd.Parameters["@ReturnValue"].Value;
            if (ReturnValue != 0)
            {
                throw new ApplicationException("DATA INTEGRITY ERROR ON MINISITE INSERT - ROLLBACK ISSUED");
            }
            return (ID);

        }
        public override bool UpdateMiniSite(int ID, string URL, bool IsDisplay, int SortID)
        {

            SqlCommand sqlCmd = new SqlCommand();

            AddParamToSQLCmd(sqlCmd, "@ReturnValue", SqlDbType.Int, 0, ParameterDirection.Output, null);

            AddParamToSQLCmd(sqlCmd, "@ID", SqlDbType.Int, 0, ParameterDirection.Input, ID);
            AddParamToSQLCmd(sqlCmd, "@URL", SqlDbType.NVarChar, 200, ParameterDirection.Input, URL);
            AddParamToSQLCmd(sqlCmd, "@IsDisplay", SqlDbType.Bit, 1, ParameterDirection.Input, IsDisplay);
            AddParamToSQLCmd(sqlCmd, "@SortID", SqlDbType.Int, 0, ParameterDirection.Input, SortID);

            SetCommandType(sqlCmd, CommandType.Text, SQL_UPDATE_MINISITE);
            ExecuteScalarCmd(sqlCmd);


            int returnValue = (int)sqlCmd.Parameters["@ReturnValue"].Value;
            if (returnValue != 0)
            {
                throw new ApplicationException("DATA INTEGRITY ERROR ON MINISITE UPDATE - ROLLBACK ISSUED");
            }
            return (returnValue == 0 ? true : false);

        }
        public override bool RemoveMiniSite(int ID)
        {

            if (ID <= 0)
                throw (new ArgumentOutOfRangeException("ID"));

            SqlCommand sqlCmd = new SqlCommand();

            AddParamToSQLCmd(sqlCmd, "@ReturnValue", SqlDbType.Int, 0, ParameterDirection.Output, null);
            AddParamToSQLCmd(sqlCmd, "@ID", SqlDbType.Int, 0, ParameterDirection.Input, ID);

            SetCommandType(sqlCmd, CommandType.Text, SQL_REMOVE_MINISITE);
            ExecuteScalarCmd(sqlCmd);

            int returnValue = (int)sqlCmd.Parameters["@ReturnValue"].Value;

            return (returnValue == 0 ? true : false);

        }
        #endregion
        /*****************************  GENARATE List HELPER METHODS *****************************/
        #region GENARATE List HELPER METHODS

        //Event
        private void TGenerateEventListFromReader<T>(SqlDataReader returnData, ref List<Event> evnetList)
        {
            while (returnData.Read())
            {
                //ID,GroupID,Title,ReleaseDate,Content,HomePageAreaID,IsDisplay,FileName
                int ID = 0;
                if (returnData["ID"] != DBNull.Value) { ID = Convert.ToInt32(returnData["ID"]); }

                int GroupID = 0;
                if (returnData["GroupID"] != DBNull.Value) { GroupID = Convert.ToInt32(returnData["GroupID"]); }

                string Title = string.Empty;
                if (returnData["Title"] != DBNull.Value) { Title = Convert.ToString(returnData["Title"]); }

                string SubTitle = string.Empty;
                if (returnData["SubTitle"] != DBNull.Value) { SubTitle = Convert.ToString(returnData["SubTitle"]); }

                string ReleaseDate = string.Empty;
                if (returnData["ReleaseDate"] != DBNull.Value) { ReleaseDate = Convert.ToString(returnData["ReleaseDate"]); }

                string Content = string.Empty;
                if (returnData["Content"] != DBNull.Value) { Content = Convert.ToString(returnData["Content"]); }

                int HomePageAreaID = 0;
                if (returnData["HomePageAreaID"] != DBNull.Value) { HomePageAreaID = Convert.ToInt32(returnData["HomePageAreaID"]); }

                bool IsDisplay = false;
                if (returnData["IsDisplay"] != DBNull.Value) { IsDisplay = Convert.ToBoolean(returnData["IsDisplay"]); }

                string FileName = string.Empty;
                if (returnData["FileName"] != DBNull.Value) { FileName = Convert.ToString(returnData["FileName"]); }

                Event ev = new Event(ID, GroupID, Title,SubTitle, ReleaseDate, Content, HomePageAreaID, IsDisplay, FileName);
                evnetList.Add(ev);
            }
        }

        //Category
        private void TGenerateCategoryListFromReader<T>(SqlDataReader returnData, ref List<Category> categoryList)
        {
            while (returnData.Read())
            {
                //int ID,   string Name, bool IsDisplay
                int ID = 0;
                if (returnData["ID"] != DBNull.Value) { ID = Convert.ToInt32(returnData["ID"]); }
 
                string Name = string.Empty;
                if (returnData["Name"] != DBNull.Value) { Name = Convert.ToString(returnData["Name"]); }
 
                bool IsDisplay = false;
                if (returnData["IsDisplay"] != DBNull.Value) { IsDisplay = Convert.ToBoolean(returnData["IsDisplay"]); }

                bool IsHomePageDisplay = false;
                if (returnData["IsHomePageDisplay"] != DBNull.Value) { IsHomePageDisplay = Convert.ToBoolean(returnData["IsHomePageDisplay"]); }

                int SortID = 0;
                if (returnData["SortID"] != DBNull.Value) { SortID = Convert.ToInt32(returnData["SortID"]); }


                Category ct = new Category(ID, Name, IsDisplay, IsHomePageDisplay, SortID);
                categoryList.Add(ct);
            }
        }

        //Product
        private void TGenerateProductListFromReader<T>(SqlDataReader returnData, ref List<Product> productList)
        {
            while (returnData.Read())
            {
                //int ID,int CategoryID,string SKU,bool IsDisplay ,string FileName_Main,string FileName_Thumb
                int ID = 0;
                if (returnData["ID"] != DBNull.Value) { ID = Convert.ToInt32(returnData["ID"]); }

                int CategoryID = 0;
                if (returnData["CategoryID"] != DBNull.Value) { CategoryID = Convert.ToInt32(returnData["CategoryID"]); }

                string SKU = string.Empty;
                if (returnData["SKU"] != DBNull.Value) { SKU = Convert.ToString(returnData["SKU"]); }

                bool IsDisplay = false;
                if (returnData["IsDisplay"] != DBNull.Value) { IsDisplay = Convert.ToBoolean(returnData["IsDisplay"]); }

                string FileName_Main = string.Empty;
                if (returnData["FileName_Main"] != DBNull.Value) { FileName_Main = Convert.ToString(returnData["FileName_Main"]); }

                string FileName_Thumb = string.Empty;
                if (returnData["FileName_Thumb"] != DBNull.Value) { FileName_Thumb = Convert.ToString(returnData["FileName_Thumb"]); }

                Product pt = new Product(ID, CategoryID, SKU, IsDisplay, FileName_Main, FileName_Thumb);
                productList.Add(pt);
            }
        }

        //Store
        private void TGenerateStoreListFromReader<T>(SqlDataReader returnData, ref List<Store> storeList)
        {
            while (returnData.Read())
            {
                //int AreaID, string StoreName, string Tel, string Address, bool IsDisplay
                int ID = 0;
                if (returnData["ID"] != DBNull.Value) { ID = Convert.ToInt32(returnData["ID"]); }

                int AreaID = 0;
                if (returnData["AreaID"] != DBNull.Value) { AreaID = Convert.ToInt32(returnData["AreaID"]); }

                string StoreName = string.Empty;
                if (returnData["StoreName"] != DBNull.Value) { StoreName = Convert.ToString(returnData["StoreName"]); }

                string Tel = string.Empty;
                if (returnData["Tel"] != DBNull.Value) { Tel = Convert.ToString(returnData["Tel"]); }

                string Address = string.Empty;
                if (returnData["Address"] != DBNull.Value) { Address = Convert.ToString(returnData["Address"]); }

                bool IsDisplay = false;
                if (returnData["IsDisplay"] != DBNull.Value) { IsDisplay = Convert.ToBoolean(returnData["IsDisplay"]); }

                string AreaName = string.Empty;
                if (returnData["AreaName"] != DBNull.Value) { AreaName = Convert.ToString(returnData["AreaName"]); }

                Store pt = new Store(ID, AreaID, StoreName, Tel, Address, IsDisplay);
                pt.AreaName = AreaName;
                storeList.Add(pt);
            }
        }


        //MiniSite
        private void TGenerateMiniSiteListFromReader<T>(SqlDataReader returnData, ref List<MiniSite> dataList)
        {
            while (returnData.Read())
            {
                //int ID,   string Name, bool IsDisplay
                int ID = 0;
                if (returnData["ID"] != DBNull.Value) { ID = Convert.ToInt32(returnData["ID"]); }

                string URL = string.Empty;
                if (returnData["URL"] != DBNull.Value) { URL = Convert.ToString(returnData["URL"]); }

                bool IsDisplay = false;
                if (returnData["IsDisplay"] != DBNull.Value) { IsDisplay = Convert.ToBoolean(returnData["IsDisplay"]); }

                int SortID = 0;
                if (returnData["SortID"] != DBNull.Value) { SortID = Convert.ToInt32(returnData["SortID"]); }


                MiniSite ms = new MiniSite(ID, URL, IsDisplay, SortID);
                dataList.Add(ms);
            }
        }
        #endregion
 
        /*****************************  SQL HELPER METHODS *****************************/
        #region SQL HELPER METHODS
        private void AddParamToSQLCmd(SqlCommand sqlCmd,
                                      string paramId,
                                      SqlDbType sqlType,
                                      int paramSize,
                                      ParameterDirection paramDirection,
                                      object paramvalue)
        {

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));
            if (paramId == string.Empty)
                throw (new ArgumentOutOfRangeException("paramId"));

            SqlParameter newSqlParam = new SqlParameter();
            newSqlParam.ParameterName = paramId;
            newSqlParam.SqlDbType = sqlType;
            newSqlParam.Direction = paramDirection;

            if (paramSize > 0)
                newSqlParam.Size = paramSize;

            if (paramvalue != null)
                newSqlParam.Value = paramvalue;

            sqlCmd.Parameters.Add(newSqlParam);
        }

        private void ExecuteScalarCmd(SqlCommand sqlCmd)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));

            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                sqlCmd.Connection = cn;
                cn.Open();
                sqlCmd.ExecuteScalar();
            }
        }

        private void SetCommandType(SqlCommand sqlCmd, CommandType cmdType, string cmdText)
        {
            sqlCmd.CommandType = cmdType;
            sqlCmd.CommandText = cmdText;
        }

        private void TExecuteReaderCmd<T>(SqlCommand sqlCmd, TGenerateListFromReader<T> gcfr, ref List<T> List)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));

            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                sqlCmd.Connection = cn;
                cn.Open();
                gcfr(sqlCmd.ExecuteReader(), ref List);
            }
        }
        #endregion

        
    }
}