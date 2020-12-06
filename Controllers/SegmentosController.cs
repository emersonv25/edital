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
    public class SegmentosController : ControllerBase
    {        
        private readonly ISegmentosService _segmentoService;

        public SegmentosController(ISegmentosService segmentoService)
        {
            _segmentoService = segmentoService;
        }
        
        // GET: api/Segmentos
        [HttpGet]
        public ActionResult<List<Segmento>> GetSegmentos()
        {
           return _segmentoService.GetSegmentos();
        }

        // GET: api/Segmentos/5
        [HttpGet("{id}")]
        public ActionResult<Segmento> GetSegmento(int id)
        {
           return _segmentoService.GetSegmento(id);
        }

        // PUT: api/Segmentos/5
        [HttpPut("{id}")]
       public ActionResult<Segmento> PutSegmento(int id, Segmento segmento)
        {
            if (id != segmento.id)
            {
                return BadRequest();
            }

            bool resp  = _segmentoService.AtualizaSegmento(segmento);
            if(!resp)
            {                            
                return NotFound();
            }

            segmento = _segmentoService.GetSegmento(id);

            return segmento;
        }

        // POST: api/Segmentos
       [HttpPost]
        public ActionResult<string> PostSegmento(Segmento novoSegmento)
        {
            bool resp = _segmentoService.CadastrarSegmento(novoSegmento);
            if(resp){
                return "Solicitação executada com sucesso!";
            }
            else{
                return "Falha ao executar a solicitação!"; 
            }           
        }

      /*  // DELETE: api/Segmentos/5
       [HttpDelete("{id}")]
        public ActionResult<Segmento> DeletePaciente(int id)
        {
            
        }*/


    }
}
