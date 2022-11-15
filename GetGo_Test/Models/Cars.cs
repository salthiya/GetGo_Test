
using System.Drawing;


namespace GetGo_Test.Models
{
    public class Cars
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isBooked { get; set; }
        public Point HomeLot { get; set; }

        public int? Distance { get; set; }
    }
}
