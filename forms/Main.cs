using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Racing.models;
using Racing.services;

namespace Racing.forms
{
    public partial class Main : Form
    {
        private readonly CarServices _carServices;

        public Main(CarServices carServices)
        {
            InitializeComponent();
            _carServices = carServices;
        }

        // ─── Événements ────────────────────────────────────────────────────────

        private void Main_Load(object sender, EventArgs e)
        {
            List<Car> cars = _carServices.LoadCars();
            AfficherListeVoitures(cars);
        }

        private void listBoxVoitures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxVoitures.SelectedItem == null) return;

            string? nom = listBoxVoitures.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(nom)) return;

            Car? car = _carServices.GetCarByNom(nom);

            if (car != null)
            {
                ShowCarDetails(car);
                btnStart.Enabled = true; // active le bouton dès qu'une voiture est sélectionnée
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (listBoxVoitures.SelectedItem == null) return;

            string? nom = listBoxVoitures.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(nom)) return;

            Car? car = _carServices.GetCarByNom(nom);
            if (car == null) return;

            // Ouvre la fenêtre de simulation en passant la voiture sélectionnée
            SimulationForm simForm = new SimulationForm(car);
            simForm.Show();
        }

        // ─── Affichage ─────────────────────────────────────────────────────────

        private void AfficherListeVoitures(List<Car> cars)
        {
            listBoxVoitures.Items.Clear();
            foreach (Car c in cars)
                listBoxVoitures.Items.Add(c.Name);
        }

        private void ShowCarDetails(Car car)
        {
            lblNomValue.Text          = car.Name;
            lblVitesseValue.Text      = $"{car.MaxSpeed} km/h";
            lblAccelerationValue.Text = $"{car.Acceleration} s (0→100)";
        }
    }
}