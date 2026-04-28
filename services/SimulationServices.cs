using System;
using Racing.models;

namespace Racing.services
{
    public class SimulationService
    {
        private readonly Car _car;

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

        /// <summary>
        /// Appelée chaque tick (50ms).
        /// isAccelerating = true si espace maintenu.
        /// </summary>
        public void Tick(bool isAccelerating)
        {
            if (IsFinished) return;

            // Augmente la vitesse uniquement si espace maintenu ET pas encore à VitesseMax
            if (isAccelerating && CurrentSpeed < _car.MaxSpeed)
            {
                // Acceleration est en km/h/s → on divise par 20 car tick = 50ms (1s/20)
                CurrentSpeed += _car.Acceleration / 20.0;

                if (CurrentSpeed > _car.MaxSpeed)
                    CurrentSpeed = _car.MaxSpeed;
            }

            // Démarre le chrono dès que la vitesse > 0
            if (CurrentSpeed > 0 && !_chronoStarted)
            {
                _chronoStarted = true;
                _chronoStart   = DateTime.Now;
            }

            // Met à jour le chrono
            if (_chronoStarted)
                ElapsedTime = DateTime.Now - _chronoStart;
        }

        /// <summary>
        /// Appelée quand la voiture atteint 800px → stop chrono, reset vitesse.
        /// </summary>
        public void Finish()
        {
            IsFinished   = true;
            CurrentSpeed = 0;
        }

        /// <summary>
        /// Remet tout à zéro pour une nouvelle course.
        /// </summary>
        public void Reset()
        {
            CurrentSpeed   = 0;
            ElapsedTime    = TimeSpan.Zero;
            _chronoStarted = false;
            IsFinished     = false;
        }
    }
}