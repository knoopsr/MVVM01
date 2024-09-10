using MVVM01.DAL;
using MVVM01.Model;
using System.Collections.ObjectModel;

namespace MVVM01.Services
{
    public class clsSchoolDataService : ISchoolDataService
    {

        ISchoolRepository Repo = new clsSchoolRepository();


        public clsSchoolDataService()
        {
            this.Repo = Repo;
        }

        public bool DeleteSchool(clsSchoolM mySchool)
        {
            return Repo.DeleteSchool(mySchool);
        }

        public clsSchoolM GetfirstSchool()
        {
            return Repo.GetfirstSchool();
        }

        public clsSchoolM GetSchoolByID(int myID)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<clsSchoolM> GetSchools()
        {
            return Repo.GetSchools();
        }

        public bool InsertSchool(clsSchoolM mySchool)
        {
            return Repo.InsertSchool(mySchool);
        }

        public bool UpdateSchool(clsSchoolM mySchool)
        {
            return Repo.UpdateSchool(mySchool);
        }
    }
}
