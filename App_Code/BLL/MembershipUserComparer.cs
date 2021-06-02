 
using System;
using System.Collections.Generic;
using System.Web.Security;

namespace TopGirl.BusinessLogicLayer
{

    /// <summary>
    /// EventComparer 的摘要描述
    /// </summary>
    public class MembershipUserComparer : IComparer<MembershipUser>
    {
        private string _sortColumn;
        private bool _reverse;


        public MembershipUserComparer(string sortEx)
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
        public bool Equals(MembershipUser x, MembershipUser y)
        {
            if (x.UserName == y.UserName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Compare(MembershipUser x, MembershipUser y)
        {
            int retVal = 0;
            System.TimeSpan TS;
            switch (_sortColumn.Trim())
            {

        
                case "UserName":
                    retVal = String.Compare(x.UserName, y.UserName, StringComparison.InvariantCultureIgnoreCase);
                    break;
                case "Email":
                    retVal = String.Compare(x.Email, y.Email, StringComparison.InvariantCultureIgnoreCase);
                    break;
                case "LastLoginDate":
                     TS = new System.TimeSpan(x.LastLoginDate.Ticks - y.LastLoginDate.Ticks);
                    retVal = Convert.ToInt32(TS.TotalDays);
                    break;
                case "CreationDate":
                      TS = new System.TimeSpan(x.CreationDate.Ticks - y.CreationDate.Ticks);
                    retVal = Convert.ToInt32(TS.TotalDays);
                    break;
            }
            return (retVal * (_reverse ? -1 : 1));
        }

        
    }
}