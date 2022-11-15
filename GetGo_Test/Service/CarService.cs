using GetGo_Test.Interfaces;
using GetGo_Test.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GetGo_Test.Service
{
    public class CarService : ICarService
    {

        private readonly List<Cars> _carsData;

        public CarService()
        {
            _carsData = Utility.Utility.GetTestCarsData();
        }

        public List<Cars> GetAll()
        {
            return _carsData;
        }

        public List<Cars> SearchByName(string carName)
        {
            
            var filteredData = _carsData.FindAll(dt => dt.Name.Equals(carName, System.StringComparison.CurrentCultureIgnoreCase));

            return filteredData;

        }
        public Cars SearchById(int carId)
        {
            var filteredData = _carsData.Find(dt => dt.Id == carId);

            return filteredData;

        }

        public bool BookCar(int carId)
        {
            if (IsCarAvail(carId)){
                //book this car
                Utility.Utility.UpdateBookingStatus(carId, true);
                return true;
            }
            return false;
        }

        public bool IsCarAvail(int carId)
        {
            var filteredData = _carsData.Find(dt => dt.Id == carId && dt.isBooked==false);
            
            return filteredData != null;
        }

        public Cars SearchNearBy(Point userLocation)
        {
            List<Cars> allCars= CalculateDistance(userLocation);
            try
            {
                var minDistance = allCars.Min(car => car.Distance);
                return allCars.First(car => car.Distance == minDistance);
            }
            catch
            {
                return null;
            }
        }

        private List<Cars> CalculateDistance(Point userLocation) {

            List<Cars> allCars = GetAll();           

            foreach (Cars car in allCars)
            {
                car.Distance = Utility.Utility.CalculeteDistance(car.HomeLot, userLocation);
            }
            //Utility.Utility.WriteJsonData(allCars);
            return allCars;

        }

        public bool ReachHomeLot(int carId)
        {
            return Utility.Utility.UpdateBookingStatus(carId, false);
        }
    }
}
