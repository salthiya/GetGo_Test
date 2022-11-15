using GetGo_Test.Models;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;

namespace GetGo_Test.Utility
{
    public class Utility
    {

            

        public static List<Cars> ReadJsonData()
        {
            string text = File.ReadAllText(@"./Data/CarsData.json");
            var carList = JsonSerializer.Deserialize<List<Cars>>(text);
            return carList;
        }

        public static void WriteJsonData(List<Cars> data)
        {
            string fileName = @"./Data/CarsData.json";
            if (data != null)
            {
                string jsonString = JsonSerializer.Serialize(data);
                
                File.WriteAllText(fileName, jsonString);
            }
        }

        public static bool UpdateBookingStatus(int carId, bool status)
        {
            bool isFound=false;
            List<Cars> data = ReadJsonData();
            foreach(Cars car in data){
                if (car.Id == carId)
                {
                    car.isBooked = status;
                    isFound = true;
                }
            }
            WriteJsonData(data);
            return isFound;
        }

        public static List<Cars> GetTestCarsData()
        {            
            return ReadJsonData();
        }
        public static int CalculeteDistance(Point source, Point target)
        {
            int xAxis = target.X - source.X;
            int yAxis = target.Y - source.Y;
            int units = xAxis + yAxis;
            return units;
        }
    }
}
