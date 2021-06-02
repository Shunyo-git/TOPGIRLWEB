using System;
using System.Collections.Generic;


namespace TopGirl.BusinessLogicLayer
{

    /// <summary>
    /// EventComparer 的摘要描述
    /// </summary>
    public class StoreComparer : IComparer<Store>
    {
        private string _sortColumn;
        private bool _reverse;


        public StoreComparer(string sortEx)
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
        public bool Equals(Store x, Store y)
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

        public int Compare(Store x, Store y)
        {
            int retVal = 0;
            switch (_sortColumn.Trim())
            {

                case "ID":
                    retVal = (x.ID - y.ID);
                    break;
                case "AreaID":
                    retVal = (x.AreaID - y.AreaID);
                    break;
              
                case "StoreName":
                    retVal = String.Compare(x.StoreName, y.StoreName, StringComparison.InvariantCultureIgnoreCase);
                    break;
                case "AreaName":
                    retVal = String.Compare(x.AreaName, y.AreaName, StringComparison.InvariantCultureIgnoreCase);
                    break;
                case "Tel":
                    retVal = String.Compare(x.Tel, y.Tel, StringComparison.InvariantCultureIgnoreCase);
                    break;
                case "Address":
                    retVal = String.Compare(x.Address, y.Address, StringComparison.InvariantCultureIgnoreCase);
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