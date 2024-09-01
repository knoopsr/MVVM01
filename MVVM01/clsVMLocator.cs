using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
