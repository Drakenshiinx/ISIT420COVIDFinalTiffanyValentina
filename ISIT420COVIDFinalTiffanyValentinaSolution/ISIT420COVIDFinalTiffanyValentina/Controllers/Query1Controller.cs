using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ISIT420COVIDFinalTiffanyValentina.Controllers
{
    public class Query1Controller : ApiController
    {
        CovidDeathsDBEntities myDB = new CovidDeathsDBEntities();

        [Route("api/covid/query1")]
        [HttpGet]
        public IHttpActionResult GetPositiveTests()
        {
            DateTime dateSpecific = new DateTime(2020, 06, 19);

            var CovidTestPos = from NursingHome in myDB.NursingHomeDeathsTables
                               from Towns in myDB.TownCTDeathsTables
                               where Towns.Date == dateSpecific && NursingHome.Date == dateSpecific
                               select new 
                               {
                                   Towns.Date,
                                   NursingHome.NursingHome,
                                   Towns.TownName,
                                   NursingHome.COVIDDeath,
                                   Towns.ConfirmedCOVIDDeaths,
                                   NursingHome.COVIDPositive,
                                   Towns.TestPositive
                               };

            return Json(CovidTestPos);
        }

    }
}
