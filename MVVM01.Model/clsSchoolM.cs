using System.ComponentModel;

namespace MVVM01.Model
{
    public class clsSchoolM : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string myPropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(myPropertyName));
            }
        }

        private object _ControlField;
        public object ControlField
        {
            get { return _ControlField; }
            set { _ControlField = value; }
        }

        private bool _IsDirty = false;
        public bool IsDirty
        {
            get { return _IsDirty; }
            set
            {
                _IsDirty = value;
                RaisePropertyChanged("IsDirty");
            }
        }


        public override string ToString()
        {
            return SchoolName.ToUpper();
        }

        private int _mySelectedIndex;
        public int mySelectedIndex
        {
            get { return _mySelectedIndex; }
            set
            {
                _mySelectedIndex = value;
                RaisePropertyChanged("mySelectedIndex");
            }
        }

        private int _myVisibility;
        public int myVisibility
        {
            get { return _myVisibility; }
            set
            {
                _myVisibility = value;
                RaisePropertyChanged("myVisibility");
            }
        }

        public string ErrorBoodschap { get; set; }
        private List<string> ErrorList = new List<string>();

        public string Error
        {
            get
            {
                if (ErrorList.Count > 0)
                {
                    return "NOK";
                }
                else
                {
                    return null;
                }
            }
        }

        private int _SchoolID;
        public int SchoolID
        {
            get { return _SchoolID; }
            set
            {
                _SchoolID = value;
                RaisePropertyChanged("SchoolID");
            }
        }

        private string _SchoolName;
        public string SchoolName
        {
            get { return _SchoolName; }
            set
            {
                if (_SchoolName != value)
                {
                    if (_SchoolName != null)
                    {
                        IsDirty = true;
                    }
                    _SchoolName = value;
                    RaisePropertyChanged("SchoolName");

                }

            }
        }

        private string _SchoolAddress;
        public string SchoolAddress
        {
            get { return _SchoolAddress; }
            set
            {
                if (_SchoolAddress != value)
                {
                    if (_SchoolAddress != null)
                    {
                        IsDirty = true;
                    }
                    _SchoolAddress = value;
                    RaisePropertyChanged("SchoolAddress");

                }

            }
        }

        private int _CityID;
        public int CityID
        {
            get { return _CityID; }
            set
            {
                if (_CityID != value)
                {
                    if (_CityID != 0)
                    {
                        IsDirty = true;
                    }
                    _CityID = value;
                    RaisePropertyChanged("CityID");

                }

            }
        }

        private string _Telephone;
        public string Telephone
        {
            get { return _Telephone; }
            set
            {

                _Telephone = value;
                RaisePropertyChanged("Telephone");

            }
        }

        private string _URL;
        public string URL
        {
            get { return _URL; }
            set
            {
                _URL = value;
                RaisePropertyChanged("URL");
            }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                RaisePropertyChanged("Email");
            }
        }








        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case "SchoolName":
                        if (string.IsNullOrEmpty(_SchoolName))
                        {
                            error = "SchoolName is required";
                            if (ErrorList.Contains("SchoolName") == false)
                            {
                                ErrorList.Add("SchoolName");
                            }
                        }
                        else if (_SchoolName.Length > 50)
                        {
                            error = "SchoolName is too long";
                            if (ErrorList.Contains("SchoolName") == false)
                            {
                                ErrorList.Add("SchoolName");
                            }
                        }
                        else
                        {
                            ErrorList.Remove("SchoolName");

                        }
                        return error;
                    case "SchoolAddress":
                        if (string.IsNullOrEmpty(_SchoolAddress))
                        {
                            error = "SchoolAddress is required";
                            if (ErrorList.Contains("SchoolAddress") == false)
                            {
                                ErrorList.Add("SchoolAddress");
                            }
                        }
                        else if (_SchoolAddress.Length > 50)
                        {
                            error = "SchoolAddress is too long";
                            if (ErrorList.Contains("SchoolAddress") == false)
                            {
                                ErrorList.Add("SchoolAddress");
                            }
                        }
                        else
                        {
                            ErrorList.Remove("SchoolAddress");

                        }
                        return error;

                    default:
                        error = null;
                        return null;

                }
            }
        }
    }
}
