namespace MedicalAnalysis.View {
    partial class AjoutConsultation {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnValider = new System.Windows.Forms.Button();
            this.cbConsultation = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(246, 32);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(134, 23);
            this.btnValider.TabIndex = 6;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // cbConsultation
            // 
            this.cbConsultation.FormattingEnabled = true;
            this.cbConsultation.Location = new System.Drawing.Point(37, 34);
            this.cbConsultation.Name = "cbConsultation";
            this.cbConsultation.Size = new System.Drawing.Size(178, 21);
            this.cbConsultation.TabIndex = 7;
            // 
            // AjoutConsultation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 86);
            this.Controls.Add(this.cbConsultation);
            this.Controls.Add(this.btnValider);
            this.Name = "AjoutConsultation";
            this.Text = "Ajouter Consultation";
            this.Load += new System.EventHandler(this.AjoutConsultation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.ComboBox cbConsultation;
    }
}