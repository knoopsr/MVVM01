using System.ComponentModel;

namespace MVVM01.Model
{
    public class clsCityM : INotifyPropertyChanged, IDataErrorInfo
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
            return City.ToUpper();
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


        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case "City":
                        if (string.IsNullOrWhiteSpace(_City))
                        {
                            error = "City is required";
                            if (ErrorList.Contains("City") == false)
                            {
                                ErrorList.Add("City");
                            }
                        }
                        else if (_City.Length > 50)
                        {
                            error = "City is too long";
                            if (ErrorList.Contains("City") == false)
                            {
                                ErrorList.Add("City");
                            }
                        }
                        else
                        {
                            if (ErrorList.Contains("City"))
                            {
                                ErrorList.Remove("City");
                            }
                        }
                        return error;
                    case "PostalCode":
                        if (string.IsNullOrWhiteSpace(_PostalCode))
                        {
                            error = "PostalCode is required";
                            if (ErrorList.Contains("PostalCode") == false)
                            {
                                ErrorList.Add("PostalCode");
                            }
                        }
                        else if (_PostalCode.Length > 50)
                        {
                            error = "PostalCode is too long";
                            if (ErrorList.Contains("PostalCode") == false)
                            {
                                ErrorList.Add("PostalCode");
                            }
                        }
                        else
                        {
                            if (ErrorList.Contains("PostalCode"))
                            {
                                ErrorList.Remove("PostalCode");
                            }
                        }
                        return error;
                    default:
                        error = null;
                        return error;

                }

            }
        }




        private int _CityID;
        public int CityID
        {
            get { return _CityID; }
            set
            {
                _CityID = value;
                RaisePropertyChanged("CityID");
            }
        }


        private string _City;

        public string City
        {
            get { return _City; }
            set
            {
                if (_City != value)
                {
                    if (_City != null)
                    {
                        IsDirty = true;
                    }
                    _City = value;
                    RaisePropertyChanged("City");
                }
            }
        }


        private string _PostalCode;
        public string PostalCode
        {
            get { return _PostalCode; }
            set
            {
                if (_PostalCode != value)
                {
                    if (_PostalCode != null)
                    {
                        IsDirty = true;
                    }
                    _PostalCode = value;
                    RaisePropertyChanged("PostalCode");
                }
            }
        }






    }
}
