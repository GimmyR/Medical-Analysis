using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MedicalAnalysis.Model.Dao {

    public class AnalysisResultDAO {
    
        // ATTRIBUTES :

        private SqlConnection connection;

        // CONSTRUCTS :

        public AnalysisResultDAO(SqlConnection connection) {

            this.connection = connection;

        }

        public List<AnalysisResult> Select(List<AxeCond> axeConds, int gender, int age) {

            List<AnalysisResult> result = new List<AnalysisResult>();;

            if (connection.State == ConnectionState.Open)
                connection = new SqlConnection(connection.ConnectionString + "Password=itu");
            connection.Open();
            using (SqlCommand cmd = connection.CreateCommand()) {

                String query = this.GetQuery(axeConds, gender, age);
                if (query != null) {
                    Console.WriteLine("The query : " + query);
                    cmd.CommandText = query;
                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        while (reader.Read()) {

                            float percentage = float.Parse(reader["percentage"].ToString());
                            AnalysisResult ar = new AnalysisResult(reader["name"].ToString(), percentage);
                            result.Add(ar);

                        }

                    }
                } else
                    Console.WriteLine("Command Text is null ...");

            } connection.Close();

            return this.Regule(result);

        }

        private List<AnalysisResult> Regule(List<AnalysisResult> aResults) {

            for (int i = 0, size = aResults.Count(); i < size; i++) {

                for (int j = 0; j < size; j++) {

                    if (i != j && aResults[i].Percentage == aResults[j].Percentage) {

                        aResults[j].Percentage -= (j * 10);

                    }

                }

            } return aResults;

        }

        private String GetQuery(List<AxeCond> axeConds, int gender, int age) {

            String result = null;

            String axeCond = this.BuildAxeCond(axeConds), clientCond = this.BuildClientCond(gender, age);
            if (axeCond.Length > 0) {

                String query1 = "SELECT COUNT(*) FROM DiseaseDetail WHERE disease=dd.disease";
                String query2 = "SELECT dd.disease , convert(decimal(4, 2), (convert(decimal, COUNT(*)) / convert(decimal, (" + query1 + ")))) * 100 as percentage " +
                                "FROM DiseaseDetail dd WHERE " + axeCond + " GROUP BY dd.disease";
                result = "SELECT TOP 3 d.name, (ddResult.percentage - (d.probaOrder - 1) * 5) as percentage FROM Disease d, (" + query2 + ") as ddResult WHERE d.id=ddResult.disease AND " + clientCond + " ORDER BY ddResult.percentage DESC , d.probaOrder ASC";
            
            } return result;

        }

        private String BuildAxeCond(List<AxeCond> axeConds) {

            String result = "";

            for (int i = 0; i < axeConds.Count; i++) {

                result += axeConds[i].ToString();
                if (i != axeConds.Count - 1)
                    result += " OR ";

            } return result;

        }

        private String BuildClientCond(int gender, int age) {

            String result = "d.gender = " + gender;
            if (gender != -1) {
                result = "(" + result;
                result += " OR d.gender = -1)";
            }

            if (age >= 0)
                result += " AND d.lowerAge <= " + age + " AND d.upperAge >= " + age;

            return result;

        }
    
    }

}
