using GetGo_Test.Models;

using System.Collections.Generic;
using System.Drawing;

namespace GetGo_Test.Interfaces
{
    public interface ICarService        
    {
        public List<Cars> GetAll();
        public List<Cars> SearchByName(string name);

        public Cars SearchById(int carId);
        public Cars SearchNearBy(Point userLocation);

        public bool IsCarAvail(int carId);
        public bool BookCar(int carId);

        public bool ReachHomeLot(int carId);


    }
}
