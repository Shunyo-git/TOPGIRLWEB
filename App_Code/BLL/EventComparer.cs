using System;
using System.Collections.Generic;


namespace TopGirl.BusinessLogicLayer
{

    /// <summary>
    /// EventComparer 的摘要描述
    /// </summary>
    public class EventComparer : IComparer<Event>
    {
        private string _sortColumn;
        private bool _reverse;


        public EventComparer(string sortEx)
        {
            if (!String.IsNullOrEmpty(sortEx))
            {
                _reverse = sortEx.ToLowerInvariant().EndsWith(" desc");
                if (_reverse)
                    _sortColumn = sortEx.Substring(0, sortEx.Length - 5);
                else
                    _sortColumn = sortEx;
            }
        }
        public bool Equals(Event x, Event y)
        {
            if (x.ID == y.ID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Compare(Event x, Event y)
        {
            int retVal = 0;
            switch (_sortColumn.Trim())
            {

                case "ID":
                    retVal = (x.ID - y.ID);
                    break;
                case "GroupID":
                    retVal = (x.GroupID - y.GroupID);
                    break;
                case "HomePageAreaID":
                    retVal = (x.HomePageAreaID - y.HomePageAreaID);
                    break;
                case "Title":
                    retVal = String.Compare(x.Title, y.Title, StringComparison.InvariantCultureIgnoreCase);
                    break;
                case "SubTitle":
                    retVal = String.Compare(x.SubTitle, y.SubTitle, StringComparison.InvariantCultureIgnoreCase);
                    break;
                case "ReleaseDate":
                    retVal = String.Compare(x.ReleaseDate, y.ReleaseDate, StringComparison.InvariantCultureIgnoreCase);
                    break;
                case "IsDisplay":
                    retVal =  Convert.ToInt32(x.IsDisplay) -  Convert.ToInt32(y.IsDisplay);
                    break;

                //case "ReleaseDate":
                //    System.TimeSpan TS = new System.TimeSpan(x.DisplayDate.Ticks - y.DisplayDate.Ticks);
                //    retVal = Convert.ToInt32(TS.TotalDays);
                //    break;
            }
            return (retVal * (_reverse ? -1 : 1));
        }

        
    }
}