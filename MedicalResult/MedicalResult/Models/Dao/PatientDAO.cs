using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MedicalAnalysis.Model.Dao {

    public class PatientDAO {

        // ATTRIBUTES :

        private SqlConnection connection;

        // CONSTRUCTS :

        public PatientDAO(SqlConnection connection) {

            this.connection = connection;

        }

        // PROPERTIES :



        // METHODS :

        private void PrepareCommand(SqlCommand cmd, Patient patient) {

            patient.Id = new SequenceDAO(connection).Next("patient");

            cmd.CommandText = "INSERT INTO Patient VALUES(@val1, @val2, @val3, @val4, @val5)";
            cmd.Parameters.AddWithValue("@val1", patient.Id);
            cmd.Parameters.AddWithValue("@val2", patient.DateDiag);
            cmd.Parameters.AddWithValue("@val3", patient.Nom);
            cmd.Parameters.AddWithValue("@val4", patient.Sexe);
            cmd.Parameters.AddWithValue("@val5", patient.Age);

        }

        public int Insert(Patient patient) {

            int result = -1;

            if (connection.State == ConnectionState.Open)
                connection = new SqlConnection(connection.ConnectionString + "Password=itu");
            connection.Open();
            using (SqlCommand cmd = connection.CreateCommand()) {

                this.PrepareCommand(cmd, patient);
                result = cmd.ExecuteNonQuery();

            } connection.Close();

            return result;

        }

        public List<Patient> Select(string cond) {

            List<Patient> result = null;

            if (connection.State == ConnectionState.Open)
                connection = new SqlConnection(connection.ConnectionString + "Password=itu");
            connection.Open();
            using (SqlCommand cmd = connection.CreateCommand()) {

                string condition = "";
                if (cond != null)
                    condition = " " + cond;
                cmd.CommandText = "SELECT * FROM Patient" + condition;
                using (SqlDataReader reader = cmd.ExecuteReader()) {

                    result = new List<Patient>();
                    while (reader.Read()) {

                        String id = reader["id"].ToString();
                        DateTime dateDiag = Convert.ToDateTime(reader["dateDiag"].ToString());
                        String nom = reader["nom"].ToString();
                        int sexe = int.Parse(reader["sexe"].ToString());
                        int age = int.Parse(reader["age"].ToString());
                        
                        result.Add(new Patient(id, dateDiag, nom, sexe, age));

                    }

                }

            } connection.Close();

            return result;

        }

    }

}
