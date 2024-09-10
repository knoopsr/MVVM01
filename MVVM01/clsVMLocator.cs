using MVVM01.ViewModel;

namespace MVVM01
{
    public class clsVMLocator
    {
        #region My ViewModels
        private static clsCityVM _CityVM;
        private static clsSchoolVM _SchoolVM;
        private static clsTaskVM _TaskVM;
        private static clsClassRoomVM _ClassRoomVM;
        private static clsPersonVM _PersonVM;
        private static clsTaskPerClassRoomVM _TaskPerClassRoomVM;

        #endregion




        public static clsSchoolVM SchoolViewModel
        {
            get
            {
                _SchoolVM = new clsSchoolVM();
                return _SchoolVM;
            }
        }


        public static clsCityVM CityViewModel
        {
            get
            {
                _CityVM = new clsCityVM();
                return _CityVM;
            }
        }
    }
}
