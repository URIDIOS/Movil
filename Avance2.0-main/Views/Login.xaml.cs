namespace Registro.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new AppShell());
    }

	private async void Button_Clicked_1(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Views.CreateAccontView());
	}

	private async void Button_Clicked_2(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Views.RecuperarContra());
	}
}