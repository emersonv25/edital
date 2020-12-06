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
    public class InscricaosController : ControllerBase
    {        
        private readonly IInscricaosService _inscricaoService;

        public InscricaosController(IInscricaosService inscricaoService)
        {
            _inscricaoService = inscricaoService;
        }
        
        // GET: api/Inscricaos
        [HttpGet]
        public ActionResult<List<Inscricao>> GetInscricaos()
        {
           return _inscricaoService.GetInscricaos();
        }

        // GET: api/Inscricaos/5
        [HttpGet("{id}")]
        public ActionResult<Inscricao> GetInscricao(int id)
        {
           return _inscricaoService.GetInscricao(id);
        }

        // PUT: api/Inscricaos/5
        /*
        [HttpPut("{id}")]
       public ActionResult<Inscricao> PutInscricao(int id, Inscricao inscricao)
        {
            if (id != inscricao.id)
            {
                return BadRequest();
            }

            bool resp  = _inscricaoService.AtualizaInscricao(inscricao);
            if(!resp)
            {                            
                return NotFound();
            }

            inscricao = _inscricaoService.GetInscricao(id);

            return inscricao;
        }*/

        // POST: api/Inscricaos
       [HttpPost]
        public ActionResult<string> PostInscricao(Inscricao novoInscricao)
        {
            bool resp = _inscricaoService.CadastrarInscricao(novoInscricao);
            if(resp){
                return "Solicitação executada com sucesso!";
            }
            else{
                return "Falha ao executar a solicitação!"; 
            }           
        }

      /*  // DELETE: api/Inscricaos/5
       [HttpDelete("{id}")]
        public ActionResult<Inscricao> DeletePaciente(int id)
        {
            
        }*/


    }
}
