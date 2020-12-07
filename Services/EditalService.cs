using System.Linq;
using System.Collections.Generic;
using edital.Data;
using edital.Model;
using edital.Services.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;

namespace edital.Services
{
    public class EditalService : IEditalService
    {
        private readonly ApplicationDbContext _context;
        
        public EditalService(ApplicationDbContext context)
        {
            _context = context;
        }

        //retorna todos os editais cadastrados
        public List<Edital> GetEditais()
        {
            List<Edital> editais = new List<Edital>();
            //select * from edital
            editais = _context.edital.Include(e => e.segmentos).ToList();

            return editais;
        }

        //retorna o edital que eu passar o id
        public Edital GetEdital(int id)
        {
            //select * from edital where id = ?
            return _context.edital.Include(e => e.segmentos).SingleOrDefault(e => e.id == id);          
        }

        //cadastra um novo edital na tabela
        public bool CadastrarEdital(Edital edital)
        {
            bool resp = true;
            try{
                //insert into edital (nome, uf, ativo) values (?, ?, ?)
                _context.edital.Add(edital);
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

        //atualiza os dados do edital cadastrado
        public bool AtualizaEdital(Edital edital)
        {
            try{
                //update edital set nome = ?, uf = ?, ativo = ? where id = ?
                _context.edital.Update(edital);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex){
                return false;
            }            
        }

        //excluir um edital cadastrado
        public bool ExcluirEdital(int id)
        {
            return true;
        } 
    }    
}