using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Registro.Views
{
    public partial class Pantalla_Principal : ContentPage
    {
        private bool puertaAbierta = false; // Estado inicial de la puerta
        public static ObservableCollection<string> Notificaciones { get; set; } = new ObservableCollection<string>();

        private readonly HttpClient httpClient = new HttpClient();
        private readonly string baseUrl = "http://192.168.1.123"; // 👈 Reemplaza por la IP real del ESP32

        public Pantalla_Principal()
        {
            InitializeComponent();
            NotificacionesList.ItemsSource = Notificaciones;
        }

        private async void PushButton_Pressed(object sender, EventArgs e)
        {
            puertaAbierta = !puertaAbierta;

            try
            {
                string endpoint = puertaAbierta ? "/abrir" : "/cerrar";
                var response = await httpClient.GetAsync($"{baseUrl}{endpoint}");

                if (response.IsSuccessStatusCode)
                {
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
                else
                {
                    await DisplayAlert("Error", "No se pudo conectar al ESP32", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error de conexión: {ex.Message}", "OK");
            }
        }
    }
}
