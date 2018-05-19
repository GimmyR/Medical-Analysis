using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;

namespace MedicalResult.Controllers {

    public class PatientController : ApiController {

        private SqlConnection connection = new SqlConnection("Server=localhost;Database=medical-analysis;User ID=sa;Password=itu;");

        public Models.Json.Res Get() {

            Models.Json.Res res = new Models.Json.Res() { error = true, message = null, data = null };

            try {

                res.data = this.GetResults();
                res.error = false;

            } catch(Exception ex) {

                res.message = ex.Message + " => " + ex.StackTrace;

            } return res;

        }

        private List<MedicalAnalysis.Model.Patient> GetAllPatients() {

            MedicalAnalysis.Model.Dao.PatientDAO ptdao = new MedicalAnalysis.Model.Dao.PatientDAO(connection);
            return ptdao.Select(null);

        }

        private List<MedicalAnalysis.Model.Config> GetAllConfigs(MedicalAnalysis.Model.Patient patient) {

            MedicalAnalysis.Model.Dao.ConfigDAO cfdao = new MedicalAnalysis.Model.Dao.ConfigDAO(connection);
            return cfdao.Select("WHERE patient = '" + patient.Id + "'");

        }

        private List<MedicalAnalysis.Model.AxeCond> GetAxeConds(List<MedicalAnalysis.Model.Config> cfs) {

            List<MedicalAnalysis.Model.AxeCond> result = new List<MedicalAnalysis.Model.AxeCond>();

            foreach(MedicalAnalysis.Model.Config cf in cfs) {

                result.Add(cf.GetAxeCond());

            } return result;

        }

        private List<Models.Json.AnaRes> GetResults() {

            List<Models.Json.AnaRes> result = new List<Models.Json.AnaRes>();

            List<MedicalAnalysis.Model.Patient> patients = this.GetAllPatients();
            foreach(MedicalAnalysis.Model.Patient pt in patients) {

                List<MedicalAnalysis.Model.AxeCond> cnds = this.GetAxeConds(this.GetAllConfigs(pt));
                MedicalAnalysis.Model.AnalysisResult rs = new MedicalAnalysis.Model.Dao.AnalysisResultDAO(connection).Select(cnds, pt.Sexe, pt.Age).First();
                String sex = ""; if (pt.Sexe == 1) sex = "Homme"; else if (pt.Sexe == 0) sex = "Femme"; else sex = "Inconnu";
                result.Add(new Models.Json.AnaRes() { nom = pt.Nom, dateDiag = pt.DateDiag.ToString("dd/MM/yyyy HH:mm:ss"), sexe = sex, age = pt.Age, maladie = rs.Name });

            } return result;

        }

    }

}
