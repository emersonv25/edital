using System.Linq;
using System.Collections.Generic;
using edital.Data;
using edital.Model;
using edital.Services.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;

namespace edital.Services
{
    public class CidadesService : ICidadesService
    {
        private readonly ApplicationDbContext _context;
        
        public CidadesService(ApplicationDbContext context)
        {
            _context = context;
        }

        //retorna todos os Cidades cadastrados
        public List<Cidade> GetCidades()
        {
            List<Cidade> cidades = new List<Cidade>();
            //select * from Cidade
            cidades = _context.cidade.Include(c => c.estado).ToList();
            return cidades;
        }

        //retorna o Cidade que eu passar o id
        public Cidade GetCidade(int id)
        {
            //select * from Cidade where id = ?
            return _context.cidade.SingleOrDefault(e => e.id == id);          
        }

        //cadastra um novo Cidade na tabela
        public bool CadastrarCidade(Cidade Cidade)
        {
            bool resp = true;
            try{
                //insert into Cidade (nome, uf, ativo) values (?, ?, ?)
                _context.cidade.Add(Cidade);
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

        //atualiza os dados do Cidade cadastrado
        public bool AtualizaCidade(Cidade Cidade)
        {
            try{
                //update Cidade set nome = ?, uf = ?, ativo = ? where id = ?
                _context.cidade.Update(Cidade);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex){
                return false;
            }            
        }

        //excluir um Cidade cadastrado
        public bool ExcluirCidade(int id)
        {
            return true;
        } 
    }    
}