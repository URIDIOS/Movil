namespace Registro.Views;

public partial class RecuperarContra : ContentPage
{
	public RecuperarContra()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Views.Login());
	}
}