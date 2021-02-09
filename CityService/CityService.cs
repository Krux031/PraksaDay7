using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityServiceCommon;
using CityModelCommon;
using CityRepositoryCommon;
using CityModel;
using CityRepository;

namespace CityService
{
    public class Service : ICityService
    {
        protected ICityRepository repository = new Repository();

        public Service(ICityRepository repo)
        {
            this.repository = repo;
        }

        public async Task<ICity> GetCity(int id)
        {
            return await repository.GetCityRep(id);
        }

        public async Task<List<ICity>> GetAllCity()
        {
            return await repository.GetAllCityRep();
        }

        public async Task<bool> DeleteResident(int id)
        {
            return await repository.DeleteresidentRep(id);
        }

        public async Task<bool> PostResident(IResidents res, int id)
        {
            return await repository.PostResidentRep(res, id);
        }
    }
}
