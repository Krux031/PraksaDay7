using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityModelCommon
{
    public interface IResidents
    {
       int Id { get; set; }
        string Ime { get; set; }
        string Prezime { get; set; }
        int Pbr { get; set; }
        string Spol { get; set; }
    }
}
