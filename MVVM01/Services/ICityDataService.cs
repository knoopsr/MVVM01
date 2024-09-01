using MVVM01.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM01.Services
{
    public interface ICityDataService
    {
        clsCityM GetfirstCity();
        clsCityM GetCityByID(int myID);

        ObservableCollection<clsCityM> GetCities();

        bool UpdateCity(clsCityM myCity);
        bool InsertCity(clsCityM myCity);
        bool DeleteCity(clsCityM myCity);
    }
}
