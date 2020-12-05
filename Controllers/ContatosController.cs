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
    public class ContatosController : ControllerBase
    {        
        private readonly IContatosService _contatoService;

        public ContatosController(IContatosService contatoService)
        {
            _contatoService = contatoService;
        }
        
        // GET: api/Contatos
        [HttpGet]
        public ActionResult<List<Contato>> GetContatos()
        {
           return _contatoService.GetContatos();
        }

        // GET: api/Contatos/5
        [HttpGet("{id}")]
        public ActionResult<Contato> GetContato(int id)
        {
           return _contatoService.GetContato(id);
        }

        // PUT: api/Contatos/5
        [HttpPut("{id}")]
       public ActionResult<Contato> PutContato(int id, Contato contato)
        {
            if (id != contato.id)
            {
                return BadRequest();
            }

            bool resp  = _contatoService.AtualizaContato(contato);
            if(!resp)
            {                            
                return NotFound();
            }

            contato = _contatoService.GetContato(id);

            return contato;
        }

        // POST: api/Contatos
       [HttpPost]
        public ActionResult<string> PostContato(Contato novoContato)
        {
            bool resp = _contatoService.CadastrarContato(novoContato);
            if(resp){
                return "Solicitação executada com sucesso!";
            }
            else{
                return "Falha ao executar a solicitação!"; 
            }           
        }

      /*  // DELETE: api/Contatos/5
       [HttpDelete("{id}")]
        public ActionResult<Contato> DeletePaciente(int id)
        {
            
        }*/


    }
}
