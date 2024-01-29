using System.Text.Json;
using Core.Entities;
using Core.Interfaces;
using StackExchange.Redis;

namespace Infrastructure.Data
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase(); // This is the database we are going to use to interact with Redis
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId); // This is the key we are going to use to delete the basket from Redis
        }

        public async Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            var data = await _database.StringGetAsync(basketId); // This is the key we are going to use to get the basket from Redis

            if (data.IsNullOrEmpty)
            {
                throw new Exception("Failed to get basket.");
            }

            return JsonSerializer.Deserialize<CustomerBasket>(data)!; // If the data is null or empty, throw an exception, otherwise deserialize the data into a CustomerBasket object
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            var created = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30)); // This is the key we are going to use to set the basket in Redis, we are also going to serialize the basket into JSON and set the expiration time to 30 days 

            if (!created) throw new Exception("Failed to update basket."); // If the basket was not created, throw an exception

            var updatedBasket = await GetBasketAsync(basket.Id) ?? throw new Exception("Failed to retrieve updated basket.");
            return updatedBasket;
        }
    }
}