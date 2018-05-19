using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MedicalAnalysis.Model;
using MedicalAnalysis.Model.Dao;

namespace MedicalAnalysis.View {

    public partial class ResultSimilar : Form {

        private SqlConnection connection;
        private List<Config> configs;

        public ResultSimilar(SqlConnection connection, List<Config> configs) {

            this.connection = connection;
            this.configs = configs;
            InitializeComponent();

        }

        private void ResultSimilar_Load(object sender, EventArgs e) {

            Patient pt = configs[0].Patient;
            List<AxeCond> conds = this.GetAxeConds(this.configs);
            AnalysisResult rs = new AnalysisResultDAO(connection).Select(conds, pt.Sexe, pt.Age).First();

            tbNom.Text = pt.Nom;
            tbMaladie.Text = rs.Name;

        }

        private List<AxeCond> GetAxeConds(List<Config> cfs) {

            List<MedicalAnalysis.Model.AxeCond> result = new List<MedicalAnalysis.Model.AxeCond>();

            foreach (MedicalAnalysis.Model.Config cf in cfs) {

                result.Add(cf.GetAxeCond());

            } return result;

        }

    }

}
