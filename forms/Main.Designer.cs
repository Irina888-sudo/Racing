namespace Racing.forms
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listBoxVoitures      = new System.Windows.Forms.ListBox();
            this.lblTitre             = new System.Windows.Forms.Label();
            this.lblSeparateur        = new System.Windows.Forms.Label();
            this.lblDetailTitre       = new System.Windows.Forms.Label();
            this.lblNom               = new System.Windows.Forms.Label();
            this.lblNomValue          = new System.Windows.Forms.Label();
            this.lblVitesse           = new System.Windows.Forms.Label();
            this.lblVitesseValue      = new System.Windows.Forms.Label();
            this.lblAcceleration      = new System.Windows.Forms.Label();
            this.lblAccelerationValue = new System.Windows.Forms.Label();
            this.btnStart             = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // ── Titre ──────────────────────────────────────────────────────────
            this.lblTitre.AutoSize  = true;
            this.lblTitre.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitre.Location  = new System.Drawing.Point(20, 18);
            this.lblTitre.Text      = "🚗 Gestion des Voitures";

            // ── ListBox ────────────────────────────────────────────────────────
            this.listBoxVoitures.Font     = new System.Drawing.Font("Segoe UI", 10F);
            this.listBoxVoitures.Location = new System.Drawing.Point(20, 60);
            this.listBoxVoitures.Size     = new System.Drawing.Size(200, 130);
            this.listBoxVoitures.SelectedIndexChanged += new System.EventHandler(this.listBoxVoitures_SelectedIndexChanged);

            // ── Séparateur visuel ──────────────────────────────────────────────
            this.lblSeparateur.AutoSize  = false;
            this.lblSeparateur.Size      = new System.Drawing.Size(2, 220);
            this.lblSeparateur.Location  = new System.Drawing.Point(240, 45);
            this.lblSeparateur.BackColor = System.Drawing.Color.LightGray;

            // ── Titre détail ───────────────────────────────────────────────────
            this.lblDetailTitre.AutoSize = true;
            this.lblDetailTitre.Font     = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetailTitre.Location = new System.Drawing.Point(260, 60);
            this.lblDetailTitre.Text     = "Détails";

            // ── Nom ────────────────────────────────────────────────────────────
            this.lblNom.AutoSize  = true;
            this.lblNom.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNom.Location  = new System.Drawing.Point(260, 95);
            this.lblNom.Text      = "Nom :";

            this.lblNomValue.AutoSize = true;
            this.lblNomValue.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNomValue.Location = new System.Drawing.Point(380, 95);
            this.lblNomValue.Text     = "—";

            // ── Vitesse Max ────────────────────────────────────────────────────
            this.lblVitesse.AutoSize  = true;
            this.lblVitesse.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVitesse.Location  = new System.Drawing.Point(260, 125);
            this.lblVitesse.Text      = "Vitesse max :";

            this.lblVitesseValue.AutoSize = true;
            this.lblVitesseValue.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVitesseValue.Location = new System.Drawing.Point(380, 125);
            this.lblVitesseValue.Text     = "—";

            // ── Accélération ───────────────────────────────────────────────────
            this.lblAcceleration.AutoSize  = true;
            this.lblAcceleration.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAcceleration.Location  = new System.Drawing.Point(260, 155);
            this.lblAcceleration.Text      = "Accélération :";

            this.lblAccelerationValue.AutoSize = true;
            this.lblAccelerationValue.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAccelerationValue.Location = new System.Drawing.Point(380, 155);
            this.lblAccelerationValue.Text     = "—";

            // ── Bouton Start ───────────────────────────────────────────────────
            this.btnStart.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStart.Location  = new System.Drawing.Point(260, 195);
            this.btnStart.Size      = new System.Drawing.Size(160, 35);
            this.btnStart.Text      = "▶ Start";
            this.btnStart.BackColor = System.Drawing.Color.ForestGreen;
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Enabled   = false; // désactivé tant qu'aucune voiture sélectionnée
            this.btnStart.Click    += new System.EventHandler(this.btnStart_Click);

            // ── MainForm ───────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(560, 250);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox         = false;
            this.Text                = "Gestion des Voitures";
            this.Load               += new System.EventHandler(this.Main_Load);

            this.Controls.Add(this.listBoxVoitures);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.lblSeparateur);
            this.Controls.Add(this.lblDetailTitre);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.lblNomValue);
            this.Controls.Add(this.lblVitesse);
            this.Controls.Add(this.lblVitesseValue);
            this.Controls.Add(this.lblAcceleration);
            this.Controls.Add(this.lblAccelerationValue);
            this.Controls.Add(this.btnStart);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // ── Déclarations ───────────────────────────────────────────────────────
        private System.Windows.Forms.ListBox listBoxVoitures;
        private System.Windows.Forms.Label   lblTitre;
        private System.Windows.Forms.Label   lblSeparateur;
        private System.Windows.Forms.Label   lblDetailTitre;
        private System.Windows.Forms.Label   lblNom;
        private System.Windows.Forms.Label   lblNomValue;
        private System.Windows.Forms.Label   lblVitesse;
        private System.Windows.Forms.Label   lblVitesseValue;
        private System.Windows.Forms.Label   lblAcceleration;
        private System.Windows.Forms.Label   lblAccelerationValue;
        private System.Windows.Forms.Button  btnStart;
    }
}