using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace OpenWeatherAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            Console.WriteLine("Enter your API key");
            var apiKey = Console.ReadLine();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Enter city name below:");
                var cityName = Console.ReadLine();

                //add uom in url
                var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&units=imperial&appid={apiKey}";

                var response = client.GetStringAsync(weatherURL).Result;

                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();

                Console.WriteLine(formattedResponse);
                Console.WriteLine();
                Console.WriteLine("Would you like to choose another city?");
                var userInput = Console.ReadLine();
                Console.WriteLine();
                if (userInput.ToLower() == "no")
                {
                    break;
                }
            }

         }
    }
}
