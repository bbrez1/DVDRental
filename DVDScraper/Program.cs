using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Data;
using Models;
using System.Net;
using Newtonsoft.Json;

namespace DVDScraper
{
    class Program
    {

        static Random rand = new Random();

        static void GenerateRandomUsers()
        {

            for(int i = 0; i < 20; i++)
            {
                using (WebClient client = new WebClient())
                {


                    string htmlCode = client.DownloadString("http://api.namefake.com");
                    CustomerApi customerApi = new CustomerApi();

                    var customer = JsonConvert.DeserializeObject<Customer>(htmlCode);

                    customerApi.Store(customer).GetAwaiter().GetResult();

                    Console.WriteLine("Inserted " + customer.name);   
                 
                }
            }

        }

        static void GenerateMovies()
        {

            for (int i = 1; i <= 300; i++)
            {
                var htmlWeb = new HtmlWeb();
                var document = htmlWeb.Load("https://www.themoviedb.org/movie?page=" + i);

                foreach (var card in document.DocumentNode.SelectNodes("//*[contains(@class,'item poster card')]"))
                {
                    Movie newMovie = new Movie();
                    newMovie.Title = card.SelectSingleNode("//*[contains(@class,'title result')]").InnerText;

                    var img = card.SelectSingleNode("//*[contains(@class,'poster lazyload')]");
                    newMovie.ImageUrl = img.Attributes["data-srcset"].Value.Split(',').First();
                    newMovie.ImageUrlBig = img.Attributes["data-srcset"].Value.Split(',').Last();

                    newMovie.Genres = card.SelectSingleNode("//*[contains(@class,'genres')]").InnerText;
                    newMovie.ReleaseDate = card.SelectSingleNode("//*[contains(@class,'release_date')]").InnerText;
                    newMovie.Overview = card.SelectSingleNode("//*[contains(@class,'overview')]").InnerText;

                    newMovie.CopiesAvailable = rand.Next(0, 5);

                    MovieApi movieApi = new MovieApi();
                    movieApi.Store(newMovie).GetAwaiter().GetResult();

                    Console.WriteLine("Inserted " + newMovie.Title);
                    break;
                }
            }
        }

        static void Main(string[] args)
        {

            GenerateRandomUsers();

            GenerateMovies();

        }
    }
}
