using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using CityServiceCommon;
using CityModelCommon;
using CityModel;
using CityService;
using RestModel;
using System.Threading.Tasks;

namespace PraksaDay2.Controllers
{
    [RoutePrefix("api/Hello")]
    public class HelloController : ApiController
    {
        protected ICityService service;

        public HelloController(ICityService serv)
        {
            this.service = serv;
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            ICity rezultat;
            GetViewModel pogled = new GetViewModel();

            rezultat = await service.GetCity(id);

            if (rezultat != null)
            {
                pogled.Naziv = rezultat.Naziv;
                return Request.CreateResponse(HttpStatusCode.OK, pogled);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, "No content");
            }

        }

        [HttpGet]
        [Route("Get/All")]
        public async Task<HttpResponseMessage> GetAll()
        {
            List<ICity> rezultati;
            List<GetViewModel> pogled = new List<GetViewModel>();

            rezultati = await service.GetAllCity();

            if (rezultati != null)
            {
                foreach(City rez in rezultati)
                {
                    pogled.Add(new GetViewModel { Naziv=rez.Naziv });
                }
                return Request.CreateResponse(HttpStatusCode.OK, pogled);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, "No content");
            }

        }

        [HttpDelete]
        [Route("Delete/Resident/{id}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            if (await service.DeleteResident(id) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
            }
        }

        [HttpPost]
        [Route("Post/Resident/{id}")]
        public async Task<HttpResponseMessage> Post([FromBody] PostViewModel res, int id)
        {
            IResidents stanovnik = new Residents();

            if (res.Ime != null) { stanovnik.Ime = res.Ime; } else { stanovnik.Ime = ""; }
            if (res.Prezime != null) { stanovnik.Prezime = res.Prezime; } else { stanovnik.Prezime = ""; }
            if (res.Pbr != null) { stanovnik.Pbr = Int32.Parse(res.Pbr); } else { stanovnik.Pbr = 0; }
            if (res.Spol != null) { stanovnik.Spol = res.Spol; } else { stanovnik.Spol = ""; }

            if (await service.PostResident(stanovnik, id) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Bad Request");
            }
        }
    }
}
