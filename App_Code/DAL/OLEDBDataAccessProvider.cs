//using System;
//using System.Data;
//using System.Configuration;
//using System.Data.SqlClient;
//using System.Text;
//using System.Collections.Generic;
//using System.Data.OleDb;
//using TopGirl.BusinessLogicLayer;


//namespace TopGirl.DataAccessLayer
//{
//    /// <summary>
//    /// EventProvider 的摘要描述
//    /// </summary>
//    public class OLEDBDataAccessProvider : DataAccess
//    {
//        /*** DELEGATE ***/

//        private delegate void TGenerateListFromReader<T>(OleDbDataReader returnData, ref List<T> tempList);


//        /*****************************  BASE CLASS IMPLEMENTATION *****************************/

//        #region Event METHODS
//        //Static constants
//        private const string SQL_SELECT_EVENT = "SELECT E.ID,E.GroupID,E.Title,E.SubTitle,E.ReleaseDate,E.Content,E.HomePageAreaID,E.IsDisplay,E.FileName FROM tg_Event E   WHERE (E.ID = @ID)";
//        private const string SQL_SELECT_LAST_DISPLAY_EVENT = "SELECT TOP 1 E.ID,E.GroupID,E.Title,E.SubTitle,E.ReleaseDate,E.Content,E.HomePageAreaID,E.IsDisplay,E.FileName FROM tg_Event E   WHERE (E.IsDelete = 0) AND (IsDisplay = 1) ORDER BY E.ReleaseDate DESC,E.ID Desc";
//        private const string SQL_SELECT_ALL_EVENT = "SELECT E.ID,E.GroupID,E.Title,E.SubTitle,E.ReleaseDate,E.Content,E.HomePageAreaID,E.IsDisplay,E.FileName FROM tg_Event E   WHERE (E.IsDelete = 0) ORDER BY E.ReleaseDate DESC,E.ID Desc";
//        private const string SQL_SELECT_ALL_EVENT_BY_GROUPID = "SELECT E.ID,E.GroupID,E.Title,E.SubTitle,E.ReleaseDate,E.Content,E.HomePageAreaID,E.IsDisplay,E.FileName FROM tg_Event E   WHERE (E.IsDelete = 0) AND (GroupID = @GroupID) ORDER BY E.ReleaseDate DESC,E.ID Desc";
//        private const string SQL_SELECT_ALL_DISPLAY_EVENT = "SELECT E.ID,E.GroupID,E.Title,E.SubTitle,E.ReleaseDate,E.Content,E.HomePageAreaID,E.IsDisplay,E.FileName FROM tg_Event E   WHERE (E.IsDelete = 0) AND (IsDisplay = 1) ORDER BY E.ReleaseDate DESC,E.ID Desc";
//        private const string SQL_SELECT_ALL_DISPLAY_EVENT_BY_GROUPID = "SELECT E.ID,E.GroupID,E.Title,E.SubTitle,E.ReleaseDate,E.Content,E.HomePageAreaID,E.IsDisplay,E.FileName FROM tg_Event E   WHERE (E.IsDelete = 0) AND (IsDisplay = 1) AND (GroupID = @GroupID) ORDER BY E.ReleaseDate DESC,E.ID Desc";
//        private const string SQL_SELECT_ALL_DISPLAY_EVENT_BY_HOMEPAGEAREAID = "SELECT E.ID,E.GroupID,E.Title,E.SubTitle,E.ReleaseDate,E.Content,E.HomePageAreaID,E.IsDisplay,E.FileName FROM tg_Event E   WHERE (E.IsDelete = 0) AND (IsDisplay = 1) AND (HomePageAreaID = @HomePageAreaID) ORDER BY E.ReleaseDate DESC,E.ID Desc";
//        private const string SQL_INSERT_EVENT = "Declare @ID int; Declare @ReturnValue int; INSERT INTO tg_Event (GroupID,Title,SubTitle,ReleaseDate,Content,HomePageAreaID,IsDisplay,FileName) VALUES(@GroupID,@Title,@SubTitle,@ReleaseDate,@Content,@HomePageAreaID,@IsDisplay,@FileName); SELECT @ID=@@IDENTITY; SELECT @ReturnValue=@@ERROR;SELECT @ID, @ReturnValue;";
//        private const string SQL_UPDATE_EVENT = " Declare @ReturnValue int; UPDATE tg_Event SET GroupID=@GroupID,Title=@Title,SubTitle=@SubTitle,ReleaseDate=@ReleaseDate,Content=@,HomePageAreaID=@HomePageAreaID,IsDisplay=@IsDisplay,FileName=@FileName  WHERE ID=@ID; SELECT @ReturnValue=@@ERROR;SELECT @ReturnValue;";
//        private const string SQL_REMOVE_EVENT = " Declare @ReturnValue int; UPDATE tg_Event SET IsDelete=1,DeletedDate=GetDate() WHERE ID=@ID; SELECT @ReturnValue=@@ERROR;SELECT @ReturnValue;";
    
//        public override Event GetEventById(int ID)
//        {
//            if (ID <= 0)
//            {
//                throw (new ArgumentOutOfRangeException("ID"));
//            }
//            OleDbCommand OleDbCmd = new OleDbCommand();
//            AddParamToOleDbCmd(OleDbCmd, "@ID", DbType.Int32, 0, ParameterDirection.Input, ID);
//            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_EVENT);
//            List<Event> eventList = new List<Event>();
//            TExecuteReaderCmd<Event>( OleDbCmd, TGenerateEventListFromReader<Event>, ref eventList);
//            if (eventList.Count > 0)
//                return eventList[0];
//            else
//                return null;
//        }
//        public override Event GetLastDisplayEvent( )
//        {
            
//            OleDbCommand OleDbCmd = new OleDbCommand();

//            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_LAST_DISPLAY_EVENT);
//            List<Event> eventList = new List<Event>();
//            TExecuteReaderCmd<Event>(OleDbCmd, TGenerateEventListFromReader<Event>, ref eventList);
//            if (eventList.Count > 0)
//                return eventList[0];
//            else
//                return null;
//        }
//        public override List<Event> GetEvent()
//        {
//            OleDbCommand OleDbCmd = new OleDbCommand();
//            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_EVENT);
//            List<Event> eventList = new List<Event>();
//            TExecuteReaderCmd<Event>(OleDbCmd, TGenerateEventListFromReader<Event>, ref eventList);
//            return eventList;
//        }
//        public override List<Event> GetEventByGroupID(int GroupID)
//        {

//            if (GroupID <= 0)
//            {
//                throw (new ArgumentOutOfRangeException("GroupID"));
//            }
//            OleDbCommand OleDbCmd = new OleDbCommand();
//            AddParamToOleDbCmd(OleDbCmd, "@GroupID",DbType.Int32, 0, ParameterDirection.Input, GroupID);
//            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_EVENT_BY_GROUPID);
//            List<Event> eventList = new List<Event>();
//            TExecuteReaderCmd<Event>(OleDbCmd, TGenerateEventListFromReader<Event>, ref eventList);
//            return eventList;
//        }
//        public override List<Event> GetDisplayEvent()
//        {
//            OleDbCommand OleDbCmd = new OleDbCommand();
//            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_DISPLAY_EVENT);
//            List<Event> eventList = new List<Event>();
//            TExecuteReaderCmd<Event>(OleDbCmd, TGenerateEventListFromReader<Event>, ref eventList);
//            return eventList;
//        }
//        public override List<Event> GetDisplayEventByGroupID(int GroupID)
//        {

//            if (GroupID <= 0)
//            {
//                throw (new ArgumentOutOfRangeException("GroupID"));
//            }
//            OleDbCommand OleDbCmd = new OleDbCommand();
//            AddParamToOleDbCmd(OleDbCmd, "@GroupID",DbType.Int32, 0, ParameterDirection.Input, GroupID);
//            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_DISPLAY_EVENT_BY_GROUPID);
//            List<Event> eventList = new List<Event>();
//            TExecuteReaderCmd<Event>(OleDbCmd, TGenerateEventListFromReader<Event>, ref eventList);
//            return eventList;
//        }
//        public override List<Event> GetDisplayEventByHomePageAreaID(int HomePageAreaID)
//        {

//            if (HomePageAreaID <= 0)
//            {
//                throw (new ArgumentOutOfRangeException("HomePageAreaID"));
//            }
//            OleDbCommand OleDbCmd = new OleDbCommand();
//            AddParamToOleDbCmd(OleDbCmd, "@HomePageAreaID", DbType.Int32, 0, ParameterDirection.Input, HomePageAreaID);
//            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_DISPLAY_EVENT_BY_HOMEPAGEAREAID);

//            List<Event> eventList = new List<Event>();
//            TExecuteReaderCmd<Event>(OleDbCmd, TGenerateEventListFromReader<Event>, ref eventList);


//            //OleDbConnection connection = new OleDbConnection(this.ConnectionString);
//            //connection.Open();
//            //OleDbCommand command;

//            //command = new OleDbCommand("SELECT E.ID,E.GroupID,E.Title,E.SubTitle,E.ReleaseDate,E.Content,E.HomePageAreaID,E.IsDisplay,E.FileName FROM tg_Event E   WHERE (E.IsDelete = 0) AND (IsDisplay = 1) AND (HomePageAreaID = @HomePageAreaID) ORDER BY E.ReleaseDate DESC,E.ID Desc",
//            //                           connection);

//            //command.Parameters.Add(new OleDbParameter("@HomePageAreaID", HomePageAreaID));
//            //OleDbDataReader reader = null;
//            //reader = command.ExecuteReader();
//            //List<Event> eventList = new List<Event>();
//            //TGenerateEventListFromReader<Event>(reader, ref  eventList);
//            //connection.Close();

//            return eventList;
//        }
//        public override int InsertEvent(int GroupID, string Title, string SubTitle, string ReleaseDate, string Content, int HomePageAreaID, bool IsDisplay, string FileName)
//        {

//            OleDbCommand OleDbCmd = new OleDbCommand();

//            AddParamToOleDbCmd(OleDbCmd, "@ReturnValue",DbType.Int32, 0, ParameterDirection.Output, null);
//            AddParamToOleDbCmd(OleDbCmd, "@ID",DbType.Int32, 0, ParameterDirection.Output, null);
            
//            AddParamToOleDbCmd(OleDbCmd, "@GroupID",DbType.Int32, 0, ParameterDirection.Input, GroupID);
//            AddParamToOleDbCmd(OleDbCmd, "@Title", DbType.String, 50, ParameterDirection.Input, Title);
//            AddParamToOleDbCmd(OleDbCmd, "@SubTitle", DbType.String, 200, ParameterDirection.Input, SubTitle);
//            AddParamToOleDbCmd(OleDbCmd, "@ReleaseDate", DbType.String, 50, ParameterDirection.Input, ReleaseDate);
//            AddParamToOleDbCmd(OleDbCmd, "@Content", DbType.String,0, ParameterDirection.Input, Content);
//            AddParamToOleDbCmd(OleDbCmd, "@HomePageAreaID",DbType.Int32, 0, ParameterDirection.Input, HomePageAreaID);
//            AddParamToOleDbCmd(OleDbCmd, "@IsDisplay", DbType.Boolean, 1, ParameterDirection.Input, IsDisplay);
//            AddParamToOleDbCmd(OleDbCmd, "@FileName", DbType.String, 50, ParameterDirection.Input, FileName);
           
//            SetCommandType(OleDbCmd, CommandType.Text, SQL_INSERT_EVENT);
//            ExecuteScalarCmd(OleDbCmd);

//            int ID = (int)OleDbCmd.Parameters["@ID"].Value;
//            int ReturnValue = (int)OleDbCmd.Parameters["@ReturnValue"].Value;
//            if (ReturnValue != 0)
//            {
//                throw new ApplicationException("DATA INTEGRITY ERROR ON Event INSERT - ROLLBACK ISSUED");
//            }
//            return (ID);

//        }
//        public override bool UpdateEvent(int ID, int GroupID, string Title, string SubTitle, string ReleaseDate, string Content, int HomePageAreaID, bool IsDisplay, string FileName)
//        {

//            OleDbCommand OleDbCmd = new OleDbCommand();

//            AddParamToOleDbCmd(OleDbCmd, "@ReturnValue",DbType.Int32, 0, ParameterDirection.Output, null);

//            AddParamToOleDbCmd(OleDbCmd, "@ID",DbType.Int32, 0, ParameterDirection.Input, ID);
//            AddParamToOleDbCmd(OleDbCmd, "@GroupID",DbType.Int32, 0, ParameterDirection.Input, GroupID);
//            AddParamToOleDbCmd(OleDbCmd, "@Title", DbType.String, 50, ParameterDirection.Input, Title);
//            AddParamToOleDbCmd(OleDbCmd, "@SubTitle", DbType.String, 200, ParameterDirection.Input, SubTitle);
//            AddParamToOleDbCmd(OleDbCmd, "@ReleaseDate", DbType.String, 50, ParameterDirection.Input, ReleaseDate);
//            AddParamToOleDbCmd(OleDbCmd, "@Content", DbType.String, 0, ParameterDirection.Input, Content);
//            AddParamToOleDbCmd(OleDbCmd, "@HomePageAreaID",DbType.Int32, 0, ParameterDirection.Input, HomePageAreaID);
//            AddParamToOleDbCmd(OleDbCmd, "@IsDisplay", DbType.Boolean, 1, ParameterDirection.Input, IsDisplay);
//            AddParamToOleDbCmd(OleDbCmd, "@FileName", DbType.String, 50, ParameterDirection.Input, FileName);

//            SetCommandType(OleDbCmd, CommandType.Text, SQL_UPDATE_EVENT);
//            ExecuteScalarCmd(OleDbCmd);


//            int returnValue = (int)OleDbCmd.Parameters["@ReturnValue"].Value;
//            if (returnValue != 0)
//            {
//                throw new ApplicationException("DATA INTEGRITY ERROR ON Event UPDATE - ROLLBACK ISSUED");
//            }
//            return (returnValue == 0 ? true : false);

//        }
//        public override bool RemoveEvent(int ID)
//        {

//            if (ID <= 0)
//                throw (new ArgumentOutOfRangeException("ID"));

//            OleDbCommand OleDbCmd = new OleDbCommand();

//            AddParamToOleDbCmd(OleDbCmd, "@ReturnValue",DbType.Int32, 0, ParameterDirection.ReturnValue, null);
//            AddParamToOleDbCmd(OleDbCmd, "@ID",DbType.Int32, 0, ParameterDirection.Input, ID);

//            SetCommandType(OleDbCmd, CommandType.Text, SQL_REMOVE_EVENT);
//            ExecuteScalarCmd(OleDbCmd);

//            int returnValue = (int)OleDbCmd.Parameters["@ReturnValue"].Value;

//            return (returnValue == 0 ? true : false);

//        }
//        #endregion

//        #region Category METHODS
//        //Static constants 
//        private const string SQL_SELECT_CATEGORY = "SELECT  ID,NAME,IsDisplay,IsHomePageDisplay FROM tg_Category WHERE (ID = @ID)";
//        private const string SQL_SELECT_FIRST_DISPLAY_CATEGORY = "SELECT TOP 1 ID,NAME,IsDisplay,IsHomePageDisplay FROM tg_Category WHERE (IsDelete = 0) AND (IsDisplay = 1) ORDER BY SortID ";
//        private const string SQL_SELECT_ALL_CATEGORY = "SELECT ID,NAME,IsDisplay,IsHomePageDisplay FROM tg_Category  WHERE (IsDelete = 0) ORDER BY  SortID";
//        private const string SQL_SELECT_ALL_DISPLAY_CATEGORY = "SELECT ID,NAME,IsDisplay,IsHomePageDisplay FROM  tg_Category WHERE (IsDelete = 0) AND (IsDisplay = 1) ORDER BY SortID";
//        private const string SQL_SELECT_ALL_HOMEPAGE_DISPLAY_CATEGORY = "SELECT ID,NAME,IsDisplay,IsHomePageDisplay FROM  tg_Category WHERE (IsDelete = 0) AND (IsDisplay = 1) AND (IsHomePageDisplay=1) ORDER BY SortID";
        
//        private const string SQL_INSERT_CATEGORY = "Declare @ID int; Declare @ReturnValue int; INSERT INTO tg_Category (Name,IsDisplay,IsHomePageDisplay) VALUES(@Name,@IsDisplay,@IsHomePageDisplay); SELECT @ID=@@IDENTITY; SELECT @ReturnValue=@@ERROR;SELECT @ID, @ReturnValue;";
//        private const string SQL_UPDATE_CATEGORY = " Declare @ReturnValue int; UPDATE tg_Category SET Name=@Name,IsDisplay=@IsDisplay,IsHomePageDisplay=@IsHomePageDisplay WHERE ID=@ID; SELECT @ReturnValue=@@ERROR;SELECT @ReturnValue;";
//        private const string SQL_REMOVE_CATEGORY = " Declare @ReturnValue int; UPDATE tg_Category SET IsDelete=1,DeletedDate=GetDate() WHERE ID=@ID; SELECT @ReturnValue=@@ERROR;SELECT @ReturnValue;";

//        public override Category GetCategoryById(int ID)
//        {
//            if (ID <= 0)
//            {
//                throw (new ArgumentOutOfRangeException("ID"));
//            }
//            OleDbCommand OleDbCmd = new OleDbCommand();
//            AddParamToOleDbCmd(OleDbCmd, "@ID",DbType.Int32, 0, ParameterDirection.Input, ID);
//            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_CATEGORY);
//            List<Category> CategoryList = new List<Category>();
//            TExecuteReaderCmd<Category>(OleDbCmd, TGenerateCategoryListFromReader<Category>, ref CategoryList);
//            if (CategoryList.Count > 0)
//                return CategoryList[0];
//            else
//                return null;
//        }
//        public override Category GetFirstDisplayCategory()
//        {

//            OleDbCommand OleDbCmd = new OleDbCommand();

//            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_FIRST_DISPLAY_CATEGORY);
//            List<Category> CategoryList = new List<Category>();
//            TExecuteReaderCmd<Category>(OleDbCmd, TGenerateCategoryListFromReader<Category>, ref CategoryList);
//            if (CategoryList.Count > 0)
//                return CategoryList[0];
//            else
//                return null;
//        }
//        public override List<Category> GetCategory()
//        {
//            OleDbCommand OleDbCmd = new OleDbCommand();
//            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_CATEGORY);
//            List<Category> CategoryList = new List<Category>();
//            TExecuteReaderCmd<Category>(OleDbCmd, TGenerateCategoryListFromReader<Category>, ref CategoryList);
//            return CategoryList;
//        }
//        public override List<Category> GetDisplayCategory()
//        {
//            OleDbCommand OleDbCmd = new OleDbCommand();
//            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_DISPLAY_CATEGORY);
//            List<Category> CategoryList = new List<Category>();
//            TExecuteReaderCmd<Category>(OleDbCmd, TGenerateCategoryListFromReader<Category>, ref CategoryList);
//            return CategoryList;
//        }
//        public override List<Category> GetHomePageDisplayCategory()
//        {
//            OleDbCommand OleDbCmd = new OleDbCommand();
//            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_HOMEPAGE_DISPLAY_CATEGORY);
//            List<Category> CategoryList = new List<Category>();
//            TExecuteReaderCmd<Category>(OleDbCmd, TGenerateCategoryListFromReader<Category>, ref CategoryList);
//            return CategoryList;
//        }
//        public override int InsertCategory(string Name, bool IsDisplay, bool IsHomePageDisplay)
//        {

//            OleDbCommand OleDbCmd = new OleDbCommand();

//            AddParamToOleDbCmd(OleDbCmd, "@ReturnValue",DbType.Int32, 0, ParameterDirection.Output, null);
//            AddParamToOleDbCmd(OleDbCmd, "@ID",DbType.Int32, 0, ParameterDirection.Output, null);
 
//            AddParamToOleDbCmd(OleDbCmd, "@Name", DbType.String, 50, ParameterDirection.Input, Name);
//            AddParamToOleDbCmd(OleDbCmd, "@IsDisplay", DbType.Boolean, 1, ParameterDirection.Input, IsDisplay);
//            AddParamToOleDbCmd(OleDbCmd, "@IsHomePageDisplay", DbType.Boolean, 1, ParameterDirection.Input, IsHomePageDisplay);
            
//            SetCommandType(OleDbCmd, CommandType.Text, SQL_INSERT_CATEGORY);
//            ExecuteScalarCmd(OleDbCmd);

//            int ID = (int)OleDbCmd.Parameters["@ID"].Value;
//            int ReturnValue = (int)OleDbCmd.Parameters["@ReturnValue"].Value;
//            if (ReturnValue != 0)
//            {
//                throw new ApplicationException("DATA INTEGRITY ERROR ON Category INSERT - ROLLBACK ISSUED");
//            }
//            return (ID);

//        }
//        public override bool UpdateCategory(int ID, string Name, bool IsDisplay, bool IsHomePageDisplay)
//        {

//            OleDbCommand OleDbCmd = new OleDbCommand();

//            AddParamToOleDbCmd(OleDbCmd, "@ReturnValue",DbType.Int32, 0, ParameterDirection.Output, null);

//            AddParamToOleDbCmd(OleDbCmd, "@ID",DbType.Int32, 0, ParameterDirection.Input, ID);
//            AddParamToOleDbCmd(OleDbCmd, "@Name", DbType.String, 50, ParameterDirection.Input, Name);
//            AddParamToOleDbCmd(OleDbCmd, "@IsDisplay", DbType.Boolean, 1, ParameterDirection.Input, IsDisplay);
//            AddParamToOleDbCmd(OleDbCmd, "@IsHomePageDisplay", DbType.Boolean, 1, ParameterDirection.Input, IsHomePageDisplay);

//            SetCommandType(OleDbCmd, CommandType.Text, SQL_UPDATE_CATEGORY);
//            ExecuteScalarCmd(OleDbCmd);


//            int returnValue = (int)OleDbCmd.Parameters["@ReturnValue"].Value;
//            if (returnValue != 0)
//            {
//                throw new ApplicationException("DATA INTEGRITY ERROR ON Category UPDATE - ROLLBACK ISSUED");
//            }
//            return (returnValue == 0 ? true : false);

//        }
//        public override bool RemoveCategory(int ID)
//        {

//            if (ID <= 0)
//                throw (new ArgumentOutOfRangeException("ID"));

//            OleDbCommand OleDbCmd = new OleDbCommand();

//            AddParamToOleDbCmd(OleDbCmd, "@ReturnValue",DbType.Int32, 0, ParameterDirection.ReturnValue, null);
//            AddParamToOleDbCmd(OleDbCmd, "@ID",DbType.Int32, 0, ParameterDirection.Input, ID);

//            SetCommandType(OleDbCmd, CommandType.Text, SQL_REMOVE_CATEGORY);
//            ExecuteScalarCmd(OleDbCmd);

//            int returnValue = (int)OleDbCmd.Parameters["@ReturnValue"].Value;

//            return (returnValue == 0 ? true : false);

//        }
//        #endregion

//        #region Product METHODS
//        //Static constants
//        private const string SQL_SELECT_PRODUCT = "SELECT ID, CategoryID, SKU, IsDisplay , FileName_Main, FileName_Thumb FROM tg_Product     WHERE (ID = @ID)";
//        private const string SQL_SELECT_LAST_DISPLAY_PRODUCT = "SELECT TOP 1 ID, CategoryID, SKU, IsDisplay , FileName_Main, FileName_Thumb FROM tg_Product     WHERE (IsDelete = 0) AND (IsDisplay = 1) ORDER BY SKU";
//        private const string SQL_SELECT_ALL_PRODUCT = "SELECT ID, CategoryID, SKU, IsDisplay , FileName_Main, FileName_Thumb FROM tg_Product     WHERE (IsDelete = 0) ORDER BY SKU";
//        private const string SQL_SELECT_ALL_PRODUCT_BY_GROUPID = "SELECT ID, CategoryID, SKU, IsDisplay , FileName_Main, FileName_Thumb FROM tg_Product     WHERE (IsDelete = 0) AND (CategoryID = @CategoryID) ORDER BY SKU";
//        private const string SQL_SELECT_ALL_DISPLAY_PRODUCT = "SELECT ID, CategoryID, SKU, IsDisplay , FileName_Main, FileName_Thumb FROM tg_Product     WHERE (IsDelete = 0) AND (IsDisplay = 1) ORDER BY SKU";
//        private const string SQL_SELECT_ALL_DISPLAY_PRODUCT_BY_GROUPID = "SELECT ID, CategoryID, SKU, IsDisplay , FileName_Main, FileName_Thumb FROM tg_Product     WHERE (IsDelete = 0) AND (IsDisplay = 1) AND (CategoryID = @CategoryID) ORDER BY  SKU";
//        private const string SQL_INSERT_PRODUCT = "Declare @ID int; Declare @ReturnValue int; INSERT INTO tg_Product (CategoryID, SKU, IsDisplay , FileName_Main, FileName_Thumb) VALUES(@CategoryID, @SKU, @IsDisplay , @FileName_Main, @FileName_Thumb); SELECT @ID=@@IDENTITY; SELECT @ReturnValue=@@ERROR;SELECT @ID, @ReturnValue;";
//        private const string SQL_UPDATE_PRODUCT = " Declare @ReturnValue int; UPDATE tg_Product SET CategoryID=@CategoryID, SKU=@SKU, IsDisplay=@IsDisplay , FileName_Main=@FileName_Main, FileName_Thumb=@FileName_Thumb  WHERE ID=@ID; SELECT @ReturnValue=@@ERROR;SELECT @ReturnValue;";
//        private const string SQL_REMOVE_PRODUCT = " Declare @ReturnValue int; UPDATE tg_Product SET IsDelete=1,DeletedDate=GetDate() WHERE ID=@ID; SELECT @ReturnValue=@@ERROR;SELECT @ReturnValue;";

//        public override Product GetProductById(int ID)
//        {
//            if (ID <= 0)
//            {
//                throw (new ArgumentOutOfRangeException("ID"));
//            }
//            OleDbCommand OleDbCmd = new OleDbCommand();
//            AddParamToOleDbCmd(OleDbCmd, "@ID",DbType.Int32, 0, ParameterDirection.Input, ID);
//            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_PRODUCT);
//            List<Product> productList = new List<Product>();
//            TExecuteReaderCmd<Product>(OleDbCmd, TGenerateProductListFromReader<Product>, ref productList);
//            if (productList.Count > 0)
//                return productList[0];
//            else
//                return null;
//        }
//        public override Product GetLastDisplayProduct()
//        {

//            OleDbCommand OleDbCmd = new OleDbCommand();

//            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_LAST_DISPLAY_PRODUCT);
//            List<Product> productList = new List<Product>();
//            TExecuteReaderCmd<Product>(OleDbCmd, TGenerateProductListFromReader<Product>, ref productList);
//            if (productList.Count > 0)
//                return productList[0];
//            else
//                return null;
//        }
//        public override List<Product> GetProduct()
//        {
//            OleDbCommand OleDbCmd = new OleDbCommand();
//            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_PRODUCT);
//            List<Product> productList = new List<Product>();
//            TExecuteReaderCmd<Product>(OleDbCmd, TGenerateProductListFromReader<Product>, ref productList);
//            return productList;
//        }
//        public override List<Product> GetProductByCategoryID(int CategoryID)
//        {

//            if (CategoryID <= 0)
//            {
//                throw (new ArgumentOutOfRangeException("CategoryID"));
//            }
//            OleDbCommand OleDbCmd = new OleDbCommand();
//            AddParamToOleDbCmd(OleDbCmd, "@CategoryID",DbType.Int32, 0, ParameterDirection.Input, CategoryID);
//            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_PRODUCT_BY_GROUPID);
//            List<Product> productList = new List<Product>();
//            TExecuteReaderCmd<Product>(OleDbCmd, TGenerateProductListFromReader<Product>, ref productList);
//            return productList;
//        }
//        public override List<Product> GetDisplayProduct()
//        {
//            OleDbCommand OleDbCmd = new OleDbCommand();
//            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_DISPLAY_PRODUCT);
//            List<Product> productList = new List<Product>();
//            TExecuteReaderCmd<Product>(OleDbCmd, TGenerateProductListFromReader<Product>, ref productList);
//            return productList;
//        }
//        public override List<Product> GetDisplayProductByCategoryID(int CategoryID)
//        {

//            if (CategoryID <= 0)
//            {
//                throw (new ArgumentOutOfRangeException("CategoryID"));
//            }
//            OleDbCommand OleDbCmd = new OleDbCommand();
//            AddParamToOleDbCmd(OleDbCmd, "@CategoryID",DbType.Int32, 0, ParameterDirection.Input, CategoryID);
//            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_DISPLAY_PRODUCT_BY_GROUPID);
//            List<Product> productList = new List<Product>();
//            TExecuteReaderCmd<Product>(OleDbCmd, TGenerateProductListFromReader<Product>, ref productList);
//            return productList;
//        }

//        public override int InsertProduct(int CategoryID, string SKU, bool IsDisplay, string FileName_Main, string FileName_Thumb)
//        {

//            OleDbCommand OleDbCmd = new OleDbCommand();

//            AddParamToOleDbCmd(OleDbCmd, "@ReturnValue",DbType.Int32, 0, ParameterDirection.Output, null);
//            AddParamToOleDbCmd(OleDbCmd, "@ID",DbType.Int32, 0, ParameterDirection.Output, null);

//            AddParamToOleDbCmd(OleDbCmd, "@CategoryID",DbType.Int32, 0, ParameterDirection.Input, CategoryID);
//            AddParamToOleDbCmd(OleDbCmd, "@SKU", DbType.String, 50, ParameterDirection.Input, SKU);
//            AddParamToOleDbCmd(OleDbCmd, "@IsDisplay", DbType.Boolean, 1, ParameterDirection.Input, IsDisplay);
//            AddParamToOleDbCmd(OleDbCmd, "@FileName_Main", DbType.String, 50, ParameterDirection.Input, FileName_Main);
//            AddParamToOleDbCmd(OleDbCmd, "@FileName_Thumb", DbType.String, 50, ParameterDirection.Input, FileName_Thumb);

//            SetCommandType(OleDbCmd, CommandType.Text, SQL_INSERT_PRODUCT);
//            ExecuteScalarCmd(OleDbCmd);

//            int ID = (int)OleDbCmd.Parameters["@ID"].Value;
//            int ReturnValue = (int)OleDbCmd.Parameters["@ReturnValue"].Value;
//            if (ReturnValue != 0)
//            {
//                throw new ApplicationException("DATA INTEGRITY ERROR ON Product INSERT - ROLLBACK ISSUED");
//            }
//            return (ID);

//        }
//        public override bool UpdateProduct(int ID, int CategoryID, string SKU, bool IsDisplay, string FileName_Main, string FileName_Thumb)
//        {

//            OleDbCommand OleDbCmd = new OleDbCommand();

//            AddParamToOleDbCmd(OleDbCmd, "@ReturnValue",DbType.Int32, 0, ParameterDirection.Output, null);

//            AddParamToOleDbCmd(OleDbCmd, "@ID",DbType.Int32, 0, ParameterDirection.Input, ID);
//            AddParamToOleDbCmd(OleDbCmd, "@CategoryID",DbType.Int32, 0, ParameterDirection.Input, CategoryID);
//            AddParamToOleDbCmd(OleDbCmd, "@SKU", DbType.String, 50, ParameterDirection.Input, SKU);
//            AddParamToOleDbCmd(OleDbCmd, "@IsDisplay", DbType.Boolean, 1, ParameterDirection.Input, IsDisplay);
//            AddParamToOleDbCmd(OleDbCmd, "@FileName_Main", DbType.String, 50, ParameterDirection.Input, FileName_Main);
//            AddParamToOleDbCmd(OleDbCmd, "@FileName_Thumb", DbType.String, 50, ParameterDirection.Input, FileName_Thumb);

//            SetCommandType(OleDbCmd, CommandType.Text, SQL_UPDATE_PRODUCT);
//            ExecuteScalarCmd(OleDbCmd);


//            int returnValue = (int)OleDbCmd.Parameters["@ReturnValue"].Value;
//            if (returnValue != 0)
//            {
//                throw new ApplicationException("DATA INTEGRITY ERROR ON Product UPDATE - ROLLBACK ISSUED");
//            }
//            return (returnValue == 0 ? true : false);

//        }
//        public override bool RemoveProduct(int ID)
//        {

//            if (ID <= 0)
//                throw (new ArgumentOutOfRangeException("ID"));

//            OleDbCommand OleDbCmd = new OleDbCommand();

//            AddParamToOleDbCmd(OleDbCmd, "@ReturnValue",DbType.Int32, 0, ParameterDirection.ReturnValue, null);
//            AddParamToOleDbCmd(OleDbCmd, "@ID",DbType.Int32, 0, ParameterDirection.Input, ID);

//            SetCommandType(OleDbCmd, CommandType.Text, SQL_REMOVE_PRODUCT);
//            ExecuteScalarCmd(OleDbCmd);

//            int returnValue = (int)OleDbCmd.Parameters["@ReturnValue"].Value;

//            return (returnValue == 0 ? true : false);

//        }
//        #endregion

//        #region Store METHODS
//        //Static constants
//        private const string SQL_SELECT_STORE = "SELECT S.ID, S.AreaID, S.StoreName, S.Tel,S.Address,S.IsDisplay,A.Name AS AreaName FROM tg_Store S INNER JOIN tg_StoreArea A  ON S.AreaID = A.ID  WHERE (ID = @ID)";
//        private const string SQL_SELECT_ALL_STORE = "SELECT S.ID, S.AreaID, S.StoreName, S.Tel,S.Address,S.IsDisplay,A.Name AS AreaName FROM tg_Store S INNER JOIN tg_StoreArea A  ON S.AreaID = A.ID WHERE (IsDelete = 0) ORDER BY A.ID,S.ID";
//        private const string SQL_SELECT_ALL_DISPLAY_STORE = "SELECT S.ID, S.AreaID, S.StoreName, S.Tel,S.Address,S.IsDisplay,A.Name AS AreaName FROM tg_Store S INNER JOIN tg_StoreArea A  ON S.AreaID = A.ID WHERE (IsDelete = 0) AND (IsDisplay = 1) ORDER BY A.ID,S.ID";
//        private const string SQL_SELECT_ALL_DISPLAY_STORE_BY_AREAID = "SELECT S.ID, S.AreaID, S.StoreName, S.Tel,S.Address,S.IsDisplay,A.Name AS AreaName FROM tg_Store S INNER JOIN tg_StoreArea A  ON S.AreaID = A.ID WHERE (IsDelete = 0) AND (IsDisplay = 1) AND (AreaID = @AreaID) ORDER BY  A.ID,S.ID";
//        private const string SQL_INSERT_STORE = "Declare @ID int; Declare @ReturnValue int; INSERT INTO tg_Store ( AreaID, StoreName, Tel,Address,IsDisplay) VALUES(  @AreaID, @StoreName, @Tel,@Address,@IsDisplay); SELECT @ID=@@IDENTITY; SELECT @ReturnValue=@@ERROR;SELECT @ID, @ReturnValue;";
//        private const string SQL_UPDATE_STORE = " Declare @ReturnValue int; UPDATE tg_Store SET  AreaID=@AreaID, StoreName=@StoreName, Tel=@Tel,Address=@Address,IsDisplay=@IsDisplay  WHERE ID=@ID; SELECT @ReturnValue=@@ERROR;SELECT @ReturnValue;";
//        private const string SQL_REMOVE_STORE = " Declare @ReturnValue int; UPDATE tg_Store SET IsDelete=1,DeletedDate=GetDate() WHERE ID=@ID; SELECT @ReturnValue=@@ERROR;SELECT @ReturnValue;";

//        public override Store GetStoreById(int ID)
//        {
//            if (ID <= 0)
//            {
//                throw (new ArgumentOutOfRangeException("ID"));
//            }
//            OleDbCommand OleDbCmd = new OleDbCommand();
//            AddParamToOleDbCmd(OleDbCmd, "@ID",DbType.Int32, 0, ParameterDirection.Input, ID);
//            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_STORE);
//            List<Store> storeList = new List<Store>();
//            TExecuteReaderCmd<Store>(OleDbCmd, TGenerateStoreListFromReader<Store>, ref storeList);
//            if (storeList.Count > 0)
//                return storeList[0];
//            else
//                return null;
//        }
//        public override List<Store> GetStore()
//        {
//            OleDbCommand OleDbCmd = new OleDbCommand();
//            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_STORE);
//            List<Store> storeList = new List<Store>();
//            TExecuteReaderCmd<Store>(OleDbCmd, TGenerateStoreListFromReader<Store>, ref storeList);
//            return storeList;
//        }
//        public override List<Store> GetDisplayStore()
//        {
//            OleDbCommand OleDbCmd = new OleDbCommand();
//            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_DISPLAY_STORE);
//            List<Store> storeList = new List<Store>();
//            TExecuteReaderCmd<Store>(OleDbCmd, TGenerateStoreListFromReader<Store>, ref storeList);
//            return storeList;
//        }
//        public override List<Store> GetDisplayStoreByArea(int AreaID)
//        {

//            if (AreaID <= 0)
//            {
//                throw (new ArgumentOutOfRangeException("AreaID"));
//            }
//            OleDbCommand OleDbCmd = new OleDbCommand();
//            AddParamToOleDbCmd(OleDbCmd, "@AreaID",DbType.Int32, 0, ParameterDirection.Input, AreaID);
//            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_DISPLAY_STORE_BY_AREAID);
//            List<Store> storeList = new List<Store>();
//            TExecuteReaderCmd<Store>(OleDbCmd, TGenerateStoreListFromReader<Store>, ref storeList);
//            return storeList;
//        }
//        public override int InsertStore(int AreaID, string StoreName, string Tel, string Address, bool IsDisplay)
//        {

//            OleDbCommand OleDbCmd = new OleDbCommand();

//            AddParamToOleDbCmd(OleDbCmd, "@ReturnValue",DbType.Int32, 0, ParameterDirection.Output, null);
//            AddParamToOleDbCmd(OleDbCmd, "@ID",DbType.Int32, 0, ParameterDirection.Output, null);

//            AddParamToOleDbCmd(OleDbCmd, "@AreaID",DbType.Int32, 0, ParameterDirection.Input, AreaID);
//            AddParamToOleDbCmd(OleDbCmd, "@StoreName", DbType.String, 50, ParameterDirection.Input, StoreName);
//            AddParamToOleDbCmd(OleDbCmd, "@IsDisplay", DbType.Boolean, 1, ParameterDirection.Input, IsDisplay);
//            AddParamToOleDbCmd(OleDbCmd, "@Tel", DbType.String, 50, ParameterDirection.Input, Tel);
//            AddParamToOleDbCmd(OleDbCmd, "@Address", DbType.String, 300, ParameterDirection.Input, Address);

//            SetCommandType(OleDbCmd, CommandType.Text, SQL_INSERT_STORE);
//            ExecuteScalarCmd(OleDbCmd);

//            int ID = (int)OleDbCmd.Parameters["@ID"].Value;
//            int ReturnValue = (int)OleDbCmd.Parameters["@ReturnValue"].Value;
//            if (ReturnValue != 0)
//            {
//                throw new ApplicationException("DATA INTEGRITY ERROR ON Store INSERT - ROLLBACK ISSUED");
//            }
//            return (ID);

//        }
//        public override bool UpdateStore(int ID, int AreaID, string StoreName, string Tel, string Address, bool IsDisplay)
//        {

//            OleDbCommand OleDbCmd = new OleDbCommand();

//            AddParamToOleDbCmd(OleDbCmd, "@ReturnValue",DbType.Int32, 0, ParameterDirection.Output, null);

//            AddParamToOleDbCmd(OleDbCmd, "@ID",DbType.Int32, 0, ParameterDirection.Input, ID);
//            AddParamToOleDbCmd(OleDbCmd, "@AreaID",DbType.Int32, 0, ParameterDirection.Input, AreaID);
//            AddParamToOleDbCmd(OleDbCmd, "@StoreName", DbType.String, 50, ParameterDirection.Input, StoreName);
//            AddParamToOleDbCmd(OleDbCmd, "@IsDisplay", DbType.Boolean, 1, ParameterDirection.Input, IsDisplay);
//            AddParamToOleDbCmd(OleDbCmd, "@Tel", DbType.String, 50, ParameterDirection.Input, Tel);
//            AddParamToOleDbCmd(OleDbCmd, "@Address", DbType.String, 300, ParameterDirection.Input, Address);

//            SetCommandType(OleDbCmd, CommandType.Text, SQL_UPDATE_STORE);
//            ExecuteScalarCmd(OleDbCmd);


//            int returnValue = (int)OleDbCmd.Parameters["@ReturnValue"].Value;
//            if (returnValue != 0)
//            {
//                throw new ApplicationException("DATA INTEGRITY ERROR ON Store UPDATE - ROLLBACK ISSUED");
//            }
//            return (returnValue == 0 ? true : false);

//        }
//        public override bool RemoveStore(int ID)
//        {

//            if (ID <= 0)
//                throw (new ArgumentOutOfRangeException("ID"));

//            OleDbCommand OleDbCmd = new OleDbCommand();

//            AddParamToOleDbCmd(OleDbCmd, "@ReturnValue",DbType.Int32, 0, ParameterDirection.ReturnValue, null);
//            AddParamToOleDbCmd(OleDbCmd, "@ID",DbType.Int32, 0, ParameterDirection.Input, ID);

//            SetCommandType(OleDbCmd, CommandType.Text, SQL_REMOVE_STORE);
//            ExecuteScalarCmd(OleDbCmd);

//            int returnValue = (int)OleDbCmd.Parameters["@ReturnValue"].Value;

//            return (returnValue == 0 ? true : false);

//        }

//        #endregion
//        /*****************************  GENARATE List HELPER METHODS *****************************/
//        #region GENARATE List HELPER METHODS

//        //Event
       
//        private void TGenerateEventListFromReader<T>(OleDbDataReader returnData, ref List<Event> evnetList)
//        {
          

//            while (returnData.Read())
//            {
//                //ID,GroupID,Title,ReleaseDate,Content,HomePageAreaID,IsDisplay,FileName
//                int ID = 0;
//                if (returnData["ID"] != DBNull.Value) { ID = Convert.ToInt32(returnData["ID"]); }

//                int GroupID = 0;
//                if (returnData["GroupID"] != DBNull.Value) { GroupID = Convert.ToInt32(returnData["GroupID"]); }

//                string Title = string.Empty;
//                if (returnData["Title"] != DBNull.Value) { Title = Convert.ToString(returnData["Title"]); }

//                string SubTitle = string.Empty;
//                if (returnData["SubTitle"] != DBNull.Value) { SubTitle = Convert.ToString(returnData["SubTitle"]); }

//                string ReleaseDate = string.Empty;
//                if (returnData["ReleaseDate"] != DBNull.Value) { ReleaseDate = Convert.ToString(returnData["ReleaseDate"]); }

//                string Content = string.Empty;
//                if (returnData["Content"] != DBNull.Value) { Content = Convert.ToString(returnData["Content"]); }

//                int HomePageAreaID = 0;
//                if (returnData["HomePageAreaID"] != DBNull.Value) { HomePageAreaID = Convert.ToInt32(returnData["HomePageAreaID"]); }

//                bool IsDisplay = false;
//                if (returnData["IsDisplay"] != DBNull.Value) { IsDisplay = Convert.ToBoolean(returnData["IsDisplay"]); }

//                string FileName = string.Empty;
//                if (returnData["FileName"] != DBNull.Value) { FileName = Convert.ToString(returnData["FileName"]); }

//                Event e2 = new Event(ID, GroupID, Title,SubTitle, ReleaseDate, Content, HomePageAreaID, IsDisplay, FileName);
//                evnetList.Add(e2);
//            }
          
//        }

//        //Category
//        private void TGenerateCategoryListFromReader<T>(OleDbDataReader returnData, ref List<Category> categoryList)
//        {
//            while (returnData.Read())
//            {
//                //int ID,   string Name, bool IsDisplay
//                int ID = 0;
//                if (returnData["ID"] != DBNull.Value) { ID = Convert.ToInt32(returnData["ID"]); }
 
//                string Name = string.Empty;
//                if (returnData["Name"] != DBNull.Value) { Name = Convert.ToString(returnData["Name"]); }
 
//                bool IsDisplay = false;
//                if (returnData["IsDisplay"] != DBNull.Value) { IsDisplay = Convert.ToBoolean(returnData["IsDisplay"]); }

//                bool IsHomePageDisplay = false;
//                if (returnData["IsHomePageDisplay"] != DBNull.Value) { IsHomePageDisplay = Convert.ToBoolean(returnData["IsHomePageDisplay"]); }

//                Category ct = new Category(ID, Name, IsDisplay ,IsHomePageDisplay);
//                categoryList.Add(ct);
//            }
//        }

//        //Product
//        private void TGenerateProductListFromReader<T>(OleDbDataReader returnData, ref List<Product> productList)
//        {
//            while (returnData.Read())
//            {
//                //int ID,int CategoryID,string SKU,bool IsDisplay ,string FileName_Main,string FileName_Thumb
//                int ID = 0;
//                if (returnData["ID"] != DBNull.Value) { ID = Convert.ToInt32(returnData["ID"]); }

//                int CategoryID = 0;
//                if (returnData["CategoryID"] != DBNull.Value) { CategoryID = Convert.ToInt32(returnData["CategoryID"]); }

//                string SKU = string.Empty;
//                if (returnData["SKU"] != DBNull.Value) { SKU = Convert.ToString(returnData["SKU"]); }

//                bool IsDisplay = false;
//                if (returnData["IsDisplay"] != DBNull.Value) { IsDisplay = Convert.ToBoolean(returnData["IsDisplay"]); }

//                string FileName_Main = string.Empty;
//                if (returnData["FileName_Main"] != DBNull.Value) { FileName_Main = Convert.ToString(returnData["FileName_Main"]); }

//                string FileName_Thumb = string.Empty;
//                if (returnData["FileName_Thumb"] != DBNull.Value) { FileName_Thumb = Convert.ToString(returnData["FileName_Thumb"]); }

//                Product pt = new Product(ID, CategoryID, SKU, IsDisplay, FileName_Main, FileName_Thumb);
//                productList.Add(pt);
//            }
//        }

//        //Store
//        private void TGenerateStoreListFromReader<T>(OleDbDataReader returnData, ref List<Store> storeList)
//        {
//            while (returnData.Read())
//            {
//                //int AreaID, string StoreName, string Tel, string Address, bool IsDisplay
//                int ID = 0;
//                if (returnData["ID"] != DBNull.Value) { ID = Convert.ToInt32(returnData["ID"]); }

//                int AreaID = 0;
//                if (returnData["AreaID"] != DBNull.Value) { AreaID = Convert.ToInt32(returnData["AreaID"]); }

//                string StoreName = string.Empty;
//                if (returnData["StoreName"] != DBNull.Value) { StoreName = Convert.ToString(returnData["StoreName"]); }

//                string Tel = string.Empty;
//                if (returnData["Tel"] != DBNull.Value) { Tel = Convert.ToString(returnData["Tel"]); }

//                string Address = string.Empty;
//                if (returnData["Address"] != DBNull.Value) { Address = Convert.ToString(returnData["Address"]); }

//                bool IsDisplay = false;
//                if (returnData["IsDisplay"] != DBNull.Value) { IsDisplay = Convert.ToBoolean(returnData["IsDisplay"]); }

//                string AreaName = string.Empty;
//                if (returnData["AreaName"] != DBNull.Value) { AreaName = Convert.ToString(returnData["AreaName"]); }

//                Store pt = new Store(ID, AreaID, StoreName, Tel, Address, IsDisplay);
//                pt.AreaName = AreaName;
//                storeList.Add(pt);
//            }
//        }
//        #endregion
 
//        /*****************************  SQL HELPER METHODS *****************************/
//        #region SQL HELPER METHODS
//        private void AddParamToOleDbCmd(OleDbCommand OleDbCmd,
//                                      string paramId,
//                                       DbType sqlType,
//                                      int paramSize,
//                                      ParameterDirection paramDirection,
//                                      object paramvalue)
//        {

//            if (OleDbCmd == null)
//                throw (new ArgumentNullException("OleDbCmd"));
//            if (paramId == string.Empty)
//                throw (new ArgumentOutOfRangeException("paramId"));

//            OleDbParameter newOleDbParam = new OleDbParameter();
//            newOleDbParam.ParameterName = paramId;
//            newOleDbParam.DbType = sqlType;
//            newOleDbParam.Direction = paramDirection;

//            if (paramSize > 0)
//                newOleDbParam.Size = paramSize;

//            if (paramvalue != null)
//                newOleDbParam.Value = paramvalue;

//            OleDbCmd.Parameters.Add(newOleDbParam);
//        }

//        private void ExecuteScalarCmd(OleDbCommand OleDbCmd)
//        {
//            if (ConnectionString == string.Empty)
//                throw (new ArgumentOutOfRangeException("ConnectionString"));

//            if (OleDbCmd == null)
//                throw (new ArgumentNullException("OleDbCmd"));

//           
//            using (OleDbConnection cn =   new OleDbConnection(this.ConnectionString))
//            {
//                OleDbCmd.Connection = cn;
//                cn.Open();
//                OleDbCmd.ExecuteScalar();
//            }
//        }

//        private void SetCommandType(OleDbCommand OleDbCmd, CommandType cmdType, string cmdText)
//        {
//            OleDbCmd.CommandType = cmdType;
//            OleDbCmd.CommandText = cmdText;
//        }

     
//        private void TExecuteReaderCmd<T>(OleDbCommand OleDbCmd, TGenerateListFromReader<T> gcfr, ref List<T> List)
//        {
//            if (ConnectionString == string.Empty)
//                throw (new ArgumentOutOfRangeException("ConnectionString"));

//            if (OleDbCmd == null)
//                throw (new ArgumentNullException("OleDbCmd"));
           
           
//             using (OleDbConnection cn =   new OleDbConnection(this.ConnectionString))
//            {
//                OleDbCmd.Connection = cn;
//                cn.Open();
//                OleDbDataReader reader = OleDbCmd.ExecuteReader();
//                gcfr(reader, ref List);
//            }
//        }
//        #endregion

        
//    }
//}