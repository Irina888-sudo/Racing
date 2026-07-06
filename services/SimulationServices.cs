using System;
using Racing.models;

namespace Racing.services
{
    public class SimulationService
    {
        private readonly Car _car;
        private int _tickCount = 0;

        public double CurrentSpeed  { get; private set; } = 0;
        public TimeSpan ElapsedTime { get; private set; } = TimeSpan.FromSeconds(-5);
        public TimeSpan? FirstAccelerationTime { get; private set; } = null;  // 🎯 Temps du 1er SPACE
        public bool IsFinished      { get; private set; } = false;

        public double MaxSpeed => _car.MaxSpeed;

        // Chrono manuel
        private bool _chronoRunning = false;
        private DateTime _chronoStart;
        private TimeSpan _chronoOffset = TimeSpan.FromSeconds(-5);
        private TimeSpan _lastSavedTime = TimeSpan.FromSeconds(-5);  // 💾 Sauvegarde lors du STOP

        public SimulationService(Car car)
        {
            _car = car;
        }

        public void Tick()
        {
            if (IsFinished) return;
    
            _tickCount++;

            
            if (_chronoRunning)
            {
                ElapsedTime = DateTime.Now - _chronoStart + _chronoOffset;
            }
        }

                public void StartChrono()
        {
            if (!_chronoRunning)
            {
                _chronoRunning = true;
                _chronoStart = DateTime.Now;
                _chronoOffset = _lastSavedTime;  
            }
        }

            public void StopChrono()
        {
            _chronoRunning = false;
            _lastSavedTime = ElapsedTime; 
        }

               public void RestartChrono()
        {
            _chronoRunning = false;
            ElapsedTime = TimeSpan.FromSeconds(-5);
            _chronoOffset = TimeSpan.FromSeconds(-5);
            _lastSavedTime = TimeSpan.FromSeconds(-5);  // 🔄 Réinitialise la valeur sauvegardée
        }

       
        public void RecordFirstAcceleration()
        {
            if (FirstAccelerationTime == null)  // 🎯 Enregistre SEULEMENT si c'est le 1er
            {
                FirstAccelerationTime = ElapsedTime;
            }
        }
        public void ApplyAcceleration(double secondsHeld)
        {
            if (IsFinished) return;

            // Augmente la vitesse de : accélération × secondesHeld
            double speedIncrease = _car.Acceleration * secondsHeld;
            CurrentSpeed += speedIncrease;

            // Plafonne à la vitesse maximale
            if (CurrentSpeed > _car.MaxSpeed)
                CurrentSpeed = _car.MaxSpeed;
        }

       

        public void Finish()
        {
            IsFinished   = true;
            CurrentSpeed = 0;
        }

        public void SaveResult(string carName, string filePath)
        {
            try
            {
                string timeFormatted = ElapsedTime.ToString(@"hh\:mm\:ss");
                // Conversion km/h → m/s (1 km/h = 1/3.6 m/s)
                double speedInMs = CurrentSpeed / 3.6;
                int finalSpeed = (int)speedInMs;
                
                // 🎯 Temps de première accélération
                string firstAccelTime = FirstAccelerationTime?.ToString(@"hh\:mm\:ss") ?? "N/A";
                
                string line = $"{carName} | {timeFormatted} | {finalSpeed} m/s | {firstAccelTime}";

                
                string? directory = Path.GetDirectoryName(filePath);
                if (directory != null && !Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                
                System.IO.File.AppendAllText(filePath, line + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la sauvegarde : {ex.Message}");
            }
        }

        public void Reset()
        {
            CurrentSpeed   = 0;
            ElapsedTime    = TimeSpan.FromSeconds(-5);
            FirstAccelerationTime = null;  // 🔄 Réinitialise le temps 1ère accélération
            _chronoRunning = false;
            _chronoOffset  = TimeSpan.FromSeconds(-5);
            _lastSavedTime = TimeSpan.FromSeconds(-5);
            IsFinished     = false;
        }
    }
}