using Api_Consume.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Api_Consume.Controllers
{
    public class MovieController : Controller
    {
        public async Task<IActionResult> Index()
        {
			List<MovieListViewModel> movies = new List<MovieListViewModel>();
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
				Headers =
	            {
	            	{ "X-RapidAPI-Key", "8353feee66mshf5988d224e46636p1a9300jsncc4fab7ab9cd" },
	            	{ "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
	            },
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				movies = JsonConvert.DeserializeObject<List<MovieListViewModel>>(body);
			}
			return View(movies);
        }
    }
}
