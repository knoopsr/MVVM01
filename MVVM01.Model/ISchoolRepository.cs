using System.Collections.ObjectModel;

namespace MVVM01.Model
{
    public interface ISchoolRepository
    {
        clsSchoolM GetfirstSchool();
        clsSchoolM GetSchoolByID(int myID);

        ObservableCollection<clsSchoolM> GetSchools();

        bool UpdateSchool(clsSchoolM mySchool);
        bool InsertSchool(clsSchoolM mySchool);
        bool DeleteSchool(clsSchoolM mySchool);
    }
}
