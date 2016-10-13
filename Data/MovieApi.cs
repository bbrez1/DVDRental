using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MovieApi
    {

        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        protected static IMongoCollection<Models.Movie> _collection;

        public MovieApi()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("DVDStore");
            _collection = _database.GetCollection<Models.Movie>("movies");
        }

        
        public async Task<BsonValue> Store(Models.Movie postOject)
        {

            try
            {
                // insert movie if it doesn't exist yet; otherwise update an existing one if the name is already taken
                var result = await _collection.ReplaceOneAsync(
                    p => p.Title == postOject.Title,
                    postOject,
                    new UpdateOptions { IsUpsert = true }
                );

                // inserted
                return result.UpsertedId;
            }
            catch (MongoWriteException x)
            {
                Console.WriteLine(x.Message);
                return "";
            }

        }



        public async Task<Models.Movie> FetchById(string id)
        {
            return await _collection.Find(x => x.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();
        }



        public async Task<List<Models.Movie>> FetchByIds(List<ObjectId> ids)
        {
            return await _collection.Find(x => ids.Contains(x.Id)).ToListAsync();
        }



        public async Task<List<Models.Movie>> GetAll()
        {
            // in last X days
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<List<Models.Movie>> GetAll(int page)
        {
            // in last X days
            return await _collection.Find(_ => true).Limit(50).Skip(page * 50).ToListAsync();
        }

        public async Task<List<Models.Movie>> SearchByName(string name)
        {
            // in last X days
            return await _collection.Find(x => x.Title.Contains(name)).ToListAsync();
        }

    }
}
