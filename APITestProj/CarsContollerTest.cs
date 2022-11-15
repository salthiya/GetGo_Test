using GetGo_Test.Controllers;
using GetGo_Test.Interfaces;
using GetGo_Test.Service;
using System.Drawing;
using Xunit;

namespace APITestProj
{
    public class CarsContollerTest
    {
        CarsController _controller;
        ICarService _service;


        public CarsContollerTest()
        {
            _service = new CarService();
            _controller = new CarsController();
        }

        [Fact]
        public void GetAllTest()
        {

            int carCount = 0;
            var listCars = _controller.Get();
            using (var car = listCars.GetEnumerator())
            {
                while (car.MoveNext())
                    carCount++;
            }

            Assert.Equal(5, carCount);
        }

        [Fact]
        public void SearchByNameTest()
        {
            string name = "carsA";
            int carCount = 0;
            var listCars = _controller.SearchByName(name);
            using (var car = listCars.GetEnumerator())
            {
                while (car.MoveNext())
                    carCount++;
            }

            Assert.Equal(1, carCount);
        }

        [Fact]
        public void SearchByIdTest()
        {
            int Id = 5;
            var car = _controller.SearchById(Id);          

            Assert.NotNull(car);
        }

        [Fact]
        public void SearchNearByTest()
        {
            Point userPoint = new Point { X = 1, Y = 2 };
            var car = _controller.SearchNearBy(userPoint);

            Assert.NotNull(car);
        }

        [Fact]
        public void BookCarTest()
        {
            int carID = 5;
            var response = _controller.Book(carID);
            var cars = _controller.Get();
            Assert.True(response);
        }

        [Fact]
        public void ReachHomeLotTest()
        {
            int carID = 5;
            var response = _controller.ReachHomeLot(carID);

            Assert.True(response);
        }
    }
}
