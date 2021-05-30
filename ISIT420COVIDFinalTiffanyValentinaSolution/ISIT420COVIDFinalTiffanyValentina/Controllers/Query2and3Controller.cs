using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ISIT420COVIDFinalTiffanyValentina.Controllers
{
    public class Query2and3Controller : ApiController
    {
        CovidDeathsDBEntities myDB = new CovidDeathsDBEntities();
        //// GET api/<controller> for Query 2
        [Route("api/final/query2")]
        [HttpGet]
        public IHttpActionResult GetHamdenJune11()
        {
            DateTime JuneDate = new DateTime(2020, 06, 11);
            var HamdenDeaths = (from NursingHomeDeaths in myDB.NursingHomeDeathsTables
                                join TownHamden in myDB.TownCTDeathsTables
                                on NursingHomeDeaths.TownName equals TownHamden.TownName
                                where TownHamden.Date == JuneDate && NursingHomeDeaths.Date == JuneDate && NursingHomeDeaths.TownName == "Hamden"
                                select new
                                {
                                    NursingHomeDeaths.Date,
                                    NursingHomeDeaths.NursingHome,
                                    NursingHomeDeaths.TownName,
                                    NursingHomeDeaths.COVIDDeath,
                                    TownHamden.ConfirmedCases
                                }).Distinct();
            return Json(HamdenDeaths);
        }

        // GET api/<controller> for Query 3
        [Route("api/final/query3")]
        [HttpGet]
        public IHttpActionResult GetNursingHomes()
        {
            DateTime startDate = new DateTime(2020, 05, 01);
            DateTime endDate = new DateTime(2020, 05, 31);
            var NursingHomesMayCovidPositive = (from NursingHomeDeaths in myDB.NursingHomeDeathsTables
                                                where NursingHomeDeaths.Date > startDate
                                                where NursingHomeDeaths.Date < endDate
                                                where NursingHomeDeaths.COVIDPositive > 50
                                               orderby NursingHomeDeaths.TownName
                                               select new
                                               {
                                                   NursingHomeDeaths.Date,
                                                   NursingHomeDeaths.TownName,
                                                   NursingHomeDeaths.NursingHome,
                                                   NursingHomeDeaths.COVIDPositive
                                               }).Distinct();
            return Json(NursingHomesMayCovidPositive);
        }
    }
}
