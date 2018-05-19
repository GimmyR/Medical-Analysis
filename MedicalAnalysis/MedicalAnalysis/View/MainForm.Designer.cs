namespace MedicalAnalysis.View
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.label1 = new System.Windows.Forms.Label();
            this.textAxe = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.uniteAxe = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbAge = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rbHomme = new System.Windows.Forms.RadioButton();
            this.rbFemme = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.maladie1 = new System.Windows.Forms.Label();
            this.pourcentage1 = new System.Windows.Forms.Label();
            this.pourcentage2 = new System.Windows.Forms.Label();
            this.maladie2 = new System.Windows.Forms.Label();
            this.pourcentage3 = new System.Windows.Forms.Label();
            this.maladie3 = new System.Windows.Forms.Label();
            this.valeurAxe = new System.Windows.Forms.Label();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnConsul = new System.Windows.Forms.Button();
            this.btnSimilaire = new System.Windows.Forms.Button();
            this.tabPatients = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.hideGraph = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tabPatients)).BeginInit();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(1461, 765);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BorderColor = System.Drawing.Color.White;
            this.rectangleShape1.Location = new System.Drawing.Point(80, 80);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(600, 600);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(756, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Axe selectionne :";
            // 
            // textAxe
            // 
            this.textAxe.AutoSize = true;
            this.textAxe.Location = new System.Drawing.Point(850, 178);
            this.textAxe.Name = "textAxe";
            this.textAxe.Size = new System.Drawing.Size(38, 13);
            this.textAxe.TabIndex = 2;
            this.textAxe.Text = "Aucun";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(759, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Valeur :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(759, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Unite :";
            // 
            // uniteAxe
            // 
            this.uniteAxe.AutoSize = true;
            this.uniteAxe.Location = new System.Drawing.Point(850, 234);
            this.uniteAxe.Name = "uniteAxe";
            this.uniteAxe.Size = new System.Drawing.Size(44, 13);
            this.uniteAxe.TabIndex = 6;
            this.uniteAxe.Text = "Aucune";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(759, 261);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Age (annee) :";
            // 
            // tbAge
            // 
            this.tbAge.Location = new System.Drawing.Point(853, 258);
            this.tbAge.Name = "tbAge";
            this.tbAge.Size = new System.Drawing.Size(100, 20);
            this.tbAge.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(758, 295);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Sexe :";
            // 
            // rbHomme
            // 
            this.rbHomme.AutoSize = true;
            this.rbHomme.Location = new System.Drawing.Point(843, 293);
            this.rbHomme.Name = "rbHomme";
            this.rbHomme.Size = new System.Drawing.Size(61, 17);
            this.rbHomme.TabIndex = 11;
            this.rbHomme.TabStop = true;
            this.rbHomme.Text = "Homme";
            this.rbHomme.UseVisualStyleBackColor = true;
            // 
            // rbFemme
            // 
            this.rbFemme.AutoSize = true;
            this.rbFemme.Location = new System.Drawing.Point(910, 293);
            this.rbFemme.Name = "rbFemme";
            this.rbFemme.Size = new System.Drawing.Size(59, 17);
            this.rbFemme.TabIndex = 12;
            this.rbFemme.TabStop = true;
            this.rbFemme.Text = "Femme";
            this.rbFemme.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(829, 512);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Resultat(s)";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // maladie1
            // 
            this.maladie1.AutoSize = true;
            this.maladie1.Location = new System.Drawing.Point(769, 564);
            this.maladie1.Name = "maladie1";
            this.maladie1.Size = new System.Drawing.Size(35, 13);
            this.maladie1.TabIndex = 14;
            this.maladie1.Text = "Rien :";
            this.maladie1.Click += new System.EventHandler(this.label11_Click);
            // 
            // pourcentage1
            // 
            this.pourcentage1.AutoSize = true;
            this.pourcentage1.Location = new System.Drawing.Point(929, 564);
            this.pourcentage1.Name = "pourcentage1";
            this.pourcentage1.Size = new System.Drawing.Size(24, 13);
            this.pourcentage1.TabIndex = 15;
            this.pourcentage1.Text = "0 %";
            this.pourcentage1.Click += new System.EventHandler(this.label12_Click);
            // 
            // pourcentage2
            // 
            this.pourcentage2.AutoSize = true;
            this.pourcentage2.Location = new System.Drawing.Point(929, 596);
            this.pourcentage2.Name = "pourcentage2";
            this.pourcentage2.Size = new System.Drawing.Size(24, 13);
            this.pourcentage2.TabIndex = 17;
            this.pourcentage2.Text = "0 %";
            // 
            // maladie2
            // 
            this.maladie2.AutoSize = true;
            this.maladie2.Location = new System.Drawing.Point(769, 596);
            this.maladie2.Name = "maladie2";
            this.maladie2.Size = new System.Drawing.Size(35, 13);
            this.maladie2.TabIndex = 16;
            this.maladie2.Text = "Rien :";
            // 
            // pourcentage3
            // 
            this.pourcentage3.AutoSize = true;
            this.pourcentage3.Location = new System.Drawing.Point(929, 625);
            this.pourcentage3.Name = "pourcentage3";
            this.pourcentage3.Size = new System.Drawing.Size(24, 13);
            this.pourcentage3.TabIndex = 19;
            this.pourcentage3.Text = "0 %";
            // 
            // maladie3
            // 
            this.maladie3.AutoSize = true;
            this.maladie3.Location = new System.Drawing.Point(769, 625);
            this.maladie3.Name = "maladie3";
            this.maladie3.Size = new System.Drawing.Size(35, 13);
            this.maladie3.TabIndex = 18;
            this.maladie3.Text = "Rien :";
            // 
            // valeurAxe
            // 
            this.valeurAxe.AutoSize = true;
            this.valeurAxe.Location = new System.Drawing.Point(850, 206);
            this.valeurAxe.Name = "valeurAxe";
            this.valeurAxe.Size = new System.Drawing.Size(13, 13);
            this.valeurAxe.TabIndex = 4;
            this.valeurAxe.Text = "0";
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(853, 141);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(100, 20);
            this.tbNom.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(761, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Nom :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(775, 381);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Enregistrer";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnConsul
            // 
            this.btnConsul.Location = new System.Drawing.Point(795, 421);
            this.btnConsul.Name = "btnConsul";
            this.btnConsul.Size = new System.Drawing.Size(128, 23);
            this.btnConsul.TabIndex = 23;
            this.btnConsul.Text = "Ajouter consultation";
            this.btnConsul.UseVisualStyleBackColor = true;
            this.btnConsul.Click += new System.EventHandler(this.btnConsul_Click);
            // 
            // btnSimilaire
            // 
            this.btnSimilaire.Location = new System.Drawing.Point(865, 381);
            this.btnSimilaire.Name = "btnSimilaire";
            this.btnSimilaire.Size = new System.Drawing.Size(75, 23);
            this.btnSimilaire.TabIndex = 24;
            this.btnSimilaire.Text = "Similaire ?";
            this.btnSimilaire.UseVisualStyleBackColor = true;
            this.btnSimilaire.Click += new System.EventHandler(this.btnSimilaire_Click);
            // 
            // tabPatients
            // 
            this.tabPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabPatients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name});
            this.tabPatients.Location = new System.Drawing.Point(1116, 194);
            this.tabPatients.Name = "tabPatients";
            this.tabPatients.Size = new System.Drawing.Size(229, 392);
            this.tabPatients.TabIndex = 25;
            this.tabPatients.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabPatients_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1179, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Les patients anterieurs :";
            // 
            // hideGraph
            // 
            this.hideGraph.Location = new System.Drawing.Point(1174, 608);
            this.hideGraph.Name = "hideGraph";
            this.hideGraph.Size = new System.Drawing.Size(124, 23);
            this.hideGraph.TabIndex = 27;
            this.hideGraph.Text = "Cacher";
            this.hideGraph.UseVisualStyleBackColor = true;
            this.hideGraph.Click += new System.EventHandler(this.hideGraph_Click);
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "Nom";
            this.name.Name = "name";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1461, 765);
            this.Controls.Add(this.hideGraph);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tabPatients);
            this.Controls.Add(this.btnSimilaire);
            this.Controls.Add(this.btnConsul);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNom);
            this.Controls.Add(this.pourcentage3);
            this.Controls.Add(this.maladie3);
            this.Controls.Add(this.pourcentage2);
            this.Controls.Add(this.maladie2);
            this.Controls.Add(this.pourcentage1);
            this.Controls.Add(this.maladie1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.rbFemme);
            this.Controls.Add(this.rbHomme);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbAge);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.uniteAxe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.valeurAxe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textAxe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "MainForm";
            this.Text = "Medical Analysis";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabPatients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label textAxe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label uniteAxe;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbAge;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbHomme;
        private System.Windows.Forms.RadioButton rbFemme;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label maladie1;
        private System.Windows.Forms.Label pourcentage1;
        private System.Windows.Forms.Label pourcentage2;
        private System.Windows.Forms.Label maladie2;
        private System.Windows.Forms.Label pourcentage3;
        private System.Windows.Forms.Label maladie3;
        private System.Windows.Forms.Label valeurAxe;
        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnConsul;
        private System.Windows.Forms.Button btnSimilaire;
        private System.Windows.Forms.DataGridView tabPatients;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button hideGraph;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
    }
}

