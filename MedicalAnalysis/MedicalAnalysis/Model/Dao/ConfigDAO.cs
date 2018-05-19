using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MedicalAnalysis.Model.Dao {

    public class ConfigDAO {

        // ATTRIBUTES :

        private SqlConnection connection;

        // CONSTRUCTS :

        public ConfigDAO(SqlConnection connection) {

            this.connection = connection;

        }

        // METHODS :

        public int Insert(Config config) {

            int result = -1;

            if (connection.State == ConnectionState.Open)
                connection = new SqlConnection(connection.ConnectionString + "Password=itu");
            connection.Open();
            using (SqlCommand cmd = connection.CreateCommand()) {

                cmd.CommandText = "INSERT INTO Config(patient, axe, consultation, valeur) VALUES(@val1, @val2, @val3, @val4)";
                cmd.Parameters.AddWithValue("@val1", config.Patient.Id);
                if (config.Axe.GetType() != typeof(Consultation)) {
                    cmd.Parameters.AddWithValue("@val2", config.Axe.Id);
                    cmd.Parameters.AddWithValue("@val3", DBNull.Value);
                } else {
                    cmd.Parameters.AddWithValue("@val2", DBNull.Value);
                    cmd.Parameters.AddWithValue("@val3", config.Axe.Id);
                } cmd.Parameters.AddWithValue("@val4", config.Valeur);

                result = cmd.ExecuteNonQuery();

            } connection.Close();

            return result;

        }

        public int InsertAll(List<Config> configs) {

            int result = 0;

            foreach (Config cfg in configs) {

                result += this.Insert(cfg);

            } return result;

        }

        public List<Config> Select(string cond) {

            List<Config> result = null;

            if (connection.State == ConnectionState.Open)
                connection = new SqlConnection(connection.ConnectionString + "Password=itu");
            connection.Open();
            using (SqlCommand cmd = connection.CreateCommand()) {

                string condition = "";
                if (cond != null)
                    condition = " " + cond;
                cmd.CommandText = "SELECT * FROM Config" + condition;
                using (SqlDataReader reader = cmd.ExecuteReader()) {

                    result = new List<Config>();
                    while (reader.Read()) {

                        Patient patient = new PatientDAO(connection).Select("WHERE id='" + reader["patient"] + "'").First();
                        Axe axe = null;
                        if(reader["axe"].ToString() != "")
                            axe = new AxeDAO(connection).Select("WHERE id='" + reader["axe"] + "'").First();
                        else if (reader["consultation"].ToString() != "")
                            axe = new AxeDAO(connection).SelectConsultation("WHERE id='" + reader["consultation"] + "'").First();
                        float valeur = float.Parse(reader["valeur"].ToString());
                        
                        result.Add(new Config(patient, axe, valeur));

                    }

                }

            } connection.Close();

            return result;

        }

        private String PrepareCondition(List<Similaire> similaires) {

            String result = "";

            for (int i = 0, size = similaires.Count(); i < size; i++) {

                Similaire sim = similaires[i];
                if(sim.Axe.GetType() != typeof(Consultation))
                    result += "(axe = '" + sim.Axe.Id + "' AND valeur >= " + sim.Min.ToString(System.Globalization.CultureInfo.InvariantCulture) + " AND valeur <= " + sim.Max.ToString(System.Globalization.CultureInfo.InvariantCulture) + ")";
                else
                    result += "(consultation = '" + sim.Axe.Id + "' AND valeur >= " + sim.Min.ToString(System.Globalization.CultureInfo.InvariantCulture) + " AND valeur <= " + sim.Max.ToString(System.Globalization.CultureInfo.InvariantCulture) + ")";
                if (i != size - 1) result += " OR ";

            }if(result.Length > 0) result = "WHERE " + result; return result;

        }

        public List<Config> SelectSimilaire(List<Similaire> similaires) {

            List<Config> result = new List<Config>();

            if (connection.State == ConnectionState.Open)
                connection = new SqlConnection(connection.ConnectionString + "Password=itu");
            connection.Open();
            using (SqlCommand cmd = connection.CreateCommand()) {

                cmd.CommandText = "SELECT * FROM Config " + this.PrepareCondition(similaires);
                //throw new ModelException(cmd.CommandText);
                using (SqlDataReader reader = cmd.ExecuteReader()) {

                    result = new List<Config>();
                    while (reader.Read()) {

                        Patient patient = new PatientDAO(connection).Select("WHERE id='" + reader["patient"] + "'").First();
                        Axe axe = null;
                        if (reader["axe"].ToString() != "")
                            axe = new AxeDAO(connection).Select("WHERE id='" + reader["axe"] + "'").First();
                        else if (reader["consultation"].ToString() != "")
                            axe = new AxeDAO(connection).SelectConsultation("WHERE id='" + reader["consultation"] + "'").First();
                        float valeur = float.Parse(reader["valeur"].ToString());

                        result.Add(new Config(patient, axe, valeur));

                    } if (result.Count() != similaires.Count()) result = new List<Config>();

                }

            } connection.Close();

            return result;

        }

    }

}
