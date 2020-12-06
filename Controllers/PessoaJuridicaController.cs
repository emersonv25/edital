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
    public class PessoaJuridicasController : ControllerBase
    {        
        private readonly IPessoaJuridicaService _pessoajuridicaService;

        public PessoaJuridicasController(IPessoaJuridicaService pessoajuridicaService)
        {
            _pessoajuridicaService = pessoajuridicaService;
        }
        
        // GET: api/PessoaJuridicas
        [HttpGet]
        public ActionResult<List<PessoaJuridica>> GetPessoaJuridicas()
        {
           return _pessoajuridicaService.GetPessoaJuridicas();
        }

        // GET: api/PessoaJuridicas/5
        [HttpGet("{id}")]
        public ActionResult<PessoaJuridica> GetPessoaJuridica(int cnpj)
        {
           return _pessoajuridicaService.GetPessoaJuridica(cnpj);
        }

        // PUT: api/PessoaJuridicas/5
        [HttpPut("{id}")]
       public ActionResult<PessoaJuridica> PutPessoaJuridica(int cnpj, PessoaJuridica pessoajuridica)
        {
            if (cnpj != pessoajuridica.cnpj)
            {
                return BadRequest();
            }

            bool resp  = _pessoajuridicaService.AtualizaPessoaJuridica(pessoajuridica);
            if(!resp)
            {                            
                return NotFound();
            }

            pessoajuridica = _pessoajuridicaService.GetPessoaJuridica(cnpj);

            return pessoajuridica;
        }

        // POST: api/PessoaJuridicas
       [HttpPost]
        public ActionResult<string> PostPessoaJuridica(PessoaJuridica novoPessoaJuridica)
        {
            bool resp = _pessoajuridicaService.CadastrarPessoaJuridica(novoPessoaJuridica);
            if(resp){
                return "Solicitação executada com sucesso!";
            }
            else{
                return "Falha ao executar a solicitação!"; 
            }           
        }

      /*  // DELETE: api/PessoaJuridicas/5
       [HttpDelete("{id}")]
        public ActionResult<PessoaJuridica> DeletePaciente(int cnpj)
        {
            
        }*/


    }
}
