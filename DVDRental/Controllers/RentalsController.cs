using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DVDRental.Controllers
{
    [Authorize]
    public class RentalsController : Controller
    {
        // GET: Rentals
        public async Task<ActionResult> Index()
        {

            RentalsApi rentalsApi = new RentalsApi();
            var rentals = await rentalsApi.GetAll();

            CustomerApi customerApi = new CustomerApi();
            MovieApi movieApi = new MovieApi();

            foreach(var rental in rentals)
            {
                rental.RentedMoviesDetails = await movieApi.FetchByIds(rental.RentedMovies);
                rental.UserDetails = await customerApi.FetchById(rental.UserId);                    
            }

            return View(rentals);

        }

        public async Task<ActionResult> New(string id)
        {

            CustomerApi customerApi = new CustomerApi();
            var customerInfo = await customerApi.FetchById(id);

            return View(customerInfo);

        }

    }
}