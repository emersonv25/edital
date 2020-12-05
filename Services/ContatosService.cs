using System.Linq;
using System.Collections.Generic;
using edital.Data;
using edital.Model;
using edital.Services.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;

namespace edital.Services
{
    public class ContatosService : IContatosService
    {
        private readonly ApplicationDbContext _context;
        
        public ContatosService(ApplicationDbContext context)
        {
            _context = context;
        }

        //retorna todos os Contatos cadastrados
        public List<Contato> GetContatos()
        {
            List<Contato> contatos = new List<Contato>();
            //select * from contato
            contatos = _context.contato.ToList();

            return contatos;
        }

        //retorna o contato que eu passar o id
        public Contato GetContato(int id)
        {
            //select * from contato where id = ?
            return _context.contato.SingleOrDefault(e => e.id == id);          
        }

        //cadastra um novo contato na tabela
        public bool CadastrarContato(Contato contato)
        {
            bool resp = true;
            try{
                //insert into contato (nome, uf, ativo) values (?, ?, ?)
                _context.contato.Add(contato);
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

        //atualiza os dados do contato cadastrado
        public bool AtualizaContato(Contato contato)
        {
            try{
                //update contato set nome = ?, uf = ?, ativo = ? where id = ?
                _context.contato.Update(contato);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex){
                return false;
            }            
        }

        //excluir um contato cadastrado
        public bool ExcluirContato(int id)
        {
            return true;
        } 
    }    
}