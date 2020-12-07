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
    public class EditalController : ControllerBase
    {        
        private readonly IEditalService _editalService;

        public EditalController(IEditalService editalService)
        {
            _editalService = editalService;
        }
        
        // GET: api/edital
        [HttpGet]
        public ActionResult<List<Edital>> GetEditais()
        {
           return _editalService.GetEditais();
        }

        // GET: api/edital/5
        [HttpGet("{id}")]
        public ActionResult<Edital> GetEdital(int id)
        {
           return _editalService.GetEdital(id);
        }

        // PUT: api/edital/5
        [HttpPut("{id}")]
       public ActionResult<Edital> PutEdital(int id, Edital edital)
        {
            if (id != edital.id)
            {
                return BadRequest();
            }

            bool resp  = _editalService.AtualizaEdital(edital);
            if(!resp)
            {                            
                return NotFound();
            }

            edital = _editalService.GetEdital(id);

            return edital;
        }

        // POST: api/edital
       [HttpPost]
        public ActionResult<string> PostEdital(Edital novoEdital)
        {
            bool resp;
            resp = _editalService.CadastrarEdital(novoEdital);


            if(resp){
                return "Solicitação executada com sucesso!";
            }
            else{
                return "Falha ao executar a solicitação!"; 
            }     
              
        }

      /*  // DELETE: api/edital/5
       [HttpDelete("{id}")]
        public ActionResult<edital> DeletePaciente(int id)
        {
            
        }*/


    }
}