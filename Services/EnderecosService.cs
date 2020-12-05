using System.Linq;
using System.Collections.Generic;
using edital.Data;
using edital.Model;
using edital.Services.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;

namespace edital.Services
{
    public class EnderecosService : IEnderecosService
    {
        private readonly ApplicationDbContext _context;
        
        public EnderecosService(ApplicationDbContext context)
        {
            _context = context;
        }

        //retorna todos os Enderecos cadastrados
        public List<Endereco> GetEnderecos()
        {
            List<Endereco> enderecos = new List<Endereco>();
            //select * from Endereco
            enderecos = _context.endereco.ToList();

            return enderecos;
        }

        //retorna o Endereco que eu passar o id
        public Endereco GetEndereco(int id)
        {
            //select * from endereco where id = ?
            return _context.endereco.SingleOrDefault(e => e.id == id);          
        }

        //cadastra um novo endereco na tabela
        public bool CadastrarEndereco(Endereco endereco)
        {
            bool resp = true;
            try{
                //insert into endereco (nome, uf, ativo) values (?, ?, ?)
                _context.endereco.Add(endereco);
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

        //atualiza os dados do endereco cadastrado
        public bool AtualizaEndereco(Endereco endereco)
        {
            try{
                //update endereco set nome = ?, uf = ?, ativo = ? where id = ?
                _context.endereco.Update(endereco);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex){
                return false;
            }            
        }

        //excluir um endereco cadastrado
        public bool ExcluirEndereco(int id)
        {
            return true;
        } 
    }    
}