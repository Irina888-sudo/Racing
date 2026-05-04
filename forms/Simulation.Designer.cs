namespace Racing.forms
{
    partial class SimulationForm
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
            this.pnlRoute       = new System.Windows.Forms.Panel();
            this.pnlSpeedo      = new System.Windows.Forms.Panel();
            this.lblChrono      = new System.Windows.Forms.Label();
            this.lblChronoTitle = new System.Windows.Forms.Label();
            this.lblSpeedValue  = new System.Windows.Forms.Label();
            this.lblCarName     = new System.Windows.Forms.Label();
            this.lblFirstAccel  = new System.Windows.Forms.Label();  // 🎯 Nouveau label
            this.btnGo          = new System.Windows.Forms.Button();
            this.btnChronoStart = new System.Windows.Forms.Button();
            this.btnChronoStop  = new System.Windows.Forms.Button();
            this.btnChronoRestart = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // ── Fond général ───────────────────────────────────────────────────
            this.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);

            // ── Nom de la voiture ──────────────────────────────────────────────
            this.lblCarName.AutoSize  = true;
            this.lblCarName.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCarName.ForeColor = System.Drawing.Color.Red;
            this.lblCarName.Location  = new System.Drawing.Point(20, 18);
            this.lblCarName.Text      = "—";

            // ── Panel Route ────────────────────────────────────────────────────
            this.pnlRoute.Location  = new System.Drawing.Point(0, 60);
            this.pnlRoute.Size      = new System.Drawing.Size(800, 120);
            this.pnlRoute.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.pnlRoute.Paint    += new System.Windows.Forms.PaintEventHandler(this.pnlRoute_Paint);

            // ── Panel Speedometer ──────────────────────────────────────────────
            this.pnlSpeedo.Location  = new System.Drawing.Point(50, 210);
            this.pnlSpeedo.Size      = new System.Drawing.Size(300, 180);
            this.pnlSpeedo.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
            this.pnlSpeedo.Paint    += new System.Windows.Forms.PaintEventHandler(this.pnlSpeedo_Paint);

            // ── Vitesse actuelle ───────────────────────────────────────────────
            this.lblSpeedValue.AutoSize  = false;
            this.lblSpeedValue.Size      = new System.Drawing.Size(300, 40);
            this.lblSpeedValue.Font      = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblSpeedValue.ForeColor = System.Drawing.Color.White;
            this.lblSpeedValue.BackColor = System.Drawing.Color.Transparent;
            this.lblSpeedValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSpeedValue.Location  = new System.Drawing.Point(50, 395);
            this.lblSpeedValue.Text      = "0 km/h";

            // ── Titre Chrono ───────────────────────────────────────────────────
            this.lblChronoTitle.AutoSize  = true;
            this.lblChronoTitle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblChronoTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblChronoTitle.Location  = new System.Drawing.Point(490, 230);
            this.lblChronoTitle.Text      = "CHRONO";

            // ── Valeur Chrono ──────────────────────────────────────────────────
            this.lblChrono.AutoSize  = false;
            this.lblChrono.Size      = new System.Drawing.Size(240, 60);
            this.lblChrono.Font      = new System.Drawing.Font("Courier New", 28F, System.Drawing.FontStyle.Bold);
            this.lblChrono.ForeColor = System.Drawing.Color.Red;
            this.lblChrono.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.lblChrono.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblChrono.Location  = new System.Drawing.Point(480, 260);
            this.lblChrono.Text      = "00:00:00";

            // ── 1ère accélération ──────────────────────────────────────────────
            this.lblFirstAccel.AutoSize  = false;
            this.lblFirstAccel.Size      = new System.Drawing.Size(240, 20);
            this.lblFirstAccel.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblFirstAccel.ForeColor = System.Drawing.Color.Yellow;
            this.lblFirstAccel.BackColor = System.Drawing.Color.Transparent;
            this.lblFirstAccel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFirstAccel.Location  = new System.Drawing.Point(480, 368);
            this.lblFirstAccel.Text      = "";

            // ── Bouton GO (reset) ──────────────────────────────────────────────
            this.btnGo.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGo.Location  = new System.Drawing.Point(480, 400);
            this.btnGo.Size      = new System.Drawing.Size(160, 45);
            this.btnGo.Text      = "🔄 RESET";
            this.btnGo.BackColor = System.Drawing.Color.FromArgb(180, 0, 0);
            this.btnGo.ForeColor = System.Drawing.Color.White;
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Click    += new System.EventHandler(this.btnGo_Click);

            // ── Bouton START Chrono ────────────────────────────────────────────
            this.btnChronoStart.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChronoStart.Location  = new System.Drawing.Point(480, 330);
            this.btnChronoStart.Size      = new System.Drawing.Size(50, 30);
            this.btnChronoStart.Text      = "Start";
            this.btnChronoStart.BackColor = System.Drawing.Color.FromArgb(0, 120, 0);
            this.btnChronoStart.ForeColor = System.Drawing.Color.White;
            this.btnChronoStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChronoStart.Click    += new System.EventHandler(this.btnChronoStart_Click);

            // ── Bouton STOP Chrono ─────────────────────────────────────────────
            this.btnChronoStop.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChronoStop.Location  = new System.Drawing.Point(535, 330);
            this.btnChronoStop.Size      = new System.Drawing.Size(50, 30);
            this.btnChronoStop.Text      = "Stop";
            this.btnChronoStop.BackColor = System.Drawing.Color.FromArgb(180, 0, 0);
            this.btnChronoStop.ForeColor = System.Drawing.Color.White;
            this.btnChronoStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChronoStop.Click    += new System.EventHandler(this.btnChronoStop_Click);

            // ── Bouton RESTART Chrono ──────────────────────────────────────────
            this.btnChronoRestart.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChronoRestart.Location  = new System.Drawing.Point(590, 330);
            this.btnChronoRestart.Size      = new System.Drawing.Size(60, 30);
            this.btnChronoRestart.Text      = "Restart";
            this.btnChronoRestart.BackColor = System.Drawing.Color.FromArgb(120, 120, 0);
            this.btnChronoRestart.ForeColor = System.Drawing.Color.White;
            this.btnChronoRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChronoRestart.Click    += new System.EventHandler(this.btnChronoRestart_Click);

            // ── SimulationForm ─────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(800, 490);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox         = false;
            this.Text                = "Simulation";
            this.Load               += new System.EventHandler(this.SimulationForm_Load);
            this.FormClosing        += new System.Windows.Forms.FormClosingEventHandler(this.SimulationForm_Closing);

            this.Controls.Add(this.lblCarName);
            this.Controls.Add(this.pnlRoute);
            this.Controls.Add(this.pnlSpeedo);
            this.Controls.Add(this.lblSpeedValue);
            this.Controls.Add(this.lblChronoTitle);
            this.Controls.Add(this.lblChrono);
            this.Controls.Add(this.lblFirstAccel);  // 🎯 Ajouter le label
            this.Controls.Add(this.btnChronoStart);
            this.Controls.Add(this.btnChronoStop);
            this.Controls.Add(this.btnChronoRestart);
            this.Controls.Add(this.btnGo);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // ── Déclarations ───────────────────────────────────────────────────────
        private System.Windows.Forms.Panel  pnlRoute;
        private System.Windows.Forms.Panel  pnlSpeedo;
        private System.Windows.Forms.Label  lblChrono;
        private System.Windows.Forms.Label  lblChronoTitle;
        private System.Windows.Forms.Label  lblSpeedValue;
        private System.Windows.Forms.Label  lblCarName;
        private System.Windows.Forms.Label  lblFirstAccel;  // 🎯 Nouveau
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnChronoStart;
        private System.Windows.Forms.Button btnChronoStop;
        private System.Windows.Forms.Button btnChronoRestart;
    }
}