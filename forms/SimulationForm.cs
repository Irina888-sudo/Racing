using System;
using System.Drawing;
using System.Windows.Forms;
using Racing.models;
using Racing.services;

namespace Racing.forms
{
    public partial class SimulationForm : Form
    {
        private readonly SimulationService _simService;
        private readonly System.Windows.Forms.Timer _timer;
        private float _carX        = 20;
        private bool _spaceHeld    = false;
        private bool _raceStarted  = false;
        private bool _raceFinished = false;
        private bool _firstSpacePressed = false;  // 🎯 Track le premier SPACE
        private int _tickCount     = 0;
        private DateTime _spaceHoldStartTime;

        public SimulationForm(Car car)
        {
            InitializeComponent();
            _simService     = new SimulationService(car);
            lblCarName.Text = car.Name;

            _timer          = new System.Windows.Forms.Timer();
            _timer.Interval = 50;
            _timer.Tick    += OnTick;

            this.KeyPreview = true;
            this.KeyDown   += OnKeyDown;
            this.KeyUp     += OnKeyUp;
        }

        private void SimulationForm_Load(object sender, EventArgs e)
        {
            lblChrono.Text = "-00:00:05";
            _timer.Start();
        }

        private void SimulationForm_Closing(object sender, FormClosingEventArgs e)
        {
            _timer.Stop();
            _timer.Dispose();
        }

        private void OnKeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && !_simService.IsFinished)
            {
                if (!_spaceHeld)  // Seulement au premier appui
                {
                    _spaceHeld = true;
                    _spaceHoldStartTime = DateTime.Now;
                    _raceStarted = true;
                    
                    // 🎯 Enregistre le 1er SPACE (1ère accélération)
                    if (!_firstSpacePressed)
                    {
                        _firstSpacePressed = true;
                        _simService.RecordFirstAcceleration();
                    }
                }
                e.SuppressKeyPress = true;
            }
        }

        private void OnKeyUp(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && _spaceHeld)
            {
                // Calcule le temps maintenu et applique l'accélération
                TimeSpan holdDuration = DateTime.Now - _spaceHoldStartTime;
                double secondsHeld = holdDuration.TotalSeconds;

                _simService.ApplyAcceleration(secondsHeld);
                _spaceHeld = false;
            }
        }

        private void OnTick(object? sender, EventArgs e)
        {
            // 🔄 Le chronomètre se met TOUJOURS à jour, indépendamment de la voiture
            _simService.Tick();
            lblChrono.Text = _simService.ElapsedTime.ToString(@"hh\:mm\:ss");

    if (!_raceStarted) return;

            if (!_raceStarted) return;

            _carX += (float)(_simService.CurrentSpeed / 5f);

            // 🏁 Si la voiture atteint la finish
            if (_carX >= pnlRoute.Width - 60 && !_raceFinished)
            {
                _raceFinished = true;  // ✅ Marque que la course est finie
                _carX = pnlRoute.Width - 60;
                // ⚠️ Ne sauvegarde PAS ici - attendre le STOP du chrono
                // ⚠️ Ne termine PAS la simulation ici - attendre le STOP du chrono
            }

            lblSpeedValue.Text = $"{(int)_simService.CurrentSpeed} km/h";
            lblChrono.Text     = _simService.ElapsedTime.ToString(@"hh\:mm\:ss");
            
            // 🎯 Affiche le temps de 1ère accélération
            if (_simService.FirstAccelerationTime.HasValue)
            {
                lblFirstAccel.Text = $"1ère accélération à: {_simService.FirstAccelerationTime:hh\\:mm\\:ss}";
            }

            pnlRoute.Invalidate();
            pnlSpeedo.Invalidate();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            _simService.Reset();
            _carX        = 20;
            _spaceHeld   = false;
            _raceStarted = false;
            _raceFinished = false;
            _firstSpacePressed = false;  // 🔄 Réinitialise aussi le flag 1er SPACE
            _tickCount   = 0;

            lblSpeedValue.Text = "0 km/h";
            lblChrono.Text     = "-00:00:05";
            lblFirstAccel.Text = "";  // 🎯 Vide aussi l'affichage 1ère accélération

            pnlRoute.Invalidate();
            pnlSpeedo.Invalidate();
        }

        private void btnChronoStart_Click(object sender, EventArgs e)
        {
            _simService.StartChrono();
            // ✅ L'affichage se met à jour à la prochaine frame OnTick
        }

        private void btnChronoStop_Click(object sender, EventArgs e)
        {
            _simService.StopChrono();
            
            // 💾 Si la course est finie, sauvegarder le résultat
            if (_raceFinished)
            {
                string saveFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "save.txt");
                _simService.SaveResult(lblCarName.Text, saveFilePath);
                
                _simService.Finish();  // 🏁 Termine vraiment la simulation
                _raceStarted = false;
                
                MessageBox.Show("Course terminée ! Résultat sauvegardé dans save.txt");
            }
            // L'affichage reste sur la dernière valeur du chrono
        }

        private void btnChronoRestart_Click(object sender, EventArgs e)
        {
            _simService.RestartChrono();
            lblChrono.Text = "-00:00:05";  // 🔄 Affiche immédiatement -5
        }

        private void pnlRoute_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int w = pnlRoute.Width;
            int h = pnlRoute.Height;

            g.FillRectangle(Brushes.DimGray, 0, h - 30, w, 30);

            Pen dashPen = new Pen(Color.White, 2);
            dashPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            g.DrawLine(dashPen, 0, h - 15, w, h - 15);

            for (int i = 0; i < h; i += 10)
            {
                Color c = (i / 10 % 2 == 0) ? Color.White : Color.Red;
                g.FillRectangle(new SolidBrush(c), w - 12, i, 12, 10);
            }

            float carY = h - 55;
            g.FillRectangle(Brushes.Red,   _carX,      carY,      60, 25);
            g.FillRectangle(Brushes.White, _carX + 10, carY - 12, 40, 14);
            g.FillEllipse(Brushes.Black,   _carX + 5,  carY + 18, 14, 14);
            g.FillEllipse(Brushes.Black,   _carX + 40, carY + 18, 14, 14);

            if (_raceFinished)  // 🏁 Affiche FINISH dès que la voiture atteint la finish
            {
                g.DrawString("FINISH !", new Font("Segoe UI", 18F, FontStyle.Bold),
                    Brushes.Red, new PointF(w / 2 - 70, h / 2 - 20));
            }
        }

        private void pnlSpeedo_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int cx = pnlSpeedo.Width  / 2;
            int cy = pnlSpeedo.Height - 20;
            int r  = 120;

            g.DrawArc(new Pen(Color.White, 4), cx - r, cy - r, r * 2, r * 2, 180, 180);

            for (int i = 0; i <= 10; i++)
            {
                double angle = Math.PI - (i / 10.0 * Math.PI);
                int x1 = (int)(cx + (r - 10) * Math.Cos(angle));
                int y1 = (int)(cy - (r - 10) * Math.Sin(angle));
                int x2 = (int)(cx + r * Math.Cos(angle));
                int y2 = (int)(cy - r * Math.Sin(angle));
                g.DrawLine(new Pen(Color.Gray, 2), x1, y1, x2, y2);
            }

            double ratio       = _simService.MaxSpeed > 0 ? _simService.CurrentSpeed / _simService.MaxSpeed : 0;
            double needleAngle = Math.PI - (ratio * Math.PI);
            int nx = (int)(cx + (r - 20) * Math.Cos(needleAngle));
            int ny = (int)(cy - (r - 20) * Math.Sin(needleAngle));
            g.DrawLine(new Pen(Color.Red, 3), cx, cy, nx, ny);

            g.FillEllipse(Brushes.White, cx - 6, cy - 6, 12, 12);
        }
    }
}