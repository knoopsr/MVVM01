using MVVM01.Utilities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MVVM01.View;

namespace MVVM01.ViewModel
{
    public class clsShoolManagerVM
    {

        public ICommand CMD_OpenSchool { get; set; }
        public ICommand CMD_OpenCity { get; set; }
        public ICommand CMD_OpenTask { get; set; }
        public ICommand CMD_OpenClassRoom { get; set; }
        public ICommand CMD_OpenPerson { get; set; }
        public ICommand CMD_OpenTasksPerClassRoom { get; set; }
        public ICommand cmdClose { get; set; }


        public clsShoolManagerVM()
        {
            LoadCommands();
        }


        private void LoadCommands()
        {

            CMD_OpenSchool = new clsCustomCommand(ExecuteCMD_OpenSchool, CanExecuteCMD_OpenSchool);
            CMD_OpenCity = new clsCustomCommand(ExecuteCMD_OpenCity, CanExecuteCMD_OpenCity);
            CMD_OpenTask = new clsCustomCommand(ExecuteCMD_OpenTask, CanExecuteCMD_OpenTask);
            CMD_OpenClassRoom = new clsCustomCommand(ExecuteCMD_OpenClassRoom, CanExecuteCMD_OpenClassRoom);
            CMD_OpenPerson = new clsCustomCommand(ExecuteCMD_OpenPerson, CanExecuteCMD_OpenPerson);
            CMD_OpenTasksPerClassRoom = new clsCustomCommand(ExecuteCMD_OpenTasksPerClassRooom, CanExecuteCMD_OpenTasksPerClassRooom);

            cmdClose = new clsCustomCommand(Execute_cmdClose, CanExecute_cmdClose);



        }


        private bool CanExecuteCMD_OpenTasksPerClassRooom(object obj)
        {
            return true;
        }

        private void ExecuteCMD_OpenTasksPerClassRooom(object obj)
        {
            FindGrid(obj);
            ucTasksPerClassRoom _ucItems = new ucTasksPerClassRoom();
            OpenUserControl(_ucItems);
        }

        private bool CanExecuteCMD_OpenPerson(object obj)
        {
            return true;
        }

        private void ExecuteCMD_OpenPerson(object obj)
        {
            FindGrid(obj);
            ucPerson _ucItems = new ucPerson();
            OpenUserControl(_ucItems);
        }

        private bool CanExecuteCMD_OpenTask(object obj)
        {
            return true;
        }

        private void ExecuteCMD_OpenTask(object obj)
        {
            FindGrid(obj);
            ucTask _ucItems = new ucTask();
            OpenUserControl(_ucItems);
        }

        private bool CanExecuteCMD_OpenCity(object obj)
        {
            return true;
        }

        private void ExecuteCMD_OpenCity(object obj)
        {
            FindGrid(obj);
            ucCity _ucItems = new ucCity();
            OpenUserControl(_ucItems);
        }

        private bool CanExecuteCMD_OpenSchool(object obj)
        {
            return true;
        }

        private void ExecuteCMD_OpenSchool(object obj)
        {
            FindGrid(obj);
            ucSchool _ucItems = new ucSchool();
            OpenUserControl(_ucItems);
        }

        private bool CanExecuteCMD_OpenClassRoom(object obj)
        {
            return true;
        }

        private void ExecuteCMD_OpenClassRoom(object obj)
        {
            FindGrid(obj);
            ucClassRoom _ucItems = new ucClassRoom();
            OpenUserControl(_ucItems);
        }

        private bool CanExecute_cmdClose(object obj)
        {
            return true;
        }

        private void Execute_cmdClose(object obj)
        {
            if (MessageBox.Show("This window will be closes.", "Closing", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CloseControl();
            }
        }

        private void CloseControl()
        {
            if (MyMainGrid.Children.Count > 0)
            {
                MyMainGrid.Children.RemoveAt(0);
            }
        }



        private static Grid _myMainGrid;
        public static Grid MyMainGrid
        {
            get { return _myMainGrid; }
            set { _myMainGrid = value; }
        }


        private void OpenUserControl(UserControl myUs)
        {
            if (MyMainGrid.Children.Count > 0)
            {
                MyMainGrid.Children.RemoveAt(0);
            }
            Grid.SetRow(myUs, 0);
            Grid.SetColumn(myUs, 1);
            MyMainGrid.Children.Add(myUs);
        }

        private void FindGrid(object obj)
        {
            var myGrid = obj as Grid;
            if (myGrid != null)
            {
                MyMainGrid = myGrid;
            }

        }
    }
}
