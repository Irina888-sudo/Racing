using System;
using System.IO;
using System.Windows.Forms;
using Racing.forms;
using Racing.services;


namespace Racing
{
   internal static class Program
 {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
 
            // Le chemin du fichier est construit dynamiquement depuis le dossier de l'exe
            string filePath = Path.Combine(Application.StartupPath, "Data", "cars.txt");
 
            CarServices carService = new CarServices(filePath);
 
            Application.Run(new Main(carService));
        }
    }
}

