using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityModelCommon;

namespace CityModel
{
    public class Residents : IResidents
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Pbr { get; set; }
        public string Spol { get; set; }
    }
}
