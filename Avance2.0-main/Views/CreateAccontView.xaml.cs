using Registro.Services;
using Registro.ViewModel;

namespace Registro.Views;

public partial class CreateAccontView : ContentPage
{
	public CreateAccontView()
	{
		InitializeComponent();
	}

	// Botón de "Registrar"
	private async void Button_Clicked(object sender, EventArgs e)
	{

		var nombreText = nombre.Text;
		var correoText = correo.Text;
		var contraseñaText = contraseña.Text;

		if (string.IsNullOrWhiteSpace(nombreText) ||
			string.IsNullOrWhiteSpace(correoText) ||
			string.IsNullOrWhiteSpace(contraseñaText))
		{
			await DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
			return;
		}

		var nuevoRegistro = new RegistroViewModel
		{
			Nombre = nombreText,
			Correo = correoText,
			Contraseña = contraseñaText
		};

		var apiService = new ApiService();
		bool success = await apiService.RegistrarUsuario(nuevoRegistro);

		if (success)
		{
			await DisplayAlert("Éxito", "Usuario registrado correctamente", "OK");
			await Navigation.PushAsync(new Login()); // Ir a Login
		}
		else
		{
			await DisplayAlert("Error", "No se pudo registrar el usuario", "OK");
		}
	}

	// Botón "¿Ya tienes cuenta?"
	private async void Button_Clicked_1(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Login());
	}
}
