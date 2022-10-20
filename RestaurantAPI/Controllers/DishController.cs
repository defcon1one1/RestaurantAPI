using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant/{restaurantId}/dish")]
    [ApiController]

    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }

        [HttpDelete]
        public ActionResult Delete([FromRoute]int restaurantId)
        {
            _dishService.RemoveAll(restaurantId);

            return NoContent();
        }

        [HttpDelete("{dishId}")]
        public ActionResult DeleteById([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            _dishService.RemoveById(restaurantId, dishId);

            return NoContent();
        }

        [HttpPost]
        public ActionResult Post([FromRoute] int restaurantId, [FromBody] CreateDishDto dto)
        {
            var newDishId = _dishService.Create(restaurantId, dto);

            return Created($"api/restaurant/{restaurantId}/dish/{newDishId})", null);
        }

        [HttpGet("{dishId}")]
        public ActionResult<DishDto> Get([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            var dish = _dishService.GetById(restaurantId, dishId);
            return Ok(dish);
        }
        [HttpGet]
        public ActionResult<DishDto> GetAll([FromRoute] int restaurantId)
        {
            var result = _dishService.GetAll(restaurantId);
            return Ok(result);
        }
    }
}
