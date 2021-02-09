using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityModelCommon;
using CityModel;

namespace CityRepositoryCommon
{
    public interface ICityRepository
    {
        Task<ICity> GetCityRep(int id);

        Task<List<ICity>> GetAllCityRep();

        Task<bool> DeleteresidentRep(int id);

        Task<bool> PostResidentRep(IResidents res, int id);
    }
}
