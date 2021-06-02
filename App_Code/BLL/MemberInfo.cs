using System;
using System.Data;
using System.Configuration;


namespace TopGirl.BusinessLogicLayer
{

    /// <summary>
    /// MemberInfo 的摘要描述
    /// </summary>
    /// <summary>
    /// Business entity used to model addresses
    /// </summary>
    [Serializable]
    public class MemberInfo
    {
        public enum GenderType
        {
            unknown = 0,
            male = 1,
            female = 2,
        }
        // Internal member variables
        private string _chineseName;
        private GenderType _gender;
        private DateTime _birthday;
        private string _telphone;
        private string _mobilePhone;
        private string _address;
        private string _career;
        private string _marital;
        private bool _isSubscription;
        private bool _isMemberCard;
        /// <summary>
        /// Default constructor
        /// </summary>
        public MemberInfo() { }

        /// <summary>
        /// Constructor with specified initial values
        /// </summary>

        public MemberInfo(string chineseName, GenderType gender, DateTime birthday, string telphone, string mobilePhone, string address, string career, string marital, bool IsSubscription, bool IsMemberCard)
        {
           
            this.ChineseName = chineseName;
            this.Gender = gender;
            this.Birthday = birthday;
            this.Telphone = telphone;
            this.MobilePhone = mobilePhone;
            this.Address = address;
            this.Career = career;
            this.Marital = marital;
            this.IsSubscription = IsSubscription;
            this.IsMemberCard = IsMemberCard;
        }

        // Properties
       

        public string ChineseName
        {
            get { return _chineseName; }
            set { _chineseName = value; }
        }
  
        public GenderType Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        public string Telphone
        {
            get { return _telphone; }
            set { _telphone = value; }
        }

        public string MobilePhone
        {
            get { return _mobilePhone; }
            set { _mobilePhone = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string Career
        {
            get { return _career; }
            set { _career = value; }
        }

        public string Marital
        {
            get { return _marital; }
            set { _marital = value; }
        }

         public bool IsSubscription
        {
            get { return _isSubscription; }
            set { _isSubscription = value; }
        }

        public bool IsMemberCard
        {
            get { return _isMemberCard; }
            set { _isMemberCard = value; }
        }
       
        
    }
}
