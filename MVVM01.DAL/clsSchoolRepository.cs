using MVVM01.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM01.DAL
{
    public class clsSchoolRepository : ISchoolRepository
    {

        private static ObservableCollection<clsSchoolM> _SchoolM;

        public object DAL { get; set; }

        public clsSchoolRepository() { }


        private void LoadSchools()
        {
            _SchoolM = new ObservableCollection<clsSchoolM>();
            DataTable DT = new DataTable();
            DT = clsDAC.ExecuteDataTable(Properties.Resources.S_School);
            foreach (DataRow DR in DT.Rows)
            {
                var x = new clsSchoolM()
                {
                    SchoolID = (int)DR[0],
                    SchoolName = DR[1].ToString(),
                    SchoolAddress = DR[2].ToString(),
                    CityID = (int)DR[3],
                    Telephone = DR[4].ToString(),
                    URL = DR[5].ToString(),
                    Email = DR[6].ToString(),
                    ControlField = DR[7]
                };
                _SchoolM.Add(x);
            }
        }



        public string ErrorBoodschap { get; set; }

        private bool ErrorBoodschappen(int myNR, clsSchoolM myError)
        {
            if (myNR == 1)
            {
                return true;
            }
            else if (myNR == 2)
            {
                myError.ErrorBoodschap = "Concurrency issue";
                return false;
            }
            else if (myNR == 3)
            {
                myError.ErrorBoodschap = "Contstraint issue";
                return false;
            }
            else
            {
                myError.ErrorBoodschap = "Unknown error";
                return false;
            }
        }



        public bool DeleteSchool(clsSchoolM mySchool)
        {
            int nr = 0;
            DataTable TDTemp = null;

            TDTemp = clsDAC.ExecuteDataTable(Properties.Resources.D__School, ref nr,
                clsDAC.Parameter("SchoolID", mySchool.SchoolID),
                clsDAC.Parameter("ControlField", mySchool.ControlField),
                clsDAC.Parameter("@ReturnValue", 0));
            return ErrorBoodschappen(nr, mySchool);

        }

        public clsSchoolM GetfirstSchool()
        {
            if (_SchoolM == null)
            {
                LoadSchools();
            }
            return _SchoolM.FirstOrDefault();
        }

        public clsSchoolM GetSchoolByID(int myID)
        {
            if (_SchoolM == null)
            {
                LoadSchools();
            }
            return _SchoolM.Where(x => x.SchoolID == myID).FirstOrDefault();
        }

        public ObservableCollection<clsSchoolM> GetSchools()
        {
          LoadSchools();
            return _SchoolM;

        }

        public bool InsertSchool(clsSchoolM mySchool)
        {
            int nr = 0;
            DataTable TDTemp = null;

            TDTemp = clsDAC.ExecuteDataTable(Properties.Resources.I_School, ref nr,
                clsDAC.Parameter("SchoolName", mySchool.SchoolName),
                clsDAC.Parameter("SchoolAddress", mySchool.SchoolAddress),
                clsDAC.Parameter("CityID", mySchool.CityID),
                clsDAC.Parameter("Telephone", mySchool.Telephone),
                clsDAC.Parameter("URL", mySchool.URL),
                clsDAC.Parameter("Email", mySchool.Email),
                clsDAC.Parameter("@ReturnValue", 0));
            return ErrorBoodschappen(nr, mySchool);
        }

        public bool UpdateSchool(clsSchoolM mySchool)
        {
            int nr = 0;
            DataTable TDTemp = null;

            TDTemp = clsDAC.ExecuteDataTable(Properties.Resources.U_School, ref nr,
                clsDAC.Parameter("SchoolID", mySchool.SchoolID),
                clsDAC.Parameter("SchoolName", mySchool.SchoolName),
                clsDAC.Parameter("SchoolAddress", mySchool.SchoolAddress),
                clsDAC.Parameter("CityID", mySchool.CityID),
                clsDAC.Parameter("Telephone", mySchool.Telephone),
                clsDAC.Parameter("URL", mySchool.URL),
                clsDAC.Parameter("Email", mySchool.Email),      
                clsDAC.Parameter("@ControlField", mySchool.ControlField),
                clsDAC.Parameter("@ReturnValue", 0));
            return ErrorBoodschappen(nr, mySchool);
        }
    }
}
