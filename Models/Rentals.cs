using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Rentals
    {

        [BsonIgnoreIfDefault]
        public ObjectId Id;

        public DateTime RentedOn { get; set; }
        public List<ObjectId> RentedMovies { get; set; }
        public ObjectId UserId { get; set; }

        [BsonIgnore]
        public List<Movie> RentedMoviesDetails { get; set; }
        [BsonIgnore]
        public Customer UserDetails { get; set; }

    }
}
