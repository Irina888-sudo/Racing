using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Racing.models;

namespace Racing.services
{
    public class CarServices
    {
        private readonly string _filePath;
        private List<Car> _cars; 
 
        public CarServices(string filePath)
        {
            _filePath = filePath;
            _cars = new List<Car>();
        }
        public List<Car> LoadCars()
        {
            _cars.Clear();
 
            if (!File.Exists(_filePath))
                throw new FileNotFoundException($"Fichier introuvable : {_filePath}");
 
            string[] lignes = File.ReadAllLines(_filePath);
 
            foreach (string ligne in lignes)
            {
                if (string.IsNullOrWhiteSpace(ligne)) continue;
 
                string[] parts = ligne.Split('|');
 
                if (parts.Length != 3) continue;
 
                string nom = parts[0].Trim();
 
                if (!int.TryParse(parts[1].Trim(), out int vitesseMax)) continue;
                if (!double.TryParse(parts[2].Trim(), out double acceleration)) continue;
 
                _cars.Add(new Car(nom, vitesseMax, acceleration));
            }
 
            return _cars;
        }
 
        public Car GetCarByNom(string nom)
        {
            return _cars.FirstOrDefault(c => c.Name.Equals(nom, StringComparison.OrdinalIgnoreCase));
        }
    }
}