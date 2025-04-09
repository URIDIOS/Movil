using Registro.ViewModel;
using System.Net.Http.Json;

namespace Registro.Services
{
	public class ApiService
	{
		private readonly HttpClient _httpClient;

		public ApiService()
		{
			_httpClient = new HttpClient
			{
				BaseAddress = new Uri("https://sdq4n1ph-5147.usw3.devtunnels.ms/api/Registro")
			};

		}

		public async Task<bool> RegistrarUsuario(RegistroViewModel registro)
		{
			var response = await _httpClient.PostAsJsonAsync("", registro);

			var responseContent = await response.Content.ReadAsStringAsync();
			System.Diagnostics.Debug.WriteLine($"StatusCode: {response.StatusCode}");
			System.Diagnostics.Debug.WriteLine($"Response: {responseContent}");

			return response.IsSuccessStatusCode;
		}

		// Puedes agregar aquí métodos para GetAll, GetById, Update, Delete...
	}
}
