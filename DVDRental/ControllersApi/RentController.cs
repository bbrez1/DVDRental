using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Models;
using Data;
using MongoDB.Bson;

namespace DVDRental.ControllersApi
{
    public class RentalPostObject
    {
        public List<Movie> Movies;
        public string Id;
    }

    public class RentController : ApiController
    {
        // GET: api/Vote
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Vote/5
        public string Get(int id)
        {
            return "value";
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Authorize]
        // verify users address
        public async Task<HttpResponseMessage> Post(RentalPostObject newRental)
        {

            RentalsApi rentalApi = new RentalsApi();            

            Rentals rental = new Rentals();
            rental.RentedMovies = newRental.Movies.Select(x => ObjectId.Parse(x.ObjectId)).ToList();
            rental.UserId = ObjectId.Parse(newRental.Id);
            rental.RentedOn = DateTime.Now;

            await rentalApi.Store(rental);

            //var userAddress = await verificationApi.FetchById(User.Identity.Name);
            //userAddress.username = newUsername.NewUsername;
            //await verificationApi.Store(userAddress);

            return Request.CreateResponse(HttpStatusCode.Created, new { Message = "Done" });

        }


    }
}
