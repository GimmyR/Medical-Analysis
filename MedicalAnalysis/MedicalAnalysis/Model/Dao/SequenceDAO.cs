using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MedicalAnalysis.Model.Dao {

    public class SequenceDAO {

        // ATTRIBUTES :

        private SqlConnection connection;

        // CONSTRUCTS :

        public SequenceDAO(SqlConnection connection) {

            this.connection = connection;

        }

        // METHODS :

        public int Update(Sequence seq) {

            int result = -1;

            if (connection.State == ConnectionState.Open)
                connection = new SqlConnection(connection.ConnectionString + "Password=itu");
            connection.Open();
            using (SqlCommand cmd = connection.CreateCommand()) {

                cmd.CommandText = "UPDATE Sequence SET valeur = @v1 WHERE nom = @v2";
                cmd.Parameters.AddWithValue("@v1", seq.valeur);
                cmd.Parameters.AddWithValue("@v2", seq.nom);

                result = cmd.ExecuteNonQuery();

            } connection.Close();

            return result;

        }

        public String Next(String nom) {

            String result = null;

            if (connection.State == ConnectionState.Open)
                connection = new SqlConnection(connection.ConnectionString + "Password=itu");
            connection.Open();
            using (SqlCommand cmd = connection.CreateCommand()) {

                cmd.CommandText = "SELECT * FROM Sequence WHERE nom = @v";
                cmd.Parameters.AddWithValue("@v", nom);
                using (SqlDataReader reader = cmd.ExecuteReader()) {

                    if (reader.Read()) {

                        Sequence seq = new Sequence(reader["nom"].ToString(), reader["prefixe"].ToString(), int.Parse(reader["longueur"].ToString()), int.Parse(reader["valeur"].ToString()));
                        result = seq.GetId();
                        seq.Next();
                        this.Update(seq);

                    }

                }

            } connection.Close();

            return result;

        }

    }

}
