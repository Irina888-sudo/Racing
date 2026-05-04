using System;
using Racing.models;

namespace Racing.services
{
    public class SimulationService
    {
        private readonly Car _car;
        private int _tickCount = 0;

        public double CurrentSpeed  { get; private set; } = 0;
        public TimeSpan ElapsedTime { get; private set; } = TimeSpan.Zero;
        public bool IsFinished      { get; private set; } = false;

        public double MaxSpeed => _car.MaxSpeed;

        private bool _chronoStarted = false;
        private DateTime _chronoStart;

        public SimulationService(Car car)
        {
            _car = car;
        }

        public void Tick()
        {
            if (IsFinished) return;
    
            _tickCount++;

            // Chrono démarre dès vitesse > 0
            if (CurrentSpeed > 0 && !_chronoStarted)
            {
                _chronoStarted = true;
                _chronoStart   = DateTime.Now;
            }

            if (_chronoStarted)
                ElapsedTime = DateTime.Now - _chronoStart;
        }

        /// <summary>
        /// Applique une augmentation de vitesse basée sur la durée du maintien du spacebar
        /// </summary>
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
                string line = $"{carName} | {timeFormatted} | {finalSpeed} m/s";

                
                string directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
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
            ElapsedTime    = TimeSpan.Zero;
            _chronoStarted = false;
            IsFinished     = false;
        }
    }
}