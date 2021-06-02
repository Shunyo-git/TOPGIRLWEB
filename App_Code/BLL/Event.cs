using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using TopGirl.DataAccessLayer;

namespace TopGirl.BusinessLogicLayer
{

    /// <summary>
    /// Event 的摘要描述
    /// </summary>
    public class Event
    {
        private int _id;
        private int _groupID;
        private string _title;
        private string _subTitle;
        private string _releaseDate;
        private string _content;
        private int _homePageAreaID;
        private bool _isDisplay;
        private string _fileName;

        public Event()
        {

        }

        public Event(int ID, int GroupID, string Title, string SubTitle, string ReleaseDate, string Content, int HomePageAreaID, bool IsDisplay, string FileName)
        {
            this.ID = ID;
            this.GroupID = GroupID;
            this.Title = Title;
            this.SubTitle = SubTitle;
            this.ReleaseDate = ReleaseDate;
            this.Content = Content;
            this.HomePageAreaID = HomePageAreaID;
            this.IsDisplay = IsDisplay;
            this.FileName = FileName;
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

        public int GroupID
        {
            get
            {
                return _groupID;
            }
            set
            {
                _groupID = value;
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }
        public string SubTitle
        {
            get
            {
                return _subTitle;
            }
            set
            {
                _subTitle = value;
            }
        }

        public string ReleaseDate
        {
            get
            {
                return _releaseDate;
            }
            set
            {
                _releaseDate = value;
            }
        }

        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
            }
        }

        public int HomePageAreaID
        {
            get
            {
                return _homePageAreaID;
            }
            set
            {
                _homePageAreaID = value;
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

        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                _fileName = value;
            }
        }

        /*** METHODS  ***/
        public bool Remove()
        {

            return Remove(this.ID);
        }
         
        public bool Save()
        {

            DataAccess  DALLayer = DataAccessHelper.GetDataAccess();
            if (ID > 0)
            {

                return DALLayer.UpdateEvent(this.ID, this.GroupID, this.Title,this.SubTitle, this.ReleaseDate, this.Content, this.HomePageAreaID, this.IsDisplay, this.FileName);
            }
            else
            {
                ID = DALLayer.InsertEvent(this.GroupID, this.Title, this.SubTitle, this.ReleaseDate, this.Content, this.HomePageAreaID, this.IsDisplay, this.FileName);
                return (ID > 0);
            }
            
        }

        /*** METHOD STATIC ***/
        public static bool Remove(int ID)
        {
            if (ID > 0)
            {
                DataAccess DALLayer = DataAccessHelper.GetDataAccess();
                return DALLayer.RemoveEvent(ID);
            }
            else
                return false;
        }

        public static Event GetEventById(int ID)
        {
            if (ID <= 0)
                return (null);

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetEventById(ID));
        }
        public static Event GetLastDisplayEvent()
        {
           
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetLastDisplayEvent());
        }
        public static List<Event> GetEvent()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetEvent());
        }
        public static List<Event> GetEvent(string sortParameter)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            List<Event> eventList = DALLayer.GetEvent();

            if (!String.IsNullOrEmpty(sortParameter))
                eventList.Sort(new EventComparer(sortParameter));
            return (eventList);
        }
        public static List<Event> GetEventByGroupID(int GroupID)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetEventByGroupID(GroupID));
        }
        public static List<Event> GetDisplayEvent()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetDisplayEvent());
        }
        public static List<Event> GetDisplayEventByGroupID(int GroupID)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetDisplayEventByGroupID(GroupID));
        }
        public static List<Event> GetDisplayEventByHomePageAreaID(int HomePageAreaID)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetDisplayEventByHomePageAreaID(HomePageAreaID));
        }
        public static string GetHomePageAreaName(int HomePageAreaID)
        {
            switch (HomePageAreaID)
            {
                case 1:
                    return "本季活動快訊";
                    break;
                case 2:
                    return "最新消息";
                    break;
                default:
                    return string.Empty;
                    break;
            }


        }
    }
}
