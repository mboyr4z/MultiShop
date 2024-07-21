using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;
using StackExchange.Redis;
using System.Text.Json;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string userId)
        {
            _redisService.GetDb().KeyDeleteAsync(userId);
        }


       
        public async Task<BasketTotalDto> GetBasket(string userId)
        {
            RedisValue existBasket = await _redisService.GetDb().StringGetAsync(userId);

            if (string.IsNullOrEmpty(existBasket))
            {
                // Handle the case where the basket for the user does not exist
                return null; // or throw an exception, depending on your logic
            }
            
            BasketTotalDto basketTotalDto = JsonSerializer.Deserialize<BasketTotalDto>(existBasket);

            return basketTotalDto;
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
        }
    }
}
