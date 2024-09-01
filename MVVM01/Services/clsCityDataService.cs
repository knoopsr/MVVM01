using MVVM01.DAL;
using MVVM01.Model;
using System.Collections.ObjectModel;

namespace MVVM01.Services
{
    public class clsCityDataService : ICityDataService
    {
        ICityRepository Repo = new clsCityRepository();

        public clsCityDataService()
        {
            this.Repo = Repo;
        }


        public bool DeleteCity(clsCityM myCity)
        {
            return Repo.DeleteCity(myCity);
        }

        public ObservableCollection<clsCityM> GetCities()
        {
            return Repo.GetCities();
        }

        public clsCityM GetCityByID(int myID)
        {
            return Repo.GetCityByID(myID);
        }

        public clsCityM GetfirstCity()
        {
            return Repo.GetfirstCity();
        }

        public bool InsertCity(clsCityM myCity)
        {
            return Repo.InsertCity(myCity);
        }

        public bool UpdateCity(clsCityM myCity)
        {
            return Repo.UpdateCity(myCity);
        }
    }
}
