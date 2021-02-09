using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityModelCommon;
using CityRepositoryCommon;
using CityModel;

namespace CityServiceCommon
{
    public interface ICityService
    {
        Task<ICity> GetCity(int id);

        Task<List<ICity>> GetAllCity();

        Task<bool> DeleteResident(int id);

        Task<bool> PostResident(IResidents res, int id);
    }

}
