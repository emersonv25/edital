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
    public class EnderecosController : ControllerBase
    {        
        private readonly IEnderecosService _enderecosService;
        private readonly ICidadesService _cidadeService;

        public EnderecosController(IEnderecosService enderecosService, ICidadesService cidadeService = null)
        {
            _enderecosService = enderecosService;
            _cidadeService = cidadeService;
        }
        
        // GET: api/enderecos
        [HttpGet]
        public ActionResult<List<Endereco>> GetEnderecos()
        {
           return _enderecosService.GetEnderecos();
        }

        // GET: api/enderecos/5
        [HttpGet("{id}")]
        public ActionResult<Endereco> GetEndereco(int id)
        {
           return _enderecosService.GetEndereco(id);
        }

        // PUT: api/enderecos/5
        [HttpPut("{id}")]
       public ActionResult<Endereco> PutEndereco(int id, Endereco endereco)
        {
            if (id != endereco.id)
            {
                return BadRequest();
            }

            bool resp  = _enderecosService.AtualizaEndereco(endereco);
            if(!resp)
            {                            
                return NotFound();
            }

            endereco = _enderecosService.GetEndereco(id);

            return endereco;
        }

        // POST: api/enderecos
       [HttpPost]
        public ActionResult<string> PostEndereco(Endereco novoEndereco)
        {
            bool resp;
            resp = _enderecosService.CadastrarEndereco(novoEndereco);
            if(resp){
                return "Solicitação executada com sucesso!";
            }
            else{
                return "Falha ao executar a solicitação!"; 
            }  
        /*
            if(novoEndereco.cidade == null){
                resp = _enderecosService.CadastrarEndereco(novoEndereco);
            }

            else if (novoEndereco.cidade.id > 0){
               Cidade cidade = _cidadeService.GetCidade(novoEndereco.cidade.id);
               Endereco endereco = new Endereco();
               endereco.logradouro = novoEndereco.logradouro;
               endereco.bairro = novoEndereco.bairro;
               endereco.cep = novoEndereco.cep;
               endereco.complemento = novoEndereco.complemento;
               endereco.numero = novoEndereco.numero;
               endereco.cidade = cidade;
                resp = _enderecosService.CadastrarEndereco(novoEndereco);
            }

            else{
                resp = _enderecosService.CadastrarEndereco(novoEndereco);
            }


            if(resp){
                return "Solicitação executada com sucesso!";
            }
            else{
                return "Falha ao executar a solicitação!"; 
            }     
            */     
        }

      /*  // DELETE: api/enderecos/5
       [HttpDelete("{id}")]
        public ActionResult<endereco> DeletePaciente(int id)
        {
            
        }*/


    }
}