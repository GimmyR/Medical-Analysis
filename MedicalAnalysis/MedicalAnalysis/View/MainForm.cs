using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalAnalysis.Model;
using MedicalAnalysis.Model.Dao;

namespace MedicalAnalysis.View {

    public partial class MainForm : Form {

        // GRAPHICAL ATTRIBUTES :
        
        private Rectangle rectLimit;

        // DATA ATTRIBUTES :

        private SqlConnection connection;
        private AxeDAO axeDAO;
        private AnalysisResultDAO anDAO;
        private List<Axe> axes;
        private bool showSimilaire;
        private List<Axe> axesSimilsaires;
        private bool showCmp;
        private List<Axe> axesCmp;
        private Axe selectedAxe;

        private List<AnalysisResult> results;

        // CONSTRUCTS :

        public MainForm() {

            this.connection = new SqlConnection("Server=localhost;Database=medical-analysis;User ID=sa;Password=itu;");
            this.axeDAO = new AxeDAO(this.connection);
            this.anDAO = new AnalysisResultDAO(this.connection);
            this.results = new List<AnalysisResult>();
            InitializeComponent();
            this.InitAxes();
            this.showSimilaire = false;
            this.showCmp = false;

        }

        // GETTERS :

        public SqlConnection Connection {
            get { return this.connection; }
        }

        // METHODS :

        public void AddAxe(Axe axe) {

            axes.Add(axe);
            this.Refresh();

        }

        private void MainForm_Load(object sender, EventArgs e) {

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Paint += new PaintEventHandler(this.PaintRectLimit);
            this.Paint += new PaintEventHandler(this.PaintAxes);
            this.Paint += new PaintEventHandler(this.PaintPolygon);
            this.rectangleShape1.MouseDown += new MouseEventHandler(this.DragAndDrop_MouseDown);
            this.rectangleShape1.MouseMove += new MouseEventHandler(this.DragAndDrop_MouseMove);
            this.rectangleShape1.MouseUp += new MouseEventHandler(this.DragAndDrop_MouseUp);
            this.tbAge.KeyPress += new KeyPressEventHandler(this.TbAge_KeyPress);

            this.maladie1.Text = ""; this.pourcentage1.Text = "";
            this.maladie2.Text = ""; this.pourcentage2.Text = "";
            this.maladie3.Text = ""; this.pourcentage3.Text = "";
            //tabPatients.AllowUserToAddRows = false;
            tabPatients.CellClick += new DataGridViewCellEventHandler(CellClick);
            tabPatients.Rows.Clear();
            this.FillTabPatients();

        }

        private void DrawCmp(List<Config> cmps) {

            if (cmps.Count() > 0) {

                axesCmp = new List<Axe>();
                foreach (Config cfg in cmps) {

                    cfg.Axe.CurrValue = cfg.Valeur;
                    axesCmp.Add(cfg.Axe);

                } showCmp = true; this.Refresh();

            }

        }

        private void CellClick(object sender, DataGridViewCellEventArgs e) {

            if (e.RowIndex != -1 && e.RowIndex + 1 != tabPatients.Rows.Count) {

                String nom = tabPatients.SelectedCells[0].Value.ToString();
                Patient pt = new PatientDAO(connection).Select("WHERE nom = '" + nom + "'").First();
                List<Config> configs = new ConfigDAO(connection).Select("WHERE patient = '" + pt.Id + "'");
                this.DrawCmp(configs);

            }

        }

        private void AddRowTabPatients(Patient pt) {

            tabPatients.Rows.Add(pt.Nom);

        }

        private void FillTabPatients() {

            List<Patient> patients = new PatientDAO(connection).Select(null);
            foreach (Patient pt in patients) {

                this.AddRowTabPatients(pt);

            }

        }

        private void PaintRectLimit(object sender, PaintEventArgs e) {

            rectLimit = new Rectangle(rectangleShape1.Location, rectangleShape1.Size);
            Brush brush = new SolidBrush(ColorTranslator.FromHtml("#ffffff"));
            e.Graphics.FillRectangle(brush, rectLimit);

        }

        private void PaintAxes(object sender, PaintEventArgs e) {

            this.CalculateAngles();
            this.PaintSegments(e);

        }

        private void PaintSegments(PaintEventArgs e) {

            Pen pen = new Pen(ColorTranslator.FromHtml("#c6c6c6"));

            foreach (Axe axe in axes) {

                axe.Line = UtilsModel.FindSegment(axe, rectLimit);
                e.Graphics.DrawLine(pen, axe.Line.P1, axe.Line.P2);

            }

        }

        private void CalculateAngles() {

            float oneLap = 360;
            float part = oneLap / axes.Count;
            //String verbose = "";
            for (int i = 0; i < axes.Count; i++) {

                float tmp = i * part;
                axes.ElementAt(i).Angle = tmp;

            }

        }

        private void InitAxes() {

            try {

                axes = axeDAO.Select(null);

            } catch (ModelException mex) {

                MessageBox.Show(mex.Message);

            } catch (Exception ex) {

                Console.WriteLine(ex.Message);
                MessageBox.Show("Une erreur inconnu s'est produit !");

            }


        }

        private Axe FindAxe(Axe find) {

            Axe result = null;

            foreach (Axe axe in axes) {

                if (axe.Id == find.Id) {
                    result = axe;
                    break;
                }

            } return result;

        }

        private void PaintSim(PaintEventArgs e) {

            List<PointF> peaks = new List<PointF>();

            Pen pen = new Pen(ColorTranslator.FromHtml("#6eb87c"));
            foreach (Axe axe in axesSimilsaires) {

                Axe vrai = this.FindAxe(axe);
                float lineLength = UtilsModel.LineLength(vrai.Line.P1, vrai.Line.P2);
                float length = UtilsModel.RuleOfThree(axe.UpperX, lineLength, axe.CurrValue);
                PointF tmp = UtilsModel.CalculateCurrPoint(length, vrai.Angle, rectLimit.Width, rectLimit.Location.X);
                peaks.Add(tmp);

            } e.Graphics.DrawPolygon(pen, peaks.ToArray());

        }

        private void PaintCmp(PaintEventArgs e) {

            List<PointF> peaks = new List<PointF>();

            Brush pen = new SolidBrush(ColorTranslator.FromHtml("#d2d6d0"));
            foreach (Axe axe in axesCmp) {

                Axe vrai = this.FindAxe(axe);
                float lineLength = UtilsModel.LineLength(vrai.Line.P1, vrai.Line.P2);
                float length = UtilsModel.RuleOfThree(axe.UpperX, lineLength, axe.CurrValue);
                PointF tmp = UtilsModel.CalculateCurrPoint(length, vrai.Angle, rectLimit.Width, rectLimit.Location.X);
                peaks.Add(tmp);

            } e.Graphics.FillPolygon(pen, peaks.ToArray());

        }

        private void PaintCurr(PaintEventArgs e) {

            List<PointF> peaks = new List<PointF>();

            Pen pen = new Pen(ColorTranslator.FromHtml("#cf7b1f"));
            foreach (Axe axe in axes) {

                float length = UtilsModel.RuleOfThree(axe.UpperX, UtilsModel.LineLength(axe.Line.P1, axe.Line.P2), axe.CurrValue);
                PointF tmp = UtilsModel.CalculateCurrPoint(length, axe.Angle, rectLimit.Width, rectLimit.Location.X);
                peaks.Add(tmp);

            } e.Graphics.DrawPolygon(pen, peaks.ToArray());

        }

        private void PaintPolygon(object sender, PaintEventArgs e) {

            try {

                if (showSimilaire && axesSimilsaires != null && axesSimilsaires.Count() > 0) this.PaintSim(e);
                if (showCmp && axesCmp != null && axesCmp.Count() > 0) this.PaintCmp(e);
                this.PaintCurr(e);

            } catch (Exception ex) {

                MessageBox.Show("Veuillez a bien configurer tout ( ajouter consultations , etc ... )");

            }

        }

        private void DragAndDrop_MouseDown(object sender, MouseEventArgs e) {

            PointF mousePos = UtilsModel.InvertFromGraph(new PointF(e.X, e.Y), 0, rectLimit.Location.X);
            foreach (Axe axe in axes) {

                float length = UtilsModel.RuleOfThree(axe.UpperX, UtilsModel.LineLength(axe.Line.P1, axe.Line.P2), axe.CurrValue);
                PointF tmp = UtilsModel.CalculateCurrPoint(length, axe.Angle, rectLimit.Width, rectLimit.Location.X);
                float distance = UtilsModel.LineLength(mousePos, tmp);
                if (distance <= 10) {

                    this.selectedAxe = axe;
                    this.textAxe.Text = this.selectedAxe.Name;
                    this.valeurAxe.Text = this.selectedAxe.CurrValue + "";
                    this.uniteAxe.Text = this.selectedAxe.Unit;
                    showSimilaire = false;
                    axesSimilsaires = null;
                    break;

                }

            }

        }

        private void DragAndDrop_MouseMove(object sender, MouseEventArgs e) {

            if (this.selectedAxe != null) {

                float nextValue = this.GetNextValue(e);
                this.selectedAxe.CurrValue = nextValue;
                this.valeurAxe.Text = this.selectedAxe.CurrValue + "";
                List<AxeCond> conditions = this.GetConditions();
                results = this.anDAO.Select(conditions, this.GetGender(), this.GetAge());

                this.Refresh();
                this.DisplayResults();

            }

        }

        private void DisplayResults() {

            if (results.Count == 1) {
                this.maladie1.Text = results.ElementAt(0).Name; this.pourcentage1.Text = results.ElementAt(0).Percentage + " %";
                this.maladie2.Text = ""; this.pourcentage2.Text = "";
                this.maladie3.Text = ""; this.pourcentage3.Text = "";
            } else if (results.Count == 2) {
                this.maladie1.Text = results.ElementAt(0).Name; this.pourcentage1.Text = results.ElementAt(0).Percentage + " %";
                this.maladie2.Text = results.ElementAt(1).Name; this.pourcentage2.Text = results.ElementAt(1).Percentage + " %";
                this.maladie3.Text = ""; this.pourcentage3.Text = "";
            } else if (results.Count == 3) {
                this.maladie1.Text = results.ElementAt(0).Name; this.pourcentage1.Text = results.ElementAt(0).Percentage + " %";
                this.maladie2.Text = results.ElementAt(1).Name; this.pourcentage2.Text = results.ElementAt(1).Percentage + " %";
                this.maladie3.Text = results.ElementAt(2).Name; this.pourcentage3.Text = results.ElementAt(2).Percentage + " %";
            } else {
                this.maladie1.Text = "Probleme de gouvernement"; this.pourcentage1.Text = "100 %";
                this.maladie2.Text = ""; this.pourcentage2.Text = "";
                this.maladie3.Text = ""; this.pourcentage3.Text = "";
            }

        }

        private int GetGender() {

            if (this.rbHomme.Checked)
                return 1;
            else if (this.rbFemme.Checked)
                return 0;
            else
                return -1;

        }

        private int GetAge() {

            if (this.tbAge.Text != "")
                return int.Parse(this.tbAge.Text);
            else
                return -1;

        }

        private String GetNom() {

            if (this.tbNom.Text != "")
                return this.tbNom.Text;
            else
                return "Inconnu";

        }

        private List<AxeCond> GetConditions() {

            List<AxeCond> result = new List<AxeCond>();

            foreach (Axe axe in axes) {

                int code = axe.GetCode();
                if (code == 1 || code == 2) {
                    if(axe .GetType() == typeof(Consultation))
                        result.Add(new AxeCond(axe.Id, code, true));
                    else
                        result.Add(new AxeCond(axe.Id, code, false));
                }

            } return result;

        }

        private List<Config> GetConfigs(Patient patient) {

            List<Config> result = new List<Config>();

            foreach (Axe axe in axes) {

                result.Add(new Config(patient, axe, axe.CurrValue));

            } return result;

        }

        private float GetNextValue(MouseEventArgs e) {

            PointF pointProject = this.FindPointProject(e);
            return this.GetValue(pointProject);

        }

        private float GetValue(PointF pointProject) {

            PointF origin = this.selectedAxe.Line.P1;
            PointF xtm = this.selectedAxe.Line.P2;
            float a = UtilsModel.LineLength(origin, xtm), b = this.selectedAxe.UpperX, c = UtilsModel.LineLength(origin, pointProject);

            return UtilsModel.RuleOfThree(a, b, c);

        }

        private PointF FindPointProject(MouseEventArgs e) {

            PointF result = new PointF();

            if (!this.selectedAxe.Line.IsVertical()) {

                LineProject projection = this.GetLineProject(e);
                Line lineForProject = this.GetLineForProject();

                float x = (-1 * (lineForProject.B + projection.C)) / (projection.A + projection.B * lineForProject.A);
                float y = lineForProject.A * x + lineForProject.B;

                result = UtilsModel.InvertFromGraph(new PointF(x, y), rectLimit.Width, rectLimit.Location.X);

            } else {

                PointF mousePos = UtilsModel.InvertFromGraph(new PointF(e.X, e.Y), 0, rectLimit.Location.X);
                result.X = this.selectedAxe.Line.P1.X;
                result.Y = mousePos.Y;

            } return result;

        }

        private Line GetLineForProject() {

            PointF p1 = UtilsModel.ConvertToGraph(selectedAxe.Line.P1, rectLimit.Width, rectLimit.Location.X);
            PointF p2 = UtilsModel.ConvertToGraph(selectedAxe.Line.P2, rectLimit.Width, rectLimit.Location.X);

            return Line.GetLine(p1, p2);

        }

        private LineProject GetLineProject(MouseEventArgs e) {

            PointF mousePos = UtilsModel.InvertFromGraph(new PointF(e.X, e.Y), 0, rectLimit.Location.X);
            PointF graphMouse = UtilsModel.ConvertToGraph(mousePos, rectLimit.Width, rectLimit.Location.X);

            float length = UtilsModel.LineLength(selectedAxe.Line.P1, selectedAxe.Line.P2);
            PointF xtm = UtilsModel.CalculateCurrPoint(length, selectedAxe.Angle, rectLimit.Width, rectLimit.Location.X);
            PointF graphXtm = UtilsModel.ConvertToGraph(xtm, rectLimit.Width, rectLimit.Location.X);

            float a = graphXtm.X, b = graphXtm.Y, c = -1 * ((graphXtm.X * graphMouse.X) + (graphXtm.Y * graphMouse.Y));
            return new LineProject(a, b, c);

        }

        private void DragAndDrop_MouseUp(object sender, MouseEventArgs e) {

            if(this.selectedAxe != null) this.selectedAxe = null;

        }

        private void label10_Click(object sender, EventArgs e) {

        }

        private void label11_Click(object sender, EventArgs e) {

        }

        private void label12_Click(object sender, EventArgs e) {

        }

        private void TbAge_KeyPress(object sender, KeyPressEventArgs e) {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {

                e.Handled = true;

            }

        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void btnSave_Click(object sender, EventArgs e) {

            try {

                Patient patient = new Patient("", DateTime.Now, this.GetNom(), this.GetGender(), this.GetAge());
                PatientDAO ptdao = new PatientDAO(connection);
                ptdao.Insert(patient);
                List<Config> cfs = this.GetConfigs(patient);
                ConfigDAO cfdao = new ConfigDAO(connection);
                cfdao.InsertAll(cfs);
                this.AddRowTabPatients(patient);

            } catch (Exception ex) {

                MessageBox.Show(ex.Message);

            }

        }

        private void btnConsul_Click(object sender, EventArgs e) {

            AjoutConsultation ac = new AjoutConsultation(this);
            ac.Show();

        }

        private List<Similaire> GetIntervals() {

            List<Similaire> result = new List<Similaire>();

            foreach (Axe a in axes) {

                result.Add(new Similaire(a, a.CurrValue - a.MarginSimilar, a.CurrValue + a.MarginSimilar));

            } return result;

        }

        private void btnSimilaire_Click(object sender, EventArgs e) {

            try {

                List<Config> configs = new ConfigDAO(connection).SelectSimilaire(this.GetIntervals());
                if (configs.Count() > 0) {

                    axesSimilsaires = new List<Axe>();
                    foreach (Config cfg in configs) {

                        cfg.Axe.CurrValue = cfg.Valeur;
                        axesSimilsaires.Add(cfg.Axe);

                    } showSimilaire = true; this.Refresh();

                    ResultSimilar rs = new ResultSimilar(connection, configs);
                    rs.Show();

                } else throw new Exception("Il n'existe aucune graphe qui ressemble a celle-ci !");

            } catch (Exception ex) {

                MessageBox.Show(ex.Message);

            }

        }

        private void tabPatients_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            
        }

        private void hideGraph_Click(object sender, EventArgs e) {

            if (showCmp) {

                showCmp = false;
                axesCmp = new List<Axe>();

                this.Refresh();

            }

        }

    }

}
