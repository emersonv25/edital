using System.Linq;
using System.Collections.Generic;
using edital.Data;
using edital.Model;
using edital.Services.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;

namespace edital.Services
{
    public class InscricaosService : IInscricaosService
    {
        private readonly ApplicationDbContext _context;
        
        public InscricaosService(ApplicationDbContext context)
        {
            _context = context;
        }

        //retorna todos os inscricaos cadastrados
        public List<Inscricao> GetInscricaos()
        {
            List<Inscricao> inscricaos = new List<Inscricao>();
            //select * from inscricao
            inscricaos = _context.inscricao.ToList();

            return inscricaos;
        }

        //retorna o inscricao que eu passar o cnpj
        public Inscricao GetInscricao(int cnpj)
        {
            //select * from inscricao where id = ?
            return _context.inscricaos.SingleOrDefault(e => e.cnpj == cnpj);          
        }

        //cadastra um novo inscricao na tabela
        public bool CadastrarInscricao(Inscricao inscricao)
        {
            bool resp = true;
            try{
                //insert into inscricao (nome, uf, ativo) values (?, ?, ?)
                _context.inscricao.Add(inscricao);
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

        //atualiza os dados do inscricao cadastrado
        public bool AtualizaInscricao(Inscricao inscricao)
        {
            try{
                //update inscricao set nome = ?, uf = ?, ativo = ? where id = ?
                _context.inscricao.Update(inscricao);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex){
                return false;
            }            
        }

        //excluir um inscricao cadastrado
        public bool ExcluirInscricao(int cnpj)
        {
            return true;
        } 
    }    
}