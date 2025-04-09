using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace Registro.Views
{
    public partial class Historial : ContentPage
    {
        public Historial()
        {
            InitializeComponent();
            NotificacionesList.ItemsSource = Pantalla_Principal.Notificaciones; // Sincroniza con las notificaciones de Pantalla_Principal
        }
    }
}
