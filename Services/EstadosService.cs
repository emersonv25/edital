using System.Linq;
using System.Collections.Generic;
using edital.Data;
using edital.Model;
using edital.Services.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;

namespace edital.Services
{
    public class EstadosService : IEstadosService
    {
        private readonly ApplicationDbContext _context;
        
        public EstadosService(ApplicationDbContext context)
        {
            _context = context;
        }

        //retorna todos os estados cadastrados
        public List<Estado> GetEstados()
        {
            List<Estado> estados = new List<Estado>();
            //select * from estado
            estados = _context.estado.ToList();
            return estados;
        }

        //retorna o estado que eu passar o id
        public Estado GetEstado(int id)
        {
            //select * from estado where id = ?
            return _context.estado.SingleOrDefault(e => e.id == id);          
        }

        //cadastra um novo estado na tabela
        public bool CadastrarEstado(Estado estado)
        {
            bool resp = true;
            try{
                //insert into estado (nome, uf, ativo) values (?, ?, ?)
                _context.estado.Add(estado);
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

        //atualiza os dados do estado cadastrado
        public bool AtualizaEstado(Estado estado)
        {
            try{
                //update estado set nome = ?, uf = ?, ativo = ? where id = ?
                _context.estado.Update(estado);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex){
                return false;
            }            
        }

        //excluir um estado cadastrado
        public bool ExcluirEstado(int id)
        {
            return true;
        } 
    }    
}