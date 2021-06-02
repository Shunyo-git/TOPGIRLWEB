using System;
using System.Configuration;

using TopGirl.IProfileDAL;
/// <summary>
/// Summary description for DataAccessHelper
/// </summary>
namespace TopGirl.DataAccessLayer
{
    public class DataAccessHelper
    {
        public static DataAccess GetDataAccess()
        {
            string dataAccessStringType = ConfigurationManager.AppSettings["DataAccessLayerType"];
            if (String.IsNullOrEmpty(dataAccessStringType))
            {
                throw (new NullReferenceException("ConnectionString configuration is missing from you web.config. It should contain  <appSettings> <add key=\"DataAccessLayerType\" value=\"TopGirl.SQLDataAccessProvider\" </appSettings>"));
            }
            else
            {
                Type dataAccessType = Type.GetType(dataAccessStringType);
                if (dataAccessType == null)
                {
                    throw (new NullReferenceException("DataAccessType can not be found"));
                }

                Type tp = Type.GetType("TopGirl.DataAccessLayer.SQLDataAccessProvider");
                if (!tp.IsAssignableFrom(dataAccessType))
                {
                    throw (new ArgumentException("DataAccessType does not inherits from TopGirl.DataAccessLayer.SQLDataAccessProvider "));

                }
                DataAccess dc = (DataAccess)Activator.CreateInstance(dataAccessType);
                return (dc);
            }
        }



        public static ISQLProfileProvider CreateTopGirlProfileProvider()
        {
            //string dataAccessStringType = ConfigurationManager.AppSettings["ProfileDAL"];
            //if (String.IsNullOrEmpty(dataAccessStringType))
            //{
            //    throw (new NullReferenceException("ConnectionString configuration is missing from you web.config. It should contain  <appSettings> <add key=\"ProfileDAL\" value=\"TopGirl.DataAccessLayer.SQLProfileDataAccessProvider\" </appSettings>"));
            //}
            //else
            //{

            //    Type dataAccessType = Type.GetType(dataAccessStringType);
            //    if (dataAccessType == null)
            //    {
            //        throw (new NullReferenceException("DataAccessType can not be found"));
            //    }

            //    Type tp = Type.GetType("TopGirl.DataAccessLayer.SQLProfileDataAccessProvider");
            //    if (!tp.IsAssignableFrom(dataAccessType))
            //    {
            //        throw (new ArgumentException("DataAccessType does not inherits from TopGirl.DataAccessLayer.SQLProfileDataAccessProvider "));

            //    }
            //    SQLProfileProvider dc = (SQLProfileProvider)Activator.CreateInstance(dataAccessType);
            //    return (dc);
            //}

            //string className = profilePath + ".TopGirlProfileProvider";
            ////return (FSonline.IProfileDAL.IFSonlineProfileProvider)Assembly.Load(profilePath).CreateInstance(className);
            return new SQLProfileProvider();
        }

    }
}
