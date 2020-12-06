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
    public class InscricaoController : ControllerBase
    {        
        private readonly IInscricaoService _inscricaoService;

        public InscricaoController(IInscricaoService inscricaoService)
        {
            _inscricaoService = inscricaoService;
        }
        
        // GET: api/Inscricao
        [HttpGet]
        public ActionResult<List<Inscricao>> GetInscricoes()
        {
           return _inscricaoService.GetInscricoes();
        }

        // GET: api/Inscricao/5
        
        [HttpGet("{cnpj}")]
        public ActionResult<Inscricao> GetInscricao(int cnpj)
        {
           return _inscricaoService.GetInscricao(cnpj);
        }

        // PUT: api/Inscricao/5
        
        [HttpPut("{cnpj}")]
       public ActionResult<Inscricao> PutInscricao(int cnpj, Inscricao inscricao)
        {
            if (cnpj != inscricao.pessoajuridica.cnpj)
            {
                return BadRequest();
            }

            bool resp  = _inscricaoService.AtualizaInscricao(inscricao);
            if(!resp)
            {                            
                return NotFound();
            }

            inscricao = _inscricaoService.GetInscricao(cnpj);

            return inscricao;
        }

        // POST: api/Inscricao
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

      /*  // DELETE: api/Inscricao/5
       [HttpDelete("{id}")]
        public ActionResult<Inscricao> DeletePaciente(int id)
        {
            
        }*/


    }
}
