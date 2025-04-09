using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace Registro.Views
{
    public partial class Pantalla_Principal : ContentPage
    {
        private bool puertaAbierta = false; // Estado inicial de la puerta
        public static ObservableCollection<string> Notificaciones { get; set; } = new ObservableCollection<string>();

        public Pantalla_Principal()
        {
            InitializeComponent();
            NotificacionesList.ItemsSource = Notificaciones; // Vincula la lista de notificaciones
        }

        private void PushButton_Pressed(object sender, EventArgs e)
        {
            puertaAbierta = !puertaAbierta; // Cambia el estado de la puerta

            if (puertaAbierta)
            {
                PushButton.BackgroundColor = Colors.Green;
                StatusLabel.Text = "Abierto";
                StatusLabel.TextColor = Colors.Green;
                Notificaciones.Insert(0, $"La puerta se abrió {DateTime.Now:hh:mm tt dd/MM/yyyy}");
            }
            else
            {
                PushButton.BackgroundColor = Colors.Red;
                StatusLabel.Text = "Cerrado";
                StatusLabel.TextColor = Colors.Red;
                Notificaciones.Insert(0, $"La puerta se cerró {DateTime.Now:hh:mm tt dd/MM/yyyy}");
            }
        }
    }
}
