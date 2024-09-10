using MVVM01.Services;
using MVVM01.Model;
using MVVM01.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MVVM01.ViewModel
{
    public class clsSchoolVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        clsSchoolDataService _SchoolDataService;


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

        private clsSchoolM _SelectedSchool;
        public clsSchoolM SelectedSchool
        {
            get { return _SelectedSchool; }
            set
            {
                if (value != null)
                {
                    if (_SelectedSchool != null && _SelectedSchool.IsDirty)
                    {
                        if (MessageBox.Show("Do you want to save >>"
                            + _SelectedSchool.SchoolName + "<<", "Save", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            _SelectedSchool.IsDirty = false;
                            ExecuteCMD_Save(null);
                            _SelectedSchool.mySelectedIndex = 0;
                            isSave = false;
                        }
                        else
                        {
                            LoadData();
                        }
                    }
                    _SelectedSchool = value;
                    isDelete = true;
                    isHelp = true;
                    isCancel = true;
                }
                RaisePropertyChanged("SelectedSchool");
            }
        }

        private ObservableCollection<clsSchoolM> _Schools;
        public ObservableCollection<clsSchoolM> Schools
        {
            get { return _Schools; }
            set
            {
                _Schools = value;
                RaisePropertyChanged("Schools");
            }
        }

        public clsSchoolVM()
        {
            _SchoolDataService = new clsSchoolDataService();

            cmdSave = new clsCustomCommand(ExecuteCMD_Save, CanExecuteCMD_Save);
            cmdNew = new clsCustomCommand(ExecuteCMD_New, CanExecuteCMD_New);
            cmdDelete = new clsCustomCommand(ExecuteCMD_Delete, CanExecuteCMD_Delete);
            cmdCancel = new clsCustomCommand(ExecuteCMD_Cancel, CanExecuteCMD_Cancel);
            cmdHelp = new clsCustomCommand(ExecuteCMD_Help, CanExecuteCMD_Help);

            LoadData();
            SelectedSchool = Schools.FirstOrDefault();
            SelectedSchool.mySelectedIndex = 0;

        }

        private bool CanExecuteCMD_Help(object obj)
        {
            return isHelp;
        }

        private void ExecuteCMD_Help(object obj)
        {
            Process.Start(psi);
        }

        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "http://www.google.com",
            UseShellExecute = true
        };


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
            if (SelectedSchool != null)
            {
                SelectedSchool.mySelectedIndex = 0;
                SelectedSchool.myVisibility = (int)Visibility.Visible;
            }

            isDelete = true;
            isHelp = true;
            isCancel = true;
            isNew = true;
            SelectedSchool.IsDirty = false;
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
            clsSchoolM SchoolToInsert = new clsSchoolM()
            {
                SchoolID = 0,
                SchoolName = string.Empty,
                SchoolAddress = string.Empty,
                CityID = 0,
                Telephone = string.Empty,
                URL = string.Empty,
                Email = string.Empty,
                ControlField = null
            };
            SelectedSchool = SchoolToInsert;

            if (SelectedSchool != null)
            {
                SelectedSchool.myVisibility = (int)Visibility.Hidden;
            }

            isDelete = false;
            isHelp = true;
            isCancel = false;
            isSave = true;

            NewStatus = true;

        }


        private bool CanExecuteCMD_Delete(object obj)
        {
            if (SelectedSchool != null)
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
                + SelectedSchool.SchoolName + "<<", "Delete", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                if (_SchoolDataService.DeleteSchool(SelectedSchool))
                {
                    LoadData();
                    SelectedSchool.mySelectedIndex = 0;
                    NewStatus = false;
                }
                else
                {
                    MessageBox.Show(SelectedSchool.ErrorBoodschap);
                }

            }
        }

        private bool CanExecuteCMD_Save(object obj)
        {
            if (SelectedSchool != null && SelectedSchool.Error == null && SelectedSchool.IsDirty == true)
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
            if (SelectedSchool != null)
            {
                if (NewStatus == true)
                {
                    if (_SchoolDataService.InsertSchool(SelectedSchool))
                    {
                        LoadData();
                        SelectedSchool.IsDirty = false;
                        SelectedSchool.mySelectedIndex = (int)Schools.Count - 1;
                        SelectedSchool.myVisibility = (int)Visibility.Visible;
                        NewStatus = false;
                        isSave = false;
                        isNew = true;
                    }
                    else
                    {
                        MessageBox.Show(SelectedSchool.ErrorBoodschap);
                    }
                }
                else
                {
                    if (_SchoolDataService.UpdateSchool(SelectedSchool))
                    {
                        LoadData();
                        SelectedSchool.IsDirty = false;
                        SelectedSchool.mySelectedIndex = 0;

                        NewStatus = false;
                        isSave = false;
                        isNew = true;
                    }
                    else
                    {
                        MessageBox.Show(SelectedSchool.ErrorBoodschap);
                    }
                }
            }


        }


        private void LoadData()
        {
            Schools = _SchoolDataService.GetSchools();
        }



    }
}
