using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleWEB.Models;

namespace SimpleWEB.Controllers
{
    public class ProductController : Controller
    {
        //Hosted web API REST Service base url  
        string Baseurl = "http://localhost:53518/";

        public async Task<ActionResult> Index()
        {
            List<Product> productInfo = new List<Product>();

            using (var client = new HttpClient())
            {
                // Pass Base Address
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                // Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Send request
                HttpResponseMessage res = await client.GetAsync("/api/products");

                // Check Response
                if(res.IsSuccessStatusCode)
                {
                    // Read Data
                    var productResponse = res.Content.ReadAsStringAsync().Result;

                    // Deserialize
                    productInfo = JsonConvert.DeserializeObject<List<Product>>(productResponse);
                }
                
                // Return View
                return View(productInfo);
            }
        }
    }
}