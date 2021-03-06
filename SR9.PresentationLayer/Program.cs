using SR9.DataLayer;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SR9.PresentationLayer
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            client.BaseAddress = new Uri("http://localhost:15009/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new 
                MediaTypeWithQualityHeaderValue("application/json"));
            var brand = new Brand
            {
                BrandName = "Test",
                Description = "test"
            };
            PostBrandAsync(brand).Wait();
            GetBrandAsync().Wait();
            Console.ReadLine();
        }
        static async Task GetBrandAsync()
        {
            HttpResponseMessage response = await client.GetAsync("api/Brands");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<Brand>>();
                foreach(var item in data)
                {
                    Console.WriteLine("Brand Name:{0}", item.BrandName);
                }
            }
            else
            {
                Console.WriteLine("No record");
            }
        }
        static async Task PostBrandAsync(Brand brand)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync<Brand>("api/Brands",brand);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Record was saved");
            }
            else
            {
                Console.WriteLine("save failed");
            }
        }
    }
}
