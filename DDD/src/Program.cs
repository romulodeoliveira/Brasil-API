using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DDD.src
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Insira o DDD: ");
            string ddd = Console.ReadLine();

            Task.Run(async () =>
            {
                string url = $"https://brasilapi.com.br/api/ddd/v1/{ddd}";

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            string result = await response.Content.ReadAsStringAsync();

                            DDD dddData = JsonConvert.DeserializeObject<DDD>(result);

                            Console.WriteLine($"Estado: {dddData.State}");
                            Console.WriteLine("Cidades:");
                            for (int i = 0; i < dddData.Cities.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {dddData.Cities[i]}");
                            }
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
            }).GetAwaiter().GetResult();
        }
    }
}
