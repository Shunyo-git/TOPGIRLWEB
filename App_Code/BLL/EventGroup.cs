using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;

namespace TopGirl.BusinessLogicLayer
{
    /// <summary>
    /// EventGroup 的摘要描述
    /// </summary>
    public class EventGroup
    {
        private int _groupID;
        private string _name;
        private bool _isDisplay;

        public EventGroup()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }

        public EventGroup(int GroupID, string Name, bool IsDisplay)
        {
            this.GroupID = GroupID;
            this.Name = Name;
            this.IsDisplay = IsDisplay;
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

        public static List<EventGroup> GetGroup() {
            List<EventGroup> groupList = new List<EventGroup>();
            for (int i = 1; i <= 5;i++ )
            {
                EventGroup eg = new EventGroup(i, GetGroupName(i), true);
                groupList.Add(eg);
            }
            return groupList;
        }

        public static EventGroup GetGroup(int GroupID)
        {
            if (GroupID > 0 & GroupID<=5)
            {
            return new EventGroup(GroupID, GetGroupName(GroupID), true);
            }
            return null;
        }

        public static string GetGroupName(int GroupID)
        {
            switch (GroupID)
            {
                case 1:
                    return "促銷活動";
                    break;
                case 2:
                    return "新聞稿";
                    break;
                case 3:
                    return "新櫃登場";
                    break;
                case 4:
                    return "展場活動";
                    break;
                case 5:
                    return "記者會及服裝秀";
                    break;
                default:
                    return string.Empty;
                    break;
            }


        }
    }
}