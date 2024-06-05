using Basket.API.Models;

namespace Basket.API.Reposoitories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string userName);

        Task<ShoppingCart> UpdateBasket(ShoppingCart basket);

        Task DeleteBasket(string userName);
    }
}
