using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using edital.Data;
using edital.Model;

namespace edital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EstadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Estados
        [HttpGet]
        public ActionResult<List<Estado>> GetEstados()
        {
            return _context.estado.ToList();
        }

        // GET: api/Estados/5
        [HttpGet("{id}")]
        public ActionResult<Estado> GetEstado(int id)
        {
            var estado = _context.estado.Find(id);

            if (estado == null)
            {
                return NotFound();
            }

            return estado;
        }
    }
}
