using System;
using System.Collections.Generic;


namespace TopGirl.BusinessLogicLayer
{

    /// <summary>
    /// EventComparer 的摘要描述
    /// </summary>
    public class MiniSiteComparer : IComparer<MiniSite>
    {
        private string _sortColumn;
        private bool _reverse;


        public MiniSiteComparer(string sortEx)
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
        public bool Equals(MiniSite x, MiniSite y)
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

        public int Compare(MiniSite x, MiniSite y)
        {
            int retVal = 0;
            switch (_sortColumn.Trim())
            {

                case "ID":
                    retVal = (x.ID - y.ID);
                    break;
                case "SortID":
                    retVal = (x.SortID - y.SortID);
                    break;
                
                case "URL":
                    retVal = String.Compare(x.URL, y.URL, StringComparison.InvariantCultureIgnoreCase);
                    break;
               
              
                case "IsDisplay":
                    retVal =  Convert.ToInt32(x.IsDisplay) -  Convert.ToInt32(y.IsDisplay);
                    break;
 
            }
            return (retVal * (_reverse ? -1 : 1));
        }

        
    }
}