using System;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Maui.Controls;



namespace TipanExamen2
{
    public partial class ChistesPage : ContentPage
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public ChistesPage()
        {
            InitializeComponent();
            CargarChiste();
        }

        private async void CargarChiste()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("https://official-joke-api.appspot.com/random_joke");
                var chiste = JsonSerializer.Deserialize<Joke>(response);

                if (chiste != null)
                {
                    ChisteLabel.Text = $"{chiste.Setup}\n\n{chiste.Punchline}";
                }
                else
                {
                    ChisteLabel.Text = "No se pudo cargar el chiste.";
                }
            }
            catch (Exception ex)
            {
                ChisteLabel.Text = $"Error al cargar: {ex.Message}";
            }
        }

        private void OnOtroChisteClicked(object sender, EventArgs e)
        {
            CargarChiste();
        }
    }

    public class Joke
    {
        public string Type { get; set; }
        public string Setup { get; set; }
        public string Punchline { get; set; }
        public int Id { get; set; }
    }
}
