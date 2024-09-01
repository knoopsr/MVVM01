using System.Collections.ObjectModel;

namespace MVVM01.Model
{
    public interface ICityRepository
    {
        clsCityM GetfirstCity();
        clsCityM GetCityByID(int myID);

        ObservableCollection<clsCityM> GetCities();

        bool UpdateCity(clsCityM myCity);
        bool InsertCity(clsCityM myCity);
        bool DeleteCity(clsCityM myCity);

    }
}
