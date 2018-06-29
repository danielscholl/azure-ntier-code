using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApp.DataAccess.Models;
using SimpleApp.DataAccess.Repositories;

namespace SimpleAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AdsController : ControllerBase
    {
        private readonly AdsRepository _repository;

        public AdsController(AdsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
         public ActionResult<List<Ad>> Get()
        {
            return _repository.GetAds();
        }
    }
}