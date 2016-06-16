using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Clima.Consola
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var prog = new Program();
            prog.UpdateService(new WeatherEntity()
            {
                Humidity = "40",
                LastUpdate = DateTime.Now.ToString(),
                Temperature = "12"
            });

        }

        private void UpdateService(WeatherEntity entity)
        {
            try
            {
                var ojectConvert = JsonConvert.SerializeObject(entity);

                HttpContent content = new StringContent(ojectConvert.ToString(), Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    // New code:
                    client.BaseAddress = new Uri("http://democlima.azurewebsites.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var result = client.PostAsync("api/clima/", content).Result;
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
