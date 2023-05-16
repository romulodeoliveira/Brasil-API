using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using API.src;

// dotnet add package Newtonsoft.Json
// https://brasilapi.com.br/

namespace API.src
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Digite o CEP: ");
            string cep = Console.ReadLine();

            string apiUrl = $"https://brasilapi.com.br/api/cep/v1/{cep}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        CepInfo cepInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<CepInfo>(responseBody);

                        Console.WriteLine($"CEP: {cepInfo.cep}");
                        Console.WriteLine($"Estado: {cepInfo.state}");
                        Console.WriteLine($"Cidade: {cepInfo.city}");
                        Console.WriteLine($"Bairro: {cepInfo.neighborhood}");
                        Console.WriteLine($"Rua: {cepInfo.street}");
                        Console.WriteLine($"Serviço: {cepInfo.service}");
                    }
                    else
                    {
                        Console.WriteLine("A requisição à API retornou um erro.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                }
            }
        }
    }
}