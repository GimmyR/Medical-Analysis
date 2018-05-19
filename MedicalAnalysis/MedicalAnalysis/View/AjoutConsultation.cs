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

    public partial class AjoutConsultation : Form {

        private MainForm main;
        private SqlConnection connection;

        public AjoutConsultation(MainForm main) {

            this.main = main;
            this.connection = main.Connection;
            InitializeComponent();

        }

        private void AjoutConsultation_Load(object sender, EventArgs e) {

            List<Consultation> consultations = new AxeDAO(connection).SelectConsultation(null);
            foreach (Consultation cons in consultations) {

                cbConsultation.Items.Add(cons.Name);

            } if (consultations.Count() > 0) cbConsultation.SelectedIndex = 0;

        }

        private void btnValider_Click(object sender, EventArgs e) {

            try {

                String nomCons = cbConsultation.SelectedItem.ToString();
                Axe cons = new AxeDAO(connection).SelectConsultation("WHERE name = '" + nomCons + "'").First();
                main.AddAxe(cons);

                this.Close();

            } catch (FormatException ex) {

                MessageBox.Show("Veuillez saisir le bon format de donnees !");

            } catch (Exception ex) {

                MessageBox.Show(ex.Message);

            }

        }

    }

}
