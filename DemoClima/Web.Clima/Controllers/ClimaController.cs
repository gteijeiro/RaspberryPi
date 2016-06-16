using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Clima.Data;
using Web.Clima.Model;

namespace Web.Clima.Controllers
{
    [Route("api/[controller]/")]
    public class ClimaController : Controller
    {
        private ApplicationDbContext context;

        public ClimaController(ApplicationDbContext pContext)
        {
            context = pContext;
        }

        [HttpGet]
        [Route("GetLast")]
        public WeatherModel GetLast(string last)
        {
            try
            {
                var allList = context.Weather.ToList().LastOrDefault();

                return allList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IEnumerable<WeatherModel> Get()
        {
            try
            {
               return context.Weather.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        public void Post([FromBody]WeatherModel request)
        {
            try
            {
                context.Weather.Add(request);
                context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
