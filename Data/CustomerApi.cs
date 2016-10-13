using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CustomerApi
    {

        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        protected static IMongoCollection<Models.Customer> _collection;

        public CustomerApi()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("DVDStore");
            _collection = _database.GetCollection<Models.Customer>("customers");
        }


        public async Task<BsonValue> Store(Models.Customer postOject)
        {

            try
            {
                // insert movie if it doesn't exist yet; otherwise update an existing one if the name is already taken
                var result = await _collection.ReplaceOneAsync(
                    p => p.name == postOject.name,
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

        public async Task<Models.Customer> FetchById(string id)
        {
            return await _collection.Find(x => x.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();
        }

        public async Task<Models.Customer> FetchById(ObjectId id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }


        public async Task<List<Models.Customer>> GetAll()
        {
            // in last X days
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<List<Models.Customer>> GetAll(int page)
        {
            // in last X days
            return await _collection.Find(_ => true).Limit(10).Skip(page * 10).ToListAsync();
        }

        public async Task<List<Models.Customer>> SearchByName(string name)
        {
            // in last X days
            return await _collection.Find(x => x.name.Contains(name)).ToListAsync();
        }

    }
}
