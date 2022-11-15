using GetGo_Test.Interfaces;
using GetGo_Test.Models;
using GetGo_Test.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Drawing;

namespace GetGo_Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {


        private readonly ICarService _carService;

        public CarsController()
        {
            _carService = new CarService();
        }



        /// <summary>
        /// Get All Cars
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Cars> Get()
        {
            return _carService.GetAll();
        }

        [HttpGet]
        [Route("SearchByName")]
        public List<Cars> SearchByName([FromQuery] string carName)
        {
            return _carService.SearchByName(carName);
        }

        [HttpGet]
        [Route("SearchById")]
        public Cars SearchById([FromQuery] int carId)
        {
            return _carService.SearchById(carId);
        }

        [HttpGet]
        [Route("SearchNearBy")]
        public Cars SearchNearBy(Point userLocation)
        {
            return _carService.SearchNearBy(userLocation);
        }

        [HttpPut]
        [Route("Book")]
        public bool Book(int carId)
        {
            return _carService.BookCar(carId);
        }

        [HttpPut]
        [Route("ReachHomeLot")]
        public bool ReachHomeLot(int carId)
        {
            return _carService.ReachHomeLot(carId);
        }
    }
}
