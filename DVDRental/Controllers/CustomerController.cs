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

    public class CustomerRentals
    {

        public Customer customer { get; set; }
        public List<Rentals> rentals { get; set; }

    }

    [Authorize]
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Details(string id)
        {

            CustomerApi customerApi = new CustomerApi();

            var user = await customerApi.FetchById(id);

            RentalsApi rentalApi = new RentalsApi();
            var rentals = await rentalApi.GetAllByUser(id);


            MovieApi movieApi = new MovieApi();

            foreach (var rental in rentals)
            {
                rental.RentedMoviesDetails = await movieApi.FetchByIds(rental.RentedMovies);
                rental.UserDetails = user;
            }

            //

            CustomerRentals customer = new CustomerRentals();
            customer.customer = user;
            customer.rentals = rentals;

            return View(customer);

        }
    }
}