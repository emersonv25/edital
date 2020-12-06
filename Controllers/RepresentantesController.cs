using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using edital.Data;
using edital.Model;
using edital.Services;
using edital.Services.Interfaces;

namespace edital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepresentantesController : ControllerBase
    {        
        private readonly IRepresentantesService _representanteService;

        public RepresentantesController(IRepresentantesService representanteService)
        {
            _representanteService = representanteService;
        }
        
        // GET: api/Representantes
        [HttpGet]
        public ActionResult<List<Representante>> GetRepresentantes()
        {
           return _representanteService.GetRepresentantes();
        }

        // GET: api/Representantes/5
        [HttpGet("{id}")]
        public ActionResult<Representante> GetRepresentante(int id)
        {
           return _representanteService.GetRepresentante(id);
        }

        // PUT: api/Representantes/5
        [HttpPut("{id}")]
       public ActionResult<Representante> PutRepresentante(int id, Representante representante)
        {
            if (id != representante.id)
            {
                return BadRequest();
            }

            bool resp  = _representanteService.AtualizaRepresentante(representante);
            if(!resp)
            {                            
                return NotFound();
            }

            representante = _representanteService.GetRepresentante(id);

            return representante;
        }

        // POST: api/Representantes
       [HttpPost]
        public ActionResult<string> PostRepresentante(Representante novoRepresentante)
        {
            bool resp = _representanteService.CadastrarRepresentante(novoRepresentante);
            if(resp){
                return "Solicitação executada com sucesso!";
            }
            else{
                return "Falha ao executar a solicitação!"; 
            }           
        }

      /*  // DELETE: api/Representantes/5
       [HttpDelete("{id}")]
        public ActionResult<Representante> DeletePaciente(int id)
        {
            
        }*/


    }
}
