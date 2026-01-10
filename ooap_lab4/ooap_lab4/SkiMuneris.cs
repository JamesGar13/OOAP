using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab4
{
    class SkiMuneris
    {
        public string Brand { get; set; }
        public int Id { get; set; }
        public int ShoeSize { get; set; }
        public string Direction { get; set; }

        public SkiMuneris(string brand, int id, int shoeSize, string direction)
        {
            Brand = brand;
            Id = id;
            ShoeSize = shoeSize;
            Direction = direction;
        }

        public override string ToString()
        {
            return $"Brand: {Brand}, Id: {Id}, Shoe Size: {ShoeSize}, Direction: {Direction}";
        }
    }
}
