
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TopGirl.DBUtility;
using TopGirl.BusinessLogicLayer;
using TopGirl.IProfileDAL;

namespace TopGirl.DataAccessLayer
{
   public class SQLProfileProvider  : ISQLProfileProvider
    {

        // Contst matching System.Web.Profile.ProfileAuthenticationOption.Anonymous
        private const int AUTH_ANONYMOUS = 0;

        // Contst matching System.Web.Profile.ProfileAuthenticationOption.Authenticated
        private const int AUTH_AUTHENTICATED = 1;

        // Contst matching System.Web.Profile.ProfileAuthenticationOption.All
        private const int AUTH_ALL = 2;

        /// <summary>
        /// Retrieve account information for current username and application.
        /// </summary>
        /// <param name="userName">User Name</param>
        /// <param name="appName">Application Name</param>
        /// <returns>Account information for current user</returns>
        public MemberInfo GetMemberInfo(string userName, string appName)
        {

            string sqlSelect = "SELECT  M.ChineseName,M.Gender,M.Birthday,M.Telphone,M.MobilePhone,M.Address,M.Career,M.Marital,M.IsSubscription,M.IsMemberCard FROM tg_MemberInfo M INNER JOIN tg_Profiles P ON M.UID = P.UID WHERE M.IsDelete=0 AND P.Username = @Username AND P.ApplicationName = @ApplicationName;";
            SqlParameter[] parms = {					   
				new SqlParameter("@Username", SqlDbType.VarChar, 256),
				new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256)};
            parms[0].Value = userName;
            parms[1].Value = appName;

            MemberInfo memberinfo = null;

            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, sqlSelect, parms);
            while (dr.Read())
            {
                DateTime birth = DateTime.MinValue;
                if (!dr.IsDBNull(2))
                {
                    birth = dr.GetDateTime(2);
                }
                MemberInfo.GenderType gender = MemberInfo.GenderType.unknown;
  
                switch (dr.GetInt32(1))
                {
                    case 0:
                        gender = MemberInfo.GenderType.unknown;
                        break;
                    case 1:
                        gender = MemberInfo.GenderType.male;
                        break;
                    case 2:
                        gender = MemberInfo.GenderType.female;
                        break;
                    default:
                        break;
                }


                //1 chineseName, 2 gender, 3 birthday, 4 telphone, 5 mobilePhone, 6 address, 7 career, 8 marital, 9 IsSubscription, 10 IsMemberCard
                memberinfo = new MemberInfo(dr.GetString(0), gender,birth, dr.GetString(3), dr.GetString(4), dr.GetString(5), dr.GetString(6), dr.GetString(7), dr.GetBoolean(8), dr.GetBoolean(9) );
            }
            dr.Close();

            return memberinfo;
        }

        /// <summary>
        /// Update account for current user
        /// </summary>
        /// <param name="uniqueID">User id</param>
        /// <param name="addressInfo">Account information for current user</param>   
        public void SetMemberInfo(int uniqueID, MemberInfo memberInfo)
        {
            string sqlDelete = "UPDATE tg_MemberInfo SET IsDelete = 1 ,DeletedDate = GetDate() WHERE UID = @UniqueID;";
            SqlParameter param = new SqlParameter("@UniqueID", SqlDbType.Int);
            param.Value = uniqueID;

            string sqlInsert = "INSERT INTO tg_MemberInfo (UID, ChineseName,Gender,Birthday,Telphone,MobilePhone,Address,Career,Marital,IsSubscription,IsMemberCard) VALUES (@UniqueID, @ChineseName,@Gender,@Birthday,@Telphone,@MobilePhone,@Address,@Career,@Marital,@IsSubscription,@IsMemberCard);";

            SqlParameter[] parms = {					   
			new SqlParameter("@UniqueID", SqlDbType.Int),
			new SqlParameter("@ChineseName", SqlDbType.NVarChar, 50),
			new SqlParameter("@Gender", SqlDbType.NVarChar, 50),
			new SqlParameter("@Birthday", SqlDbType.DateTime, 8),
			new SqlParameter("@Telphone", SqlDbType.NVarChar,50),
			new SqlParameter("@MobilePhone", SqlDbType.NVarChar, 50),
			new SqlParameter("@Address", SqlDbType.NVarChar, 300),
			new SqlParameter("@Career", SqlDbType.NVarChar, 50),
			new SqlParameter("@addr", SqlDbType.NVarChar, 200),
			new SqlParameter("@Marital", SqlDbType.NVarChar, 50),
			new SqlParameter("@IsSubscription", SqlDbType.Bit, 1) ,
            new SqlParameter("@IsMemberCard", SqlDbType.Bit, 1) };

            parms[0].Value = uniqueID;
            parms[1].Value = memberInfo.ChineseName;
            parms[2].Value = Convert.ToInt16(memberInfo.Gender);
            parms[3].Value = memberInfo.Birthday;
            parms[4].Value = memberInfo.Telphone ;
            parms[5].Value = memberInfo.MobilePhone;
            parms[6].Value = memberInfo.Address;
            parms[7].Value = memberInfo.Career;
            parms[8].Value = memberInfo.Address;
            parms[9].Value = memberInfo.Marital;
            parms[10].Value = memberInfo.IsSubscription;
            parms[11].Value = memberInfo.IsMemberCard;
            SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringProfile);
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sqlDelete, param);
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sqlInsert, parms);
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();
                throw new ApplicationException(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }




        /// <summary>
        /// Update activity dates for current user and application
        /// </summary>
        /// <param name="userName">USer name</param>
        /// <param name="activityOnly">Activity only flag</param>
        /// <param name="appName">Application Name</param>
        public void UpdateActivityDates(string userName, bool activityOnly, string appName)
        {
            DateTime activityDate = DateTime.Now;

            string sqlUpdate;
            SqlParameter[] parms;

            if (activityOnly)
            {
                sqlUpdate = "UPDATE tg_Profiles Set LastActivityDate = @LastActivityDate WHERE IsDelete = 0 AND Username = @Username AND ApplicationName = @ApplicationName;";
                parms = new SqlParameter[]{						   
					new SqlParameter("@LastActivityDate", SqlDbType.DateTime),
					new SqlParameter("@Username", SqlDbType.VarChar, 256),
					new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256)};

                parms[0].Value = activityDate;
                parms[1].Value = userName;
                parms[2].Value = appName;

            }
            else
            {
                sqlUpdate = "UPDATE tg_Profiles Set LastActivityDate = @LastActivityDate, LastUpdatedDate = @LastUpdatedDate WHERE IsDelete = 0 AND Username = @Username AND ApplicationName = @ApplicationName;";
                parms = new SqlParameter[]{
					new SqlParameter("@LastActivityDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdatedDate", SqlDbType.DateTime),
					new SqlParameter("@Username", SqlDbType.VarChar, 256),
					new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256)};

                parms[0].Value = activityDate;
                parms[1].Value = activityDate;
                parms[2].Value = userName;
                parms[3].Value = appName;
            }

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, sqlUpdate, parms);

        }

        /// <summary>
        /// Retrive unique id for current user
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="isAuthenticated">Authentication flag</param>
        /// <param name="ignoreAuthenticationType">Ignore authentication flag</param>
        /// <param name="appName">Application Name</param>
        /// <returns>Unique id for current user</returns>
        public int GetUniqueID(string userName, bool isAuthenticated, bool ignoreAuthenticationType, string appName)
        {
            string sqlSelect = "SELECT UID FROM tg_Profiles WHERE IsDelete = 0 AND Username = @Username AND ApplicationName = @ApplicationName";

            SqlParameter[] parms = {
				new SqlParameter("@Username", SqlDbType.VarChar, 256),
				new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256)};
            parms[0].Value = userName;
            parms[1].Value = appName;

            if (!ignoreAuthenticationType)
            {
                sqlSelect += " AND IsAnonymous = @IsAnonymous";
                Array.Resize<SqlParameter>(ref parms, parms.Length + 1);
                parms[2] = new SqlParameter("@IsAnonymous", SqlDbType.Bit);
                parms[2].Value = !isAuthenticated;
            }

            int uniqueID = 0;

            object retVal = null;
            retVal = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, sqlSelect, parms);

            if (retVal == null)
                uniqueID = CreateProfileForUser(userName, isAuthenticated, appName);
            else
                uniqueID = Convert.ToInt32(retVal);
            return uniqueID;
        }

        /// <summary>
        /// Create profile record for current user
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="isAuthenticated">Authentication flag</param>
        /// <param name="appName">Application Name</param>
        /// <returns>Number of records created</returns>
        public int CreateProfileForUser(string userName, bool isAuthenticated, string appName)
        {

            string sqlInsert = "INSERT INTO tg_Profiles (Username, ApplicationName, LastActivityDate, LastUpdatedDate, IsAnonymous) Values(@Username, @ApplicationName, @LastActivityDate, @LastUpdatedDate, @IsAnonymous); SELECT @@IDENTITY;";

            SqlParameter[] parms = {
				new SqlParameter("@Username", SqlDbType.VarChar, 256),
				new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256),
				new SqlParameter("@LastActivityDate", SqlDbType.DateTime),
				new SqlParameter("@LastUpdatedDate", SqlDbType.DateTime),
				new SqlParameter("@IsAnonymous", SqlDbType.Bit)};

            parms[0].Value = userName;
            parms[1].Value = appName;
            parms[2].Value = DateTime.Now;
            parms[3].Value = DateTime.Now;
            parms[4].Value = !isAuthenticated;

            int uniqueID = 0;
            int.TryParse(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, sqlInsert, parms).ToString(), out uniqueID);

            return uniqueID;
        }

        /// <summary>
        /// Retrieve colection of inactive user id's
        /// </summary>
        /// <param name="authenticationOption">Authentication option</param>
        /// <param name="userInactiveSinceDate">Date to start search from</param>
        /// <param name="appName">Application Name</param>
        /// <returns>Collection of inactive profile id's</returns>
        public IList<string> GetInactiveProfiles(int authenticationOption, DateTime userInactiveSinceDate, string appName)
        {

            StringBuilder sqlSelect = new StringBuilder("SELECT Username FROM tg_Profiles WHERE IsDelete = 0 AND ApplicationName = @ApplicationName AND LastActivityDate <= @LastActivityDate");

            SqlParameter[] parms = {
				new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256),
				new SqlParameter("@LastActivityDate", SqlDbType.DateTime)};
            parms[0].Value = appName;
            parms[1].Value = userInactiveSinceDate;

            switch (authenticationOption)
            {
                case AUTH_ANONYMOUS:
                    sqlSelect.Append(" AND IsAnonymous = @IsAnonymous");
                    Array.Resize<SqlParameter>(ref parms, parms.Length + 1);
                    parms[2] = new SqlParameter("@IsAnonymous", SqlDbType.Bit);
                    parms[2].Value = true;
                    break;
                case AUTH_AUTHENTICATED:
                    sqlSelect.Append(" AND IsAnonymous = @IsAnonymous");
                    Array.Resize<SqlParameter>(ref parms, parms.Length + 1);
                    parms[2] = new SqlParameter("@IsAnonymous", SqlDbType.Bit);
                    parms[2].Value = false;
                    break;
                default:
                    break;
            }

            IList<string> usernames = new List<string>();

            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, sqlSelect.ToString(), parms);
            while (dr.Read())
            {
                usernames.Add(dr.GetString(0));
            }

            dr.Close();
            return usernames;
        }

        /// <summary>
        /// Delete user's profile
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="appName">Application Name</param>
        /// <returns>True, if profile successfully deleted</returns>
        public bool DeleteProfile(string userName, string appName)
        {

            int uniqueID = GetUniqueID(userName, false, true, appName);

            string sqlDelete = "UPDATE tg_Profiles SET IsDelete=1 AND DeletedDate = GetDate() WHERE UID = @UniqueID;";
            SqlParameter param = new SqlParameter("@UniqueId", SqlDbType.Int, 4);
            param.Value = uniqueID;

            int numDeleted = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, sqlDelete, param);

            if (numDeleted <= 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Retrieve profile information
        /// </summary>
        /// <param name="authenticationOption">Authentication option</param>
        /// <param name="usernameToMatch">User name</param>
        /// <param name="userInactiveSinceDate">Date to start search from</param>
        /// <param name="appName">Application Name</param>
        /// <param name="totalRecords">Number of records to return</param>
        /// <returns>Collection of profiles</returns>
        public IList<CustomProfileInfo> GetProfileInfo(int authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, string appName, out int totalRecords)
        {

            // Retrieve the total count.
            StringBuilder sqlSelect1 = new StringBuilder("SELECT COUNT(*) FROM tg_Profiles WHERE IsDelete = 0 AND ApplicationName = @ApplicationName");
            SqlParameter[] parms1 = {
				new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256)};
            parms1[0].Value = appName;

            // Retrieve the profile data.
            StringBuilder sqlSelect2 = new StringBuilder("SELECT Username, LastActivityDate, LastUpdatedDate, IsAnonymous FROM tg_Profiles WHERE IsDelete = 0 AND ApplicationName = @ApplicationName");
            SqlParameter[] parms2 = { new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256) };
            parms2[0].Value = appName;

            int arraySize;

            // If searching for a user name to match, add the command text and parameters.
            if (usernameToMatch != null)
            {
                arraySize = parms1.Length;

                sqlSelect1.Append(" AND Username LIKE @Username ");
                Array.Resize<SqlParameter>(ref parms1, arraySize + 1);
                parms1[arraySize] = new SqlParameter("@Username", SqlDbType.VarChar, 256);
                parms1[arraySize].Value = usernameToMatch;

                sqlSelect2.Append(" AND Username LIKE @Username ");
                Array.Resize<SqlParameter>(ref parms2, arraySize + 1);
                parms2[arraySize] = new SqlParameter("@Username", SqlDbType.VarChar, 256);
                parms2[arraySize].Value = usernameToMatch;
            }


            // If searching for inactive profiles, 
            // add the command text and parameters.
            if (userInactiveSinceDate != null)
            {
                arraySize = parms1.Length;

                sqlSelect1.Append(" AND LastActivityDate >= @LastActivityDate ");
                Array.Resize<SqlParameter>(ref parms1, arraySize + 1);
                parms1[arraySize] = new SqlParameter("@LastActivityDate", SqlDbType.DateTime);
                parms1[arraySize].Value = (DateTime)userInactiveSinceDate;

                sqlSelect2.Append(" AND LastActivityDate >= @LastActivityDate ");
                Array.Resize<SqlParameter>(ref parms2, arraySize + 1);
                parms2[arraySize] = new SqlParameter("@LastActivityDate", SqlDbType.DateTime);
                parms2[arraySize].Value = (DateTime)userInactiveSinceDate;
            }


            // If searching for a anonymous or authenticated profiles,    
            // add the command text and parameters.	
            if (authenticationOption != AUTH_ALL)
            {
                arraySize = parms1.Length;

                Array.Resize<SqlParameter>(ref parms1, arraySize + 1);
                sqlSelect1.Append(" AND IsAnonymous = @IsAnonymous");
                parms1[arraySize] = new SqlParameter("@IsAnonymous", SqlDbType.Bit);

                Array.Resize<SqlParameter>(ref parms2, arraySize + 1);
                sqlSelect2.Append(" AND IsAnonymous = @IsAnonymous");
                parms2[arraySize] = new SqlParameter("@IsAnonymous", SqlDbType.Bit);

                switch (authenticationOption)
                {
                    case AUTH_ANONYMOUS:
                        parms1[arraySize].Value = true;
                        parms2[arraySize].Value = true;
                        break;
                    case AUTH_AUTHENTICATED:
                        parms1[arraySize].Value = false;
                        parms2[arraySize].Value = false;
                        break;
                    default:
                        break;
                }
            }

            IList<CustomProfileInfo> profiles = new List<CustomProfileInfo>();

            // Get the profile count.
            totalRecords = (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, sqlSelect1.ToString(), parms1);

            // No profiles found.
            if (totalRecords <= 0)
                return profiles;

            SqlDataReader dr;
            dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, sqlSelect2.ToString(), parms2);
            while (dr.Read())
            {
                CustomProfileInfo profile = new CustomProfileInfo(dr.GetString(0), dr.GetDateTime(1), dr.GetDateTime(2), dr.GetBoolean(3));
                profiles.Add(profile);
            }
            dr.Close();

            return profiles;
        }
    }
}

