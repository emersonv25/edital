using System.Linq;
using System.Collections.Generic;
using edital.Data;
using edital.Model;
using edital.Services.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;

namespace edital.Services
{
    public class SegmentosService : ISegmentosService
    {
        private readonly ApplicationDbContext _context;
        
        public SegmentosService(ApplicationDbContext context)
        {
            _context = context;
        }

        //retorna todos os segmentos cadastrados
        public List<Segmento> GetSegmentos()
        {
            List<Segmento> segmentos = new List<Segmento>();
            //select * from segmento
           // segmentos = _context.segmento.ToList();
            segmentos = _context.segmento.Include(s => s.edital).ToList();
            return segmentos;
        }

        //retorna o segmento que eu passar o id
        public Segmento GetSegmento(int id)
        {
            //select * from segmento where id = ?
            Segmento segmento = new Segmento();
            segmento = _context.segmento.Include(e => e.edital).SingleOrDefault(s => s.id == id);
            return segmento;
            //return _context.segmento.SingleOrDefault(e => e.id == id);     

        }

        //cadastra um novo segmento na tabela
        public bool CadastrarSegmento(Segmento segmento)
        {
            bool resp = true;
            try{
                //insert into segmento (nome, uf, ativo) values (?, ?, ?)
                _context.segmento.Add(segmento);
                //commita a instrução no banco de dados
                _context.SaveChanges();               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                resp = false;
            }
            return resp;
        }

        //atualiza os dados do segmento cadastrado
        public bool AtualizaSegmento(Segmento segmento)
        {
            try{
                //update segmento set nome = ?, uf = ?, ativo = ? where id = ?
                _context.segmento.Update(segmento);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex){
                return false;
            }            
        }

        //excluir um segmento cadastrado
        public bool ExcluirSegmento(int id)
        {
            return true;
        } 
    }    
}