using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet] // GET /api/basket/{id}
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id); // Get the basket from Redis

            return Ok(basket ?? new CustomerBasket(id)); // If the basket is null, return a new CustomerBasket object with the id passed in
        }

        [HttpPost] // POST /api/basket
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            var updatedBasket = await _basketRepository.UpdateBasketAsync(basket); // Update the basket in Redis

            return Ok(updatedBasket);
        }

        [HttpDelete] // DELETE /api/basket/{id}
        public async Task DeleteBasket(string id)
        {
            await _basketRepository.DeleteBasketAsync(id); // Delete the basket from Redis
        }  
    }
}