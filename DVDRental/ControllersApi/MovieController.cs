using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Models;

namespace DVDRental.ControllersApi
{
    public class MovieController : ApiController
    {
        // GET: api/Movie
        public async Task<List<Movie>> Get()
        {
            MovieApi movieApi = new MovieApi();
            return await movieApi.GetAll();
        }

        // GET: api/Movie/5
        public async Task<List<Movie>> Get(int id)
        {
            MovieApi movieApi = new MovieApi();
            return await movieApi.GetAll(id);
        }

        // POST: api/Movie
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Movie/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Movie/5
        public void Delete(int id)
        {
        }
    }
}
