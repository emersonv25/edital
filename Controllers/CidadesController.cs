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
    public class CidadesController : ControllerBase
    {        
        private readonly ICidadesService _cidadeService;
        private readonly IEstadosService _estadoService;

        public CidadesController(ICidadesService cidadeService)
        {
            _cidadeService = cidadeService;
        }
        
        // GET: api/Cidades
        [HttpGet]
        public ActionResult<List<Cidade>> GetCidades()
        {
           return _cidadeService.GetCidades();
        }

        // GET: api/Cidades/5
        [HttpGet("{id}")]
        public ActionResult<Cidade> GetCidade(int id)
        {
           return _cidadeService.GetCidade(id);
        }

        // PUT: api/Cidades/5
        [HttpPut("{id}")]
       public ActionResult<Cidade> PutCidade(int id, Cidade Cidade)
        {
            if (id != Cidade.id)
            {
                return BadRequest();
            }

            bool resp  = _cidadeService.AtualizaCidade(Cidade);
            if(!resp)
            {                            
                return NotFound();
            }

            Cidade = _cidadeService.GetCidade(id);

            return Cidade;
        }

        // POST: api/Cidades
       [HttpPost]
        public ActionResult<string> PostCidade(Cidade novoCidade)
        {
            bool resp;

            if(novoCidade.estado.id != 0){
                Estado estado = _estadoService.GetEstado(novoCidade.estado.id);
                Cidade cidade = new Cidade();
                cidade.nome = novoCidade.nome;
                cidade.estado = estado;
                resp = _cidadeService.CadastrarCidade(cidade);
                
            }
            if(novoCidade.estado == null){
                resp = false;
            }

            resp = _cidadeService.CadastrarCidade(novoCidade);

            
            if(resp){
                return "Solicitação executada com sucesso!";
            }
            else{
                return "Falha ao executar a solicitação!"; 
            }           
        }

      /*  // DELETE: api/Cidades/5
       [HttpDelete("{id}")]
        public ActionResult<Cidade> DeletePaciente(int id)
        {
            
        }*/


    }
}
