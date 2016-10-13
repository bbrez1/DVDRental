using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Movie
    {

        [BsonIgnoreIfDefault]
        public ObjectId Id;
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string ImageUrlBig { get; set; }
        public string Genres { get; set; }
        public string ReleaseDate { get; set; }
        public string Overview { get; set; }
        public string ObjectId { get; set; }
        public int CopiesAvailable { get; set; }

    }
}
