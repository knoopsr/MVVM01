using MVVM01.Model;
using System.Collections.ObjectModel;
using System.Data;

namespace MVVM01.DAL
{
    public class clsCityRepository : ICityRepository
    {
        private static ObservableCollection<clsCityM> _CityM;

        public object DAL { get; set; }

        public clsCityRepository() { }

        private void LoadCity()
        {
            _CityM = new ObservableCollection<clsCityM>();
            DataTable DT = new DataTable();
            DT = clsDAC.ExecuteDataTable(Properties.Resources.S_City);
            foreach (DataRow DR in DT.Rows)
            {
                var x = new clsCityM()
                {
                    CityID = (int)DR[0],
                    City = DR[1].ToString(),
                    PostalCode = DR[2].ToString(),
                    ControlField = DR[3]
                };
                _CityM.Add(x);
            }

        }


        public bool DeleteCity(clsCityM myCity)
        {
            int nr = 0;
            DataTable TDTemp = null;

            TDTemp = clsDAC.ExecuteDataTable(Properties.Resources.D_City, ref nr,
                clsDAC.Parameter("CityID", myCity.CityID),
                clsDAC.Parameter("ControlField", myCity.ControlField),
                clsDAC.Parameter("@ReturnValue", 0));
            return ErrorBoodschappen(nr, myCity);
        }

        public ObservableCollection<clsCityM> GetCities()
        {
            LoadCity();
            return _CityM;
        }

        public clsCityM GetCityByID(int myID)
        {
            if (_CityM == null)
            {
                LoadCity();
            }
            return _CityM.Where(x => x.CityID == myID).FirstOrDefault();
        }

        public clsCityM GetfirstCity()
        {
            if (_CityM == null)
            {
                LoadCity();
            }
            return _CityM.FirstOrDefault();
        }

        public bool InsertCity(clsCityM myCity)
        {
            int nr = 0;
            DataTable TDTemp = null;

            TDTemp = clsDAC.ExecuteDataTable(Properties.Resources.I_City, ref nr,
                clsDAC.Parameter("City", myCity.City),
                clsDAC.Parameter("PostalCode", myCity.PostalCode),
                clsDAC.Parameter("@ReturnValue", 0));
            return ErrorBoodschappen(nr, myCity);
        }



        public bool UpdateCity(clsCityM myCity)
        {
            int nr = 0;
            DataTable TDTemp = null;

            TDTemp = clsDAC.ExecuteDataTable(Properties.Resources.U_City, ref nr,
                clsDAC.Parameter("CityID", myCity.CityID),
                clsDAC.Parameter("City", myCity.City),
                clsDAC.Parameter("PostalCode", myCity.PostalCode),
                clsDAC.Parameter("ControlField", myCity.ControlField),
                clsDAC.Parameter("@ReturnValue", 0));
            return ErrorBoodschappen(nr, myCity);
        }

        public string ErrorBoodschap { get; set; }

        private bool ErrorBoodschappen(int myNR, clsCityM myCity)
        {
            if (myNR == 1)
            {
                return true;
            }
            else if (myNR == 2)
            {
                myCity.ErrorBoodschap = "Concurrency issue";
                return false;
            }
            else if (myNR == 3)
            {
                myCity.ErrorBoodschap = "Contstraint issue";
                return false;
            }
            else
            {
                myCity.ErrorBoodschap = "Unknown error";
                return false;
            }
        }
    }



}

