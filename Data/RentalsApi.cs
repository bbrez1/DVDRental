using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RentalsApi
    {

        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        protected static IMongoCollection<Models.Rentals> _collection;

        public RentalsApi()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("DVDStore");
            _collection = _database.GetCollection<Models.Rentals>("rentals");
        }


        public async Task<BsonValue> Store(Models.Rentals postOject)
        {

            try
            {
                var result = await _collection.ReplaceOneAsync(
                    p => p.UserId == postOject.UserId && p.RentedMovies == postOject.RentedMovies,
                    postOject,
                    new UpdateOptions { IsUpsert = true }
                );

                return result.UpsertedId;
            }
            catch (MongoWriteException x)
            {
                Console.WriteLine(x.Message);
                return "";
            }

        }

        public async Task<List<Models.Rentals>> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<List<Models.Rentals>> GetAllByUser(string userId)
        {
            return await _collection.Find(x => x.UserId == ObjectId.Parse(userId)).ToListAsync();
        }

    }
}
