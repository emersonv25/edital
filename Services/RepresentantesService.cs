using System.Linq;
using System.Collections.Generic;
using edital.Data;
using edital.Model;
using edital.Services.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;

namespace edital.Services
{
    public class RepresentantesService : IRepresentantesService
    {
        private readonly ApplicationDbContext _context;
        
        public RepresentantesService(ApplicationDbContext context)
        {
            _context = context;
        }

        //retorna todos os representantes cadastrados
        public List<Representante> GetRepresentantes()
        {
            List<Representante> representantes = new List<Representante>();
            //select * from representante
            representantes = _context.representante.ToList();

            return representantes;
        }

        //retorna o representante que eu passar o id
        public Representante GetRepresentante(int id)
        {
            //select * from representante where id = ?
            return _context.representante.SingleOrDefault(e => e.id == id);          
        }

        //cadastra um novo representante na tabela
        public bool CadastrarRepresentante(Representante representante)
        {
            bool resp = true;
            try{
                //insert into representante (nome, uf, ativo) values (?, ?, ?)
                _context.representante.Add(representante);
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

        //atualiza os dados do representante cadastrado
        public bool AtualizaRepresentante(Representante representante)
        {
            try{
                //update representante set nome = ?, uf = ?, ativo = ? where id = ?
                _context.representante.Update(representante);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex){
                return false;
            }            
        }

        //excluir um representante cadastrado
        public bool ExcluirRepresentante(int id)
        {
            return true;
        } 
    }    
}