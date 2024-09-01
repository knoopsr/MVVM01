using MVVM01.Model;
using MVVM01.Services;
using MVVM01.Utilities;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace MVVM01.ViewModel
{
    public class clsCityVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        clsCityDataService _CityDataService;

        private bool NewStatus = false;

        public ICommand cmdSave { get; set; }
        public ICommand cmdNew { get; set; }
        public ICommand cmdDelete { get; set; }
        public ICommand cmdCancel { get; set; }
        public ICommand cmdHelp { get; set; }


        bool isDelete = false;
        bool isCancel = true;
        bool isHelp = true;
        bool isNew = true;
        bool isSave = false;



        private bool _IsFocused;
        public bool IsFocused
        {
            get { return _IsFocused; }
            set
            {
                _IsFocused = value;
                RaisePropertyChanged("IsFocused");
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private clsCityM _SelectedCity;
        public clsCityM SelectedCity
        {
            get { return _SelectedCity; }
            set
            {
                if (value != null)
                {
                    if (_SelectedCity != null && _SelectedCity.IsDirty)
                    {
                        if (MessageBox.Show("Do you want to save >>"
                            + _SelectedCity.City + "<<", "Save", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            _SelectedCity.IsDirty = false;
                            ExecuteCMD_Save(null);
                            _SelectedCity.mySelectedIndex = 0;
                            isSave = false;
                        }
                        else
                        {
                            LoadData();
                        }
                    }
                    _SelectedCity = value;
                    isDelete = true;
                    isHelp = true;
                    isCancel = true;
                }
                RaisePropertyChanged("SelectedCity");
            }
        }


        private ObservableCollection<clsCityM> _Cities;
        public ObservableCollection<clsCityM> Cities
        {
            get { return _Cities; }
            set
            {
                _Cities = value;
                RaisePropertyChanged("Cities");
            }
        }


        public clsCityVM()
        {
            _CityDataService = new clsCityDataService();

            cmdSave = new clsCustomCommand(ExecuteCMD_Save, CanExecuteCMD_Save);
            cmdNew = new clsCustomCommand(ExecuteCMD_New, CanExecuteCMD_New);
            cmdDelete = new clsCustomCommand(ExecuteCMD_Delete, CanExecuteCMD_Delete);
            cmdCancel = new clsCustomCommand(ExecuteCMD_Cancel, CanExecuteCMD_Cancel);
            cmdHelp = new clsCustomCommand(ExecuteCMD_Help, CanExecuteCMD_Help);

            LoadData();
            SelectedCity = Cities.FirstOrDefault();
            SelectedCity.mySelectedIndex = 0;

        }

        private bool CanExecuteCMD_Help(object obj)
        {
            return true;
        }

        private void ExecuteCMD_Help(object obj)
        {
            Process.Start("https://www.google.com");
        }

        private bool CanExecuteCMD_Cancel(object obj)
        {
            if (NewStatus)
            {
                isCancel = true;
            }
            else
            {
                isCancel = false;
            }
            return isCancel;
        }

        private void ExecuteCMD_Cancel(object obj)
        {
            if (SelectedCity != null)
            {
                SelectedCity.mySelectedIndex = 0;
                SelectedCity.myVisibility = (int)Visibility.Visible;
            }

            isDelete = true;
            isHelp = true;
            isCancel = true;
            isNew = true;
            SelectedCity.IsDirty = false;
            NewStatus = false;
        }

        private bool CanExecuteCMD_New(object obj)
        {
            if (NewStatus)
            {
                isNew = false;
            }
            return isNew;
        }
        private void ExecuteCMD_New(object obj)
        {
            clsCityM CityToInsert = new clsCityM()
            {
                CityID = 0,
                City = string.Empty,
                PostalCode = string.Empty,
                ControlField = null
            };
            SelectedCity = CityToInsert;

            if (SelectedCity != null)
            {
                SelectedCity.myVisibility = (int)Visibility.Hidden;
            }

            isDelete = false;
            isHelp = true;
            isCancel = false;
            isSave = true;

            NewStatus = true;

        }


        private bool CanExecuteCMD_Delete(object obj)
        {
            if (SelectedCity != null)
            {
                isDelete = true;
                isHelp = true;
                isCancel = true;
                if (NewStatus)
                {
                    isDelete = false;
                    isHelp = true;
                    isCancel = true;
                }

            }
            else
            {
                isDelete = false;
                isHelp = true;
                isCancel = true;
            }
            return isDelete;
        }

        private void ExecuteCMD_Delete(object obj)
        {

            if (MessageBox.Show("Do you want to delete >>"
                + SelectedCity.City + "<<", "Delete", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                if (_CityDataService.DeleteCity(SelectedCity))
                {
                    LoadData();
                    SelectedCity.mySelectedIndex = 0;
                    NewStatus = false;
                }
                else
                {
                    MessageBox.Show(SelectedCity.ErrorBoodschap);
                }

            }
        }


        private bool CanExecuteCMD_Save(object obj)
        {
            if (SelectedCity != null && SelectedCity.Error == null && SelectedCity.IsDirty == true)
            {
                isDelete = true;
                isHelp = true;
                isCancel = true;
                isSave = true;

            }
            else
            {
                isDelete = false;
                isHelp = true;
                isCancel = true;
                isSave = false;
            }
            return isSave;
        }


        private void ExecuteCMD_Save(object obj)
        {
            if (SelectedCity != null)
            {
                if (NewStatus == true)
                {
                    if (_CityDataService.InsertCity(SelectedCity))
                    {
                        LoadData();
                        SelectedCity.IsDirty = false;
                        SelectedCity.mySelectedIndex = (int)Cities.Count - 1;
                        SelectedCity.myVisibility = (int)Visibility.Visible;
                        NewStatus = false;
                        isSave = false;
                        isNew = true;
                    }
                    else
                    {
                        MessageBox.Show(SelectedCity.ErrorBoodschap);
                    }
                }
                else
                {
                    if (_CityDataService.UpdateCity(SelectedCity))
                    {
                        LoadData();
                        SelectedCity.IsDirty = false;
                        SelectedCity.mySelectedIndex = 0;

                        NewStatus = false;
                        isSave = false;
                        isNew = true;
                    }
                    else
                    {
                        MessageBox.Show(SelectedCity.ErrorBoodschap);
                    }
                }
            }


        }


        private void LoadData()
        {
            Cities = _CityDataService.GetCities();
        }


    }
}
