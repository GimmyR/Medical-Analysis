using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MedicalAnalysis.Model.Dao {

    public class AxeDAO {

        // ATTRIBUTES :

        private SqlConnection connection;

        // CONSTRUCTS :

        public AxeDAO(SqlConnection connection) {

            this.connection = connection;

        }

        // PROPERTIES :



        // METHODS :

        public List<Axe> Select(string cond) {

            List<Axe> result = null;

            if (connection.State == ConnectionState.Open)
                connection = new SqlConnection(connection.ConnectionString + "Password=itu");
            connection.Open();
            using (SqlCommand cmd = connection.CreateCommand()) {

                string condition = "";
                if (cond != null)
                    condition = " " + cond;
                cmd.CommandText = "SELECT * FROM Axe" + condition;
                using (SqlDataReader reader = cmd.ExecuteReader()) {

                    result = new List<Axe>();
                    while (reader.Read()) {

                        float lowerX = float.Parse(reader["lowerX"].ToString());
                        float upperX = float.Parse(reader["upperX"].ToString());
                        float lowerNormal = float.Parse(reader["lowerNormal"].ToString());
                        float upperNormal = float.Parse(reader["upperNormal"].ToString());
                        float marginSimilar = float.Parse(reader["marginSimilar"].ToString());
                        Axe axe = new Axe(reader["id"].ToString(), reader["name"].ToString(), lowerX, upperX, lowerNormal, upperNormal, marginSimilar, reader["unit"].ToString());
                        result.Add(axe);

                    }

                }

            } connection.Close();

            return result;

        }

        public List<Consultation> SelectConsultation(string cond) {

            List<Consultation> result = null;

            if (connection.State == ConnectionState.Open)
                connection = new SqlConnection(connection.ConnectionString + "Password=itu");
            connection.Open();
            using (SqlCommand cmd = connection.CreateCommand()) {

                string condition = "";
                if (cond != null)
                    condition = " " + cond;
                cmd.CommandText = "SELECT * FROM Consultation" + condition;
                using (SqlDataReader reader = cmd.ExecuteReader()) {

                    result = new List<Consultation>();
                    while (reader.Read()) {

                        float lowerX = float.Parse(reader["lowerX"].ToString());
                        float upperX = float.Parse(reader["upperX"].ToString());
                        float lowerNormal = float.Parse(reader["lowerNormal"].ToString());
                        float upperNormal = float.Parse(reader["upperNormal"].ToString());
                        float marginSimilar = float.Parse(reader["marginSimilar"].ToString());
                        Consultation axe = new Consultation(reader["id"].ToString(), reader["name"].ToString(), lowerX, upperX, lowerNormal, upperNormal, marginSimilar, reader["unit"].ToString());
                        result.Add(axe);

                    }

                }

            } connection.Close();

            return result;

        }

        private void PrepareCommand(SqlCommand cmd, Consultation cons) {

            cons.Id = new SequenceDAO(connection).Next("consultation");

            cmd.CommandText = "INSERT INTO Consultation VALUES(@val1, @val2, @val3, @val4, @val5, @val6, @val7, @val8)";
            cmd.Parameters.AddWithValue("@val1", cons.Id);
            cmd.Parameters.AddWithValue("@val2", cons.Name);
            cmd.Parameters.AddWithValue("@val3", cons.LowerX);
            cmd.Parameters.AddWithValue("@val4", cons.UpperX);
            cmd.Parameters.AddWithValue("@val5", cons.LowerNormal);
            cmd.Parameters.AddWithValue("@val6", cons.UpperNormal);
            cmd.Parameters.AddWithValue("@val7", cons.MarginSimilar);
            cmd.Parameters.AddWithValue("@val8", cons.Unit);

        }

        public int InsertConsultation(Consultation cons) {

            int result = -1;

            if (connection.State == ConnectionState.Open)
                connection = new SqlConnection(connection.ConnectionString + "Password=itu");
            connection.Open();
            using (SqlCommand cmd = connection.CreateCommand()) {

                this.PrepareCommand(cmd, cons);
                result = cmd.ExecuteNonQuery();

            } connection.Close();

            return result;

        }

        // STATIC METHODS :



    }

}
