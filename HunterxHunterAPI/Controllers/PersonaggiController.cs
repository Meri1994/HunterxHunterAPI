using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HunterxHunterAPI.Services;
using HunterxHunterAPI.Models;

namespace HunterxHunterAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonaggiController : ControllerBase
    {
        private IPersonaggiService _personaggiService = ScaffoldingPersonaggiServices.GetInstance();

        [HttpGet]

        public List<Personaggi> Get()
        {
            var ris = _personaggiService.GetAll();

            return ris;

        }

        [HttpPost]

        public bool AddNewChamp([FromBody] Personaggi Personaggio)
        {

           return  _personaggiService.AddPersonaggio(Personaggio);

        }





    }
}
