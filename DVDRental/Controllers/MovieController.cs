using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DVDRental.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {

            return View();

        }

        public async Task<ActionResult> Details(string id)
        {

            MovieApi movieApi = new MovieApi();
            var movie = await movieApi.FetchById(id);

            return View(movie);

        }
    }
}