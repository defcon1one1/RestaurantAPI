using RestaurantAPI.Models;
using System.Collections.Generic;

namespace RestaurantAPI.Services
{
    public interface IRestaurantService
    {
        int Create(CreateRestaurantDto dto);
        bool Delete(int id);
        IEnumerable<RestaurantDto> GetAll();
        RestaurantDto GetById(int id);
        bool Update(int id, UpdateRestaurantDto dto);
    }
}