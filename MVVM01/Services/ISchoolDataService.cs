using MVVM01.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM01.Services
{
    public interface ISchoolDataService
    {

        clsSchoolM GetfirstSchool();
        clsSchoolM GetSchoolByID(int myID);

        ObservableCollection<clsSchoolM> GetSchools();

        bool UpdateSchool(clsSchoolM mySchool);
        bool InsertSchool(clsSchoolM mySchool);
        bool DeleteSchool(clsSchoolM mySchool);
    }
}
