using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos.Requests.Pets;
using WebApplication1.Dtos.Responses.Pets;
using WebApplication1.Entidades.Pets;
using WebApplication1.Services.Pets;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpPost("create")]
        public ActionResult<PetResponse> Create([FromBody] PetRequest petRequest)
        {
            var pet = _petService.Create(petRequest as Pet);
            return new PetResponse
            {
                Id = pet.Id,
                Nome = pet.Nome,
                Tipo = pet.Tipo,
                Raca = pet.Raca,
                Idade = pet.Idade,
            };
        }
    }
}