using System;
using System.Collections.Generic;


namespace TopGirl.BusinessLogicLayer
{

    /// <summary>
    /// EventComparer 的摘要描述
    /// </summary>
    public class CategoryComparer : IComparer<Category>
    {
        private string _sortColumn;
        private bool _reverse;


        public CategoryComparer(string sortEx)
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
        public bool Equals(Category x, Category y)
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

        public int Compare(Category x, Category y)
        {
            int retVal = 0;
            switch (_sortColumn.Trim())
            {

                case "ID":
                    retVal = (x.ID - y.ID);
                    break;

                case "Name":
                    retVal = String.Compare(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase);
                    break;
            
                case "IsDisplay":
                    retVal =  Convert.ToInt32(x.IsDisplay) -  Convert.ToInt32(y.IsDisplay);
                    break;
                case "IsHomePageDisplay":
                    retVal = Convert.ToInt32(x.IsHomePageDisplay) - Convert.ToInt32(y.IsHomePageDisplay);
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