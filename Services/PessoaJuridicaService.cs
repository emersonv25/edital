using System.Linq;
using System.Collections.Generic;
using edital.Data;
using edital.Model;
using edital.Services.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;

namespace edital.Services
{
    public class PessoaJuridicaService : IPessoaJuridicaService
    {
        private readonly ApplicationDbContext _context;
        
        public PessoaJuridicaService(ApplicationDbContext context)
        {
            _context = context;
        }

        //retorna todos os pessoajuridicas cadastrados
        public List<PessoaJuridica> GetPessoaJuridicas()
        {
            List<PessoaJuridica> pessoajuridicas = new List<PessoaJuridica>();
            //select * from pessoajuridica
            pessoajuridicas = _context.pessoajuridica
            .Include(e => e.endereco)
            .Include(e => e.endereco.cidade)
            .Include(e => e.endereco.cidade.estado)
            .Include(r => r.representante)
            .Include(r=> r.representante.contato)
            .Include(r => r.representante.endereco)
            .Include(r => r.representante.endereco.cidade)
            .Include(r => r.representante.endereco.cidade.estado)
            .Include(c => c.contato)
            .ToList();

            return pessoajuridicas;
        }

        //retorna o pessoajuridica que eu passar o id
        public PessoaJuridica GetPessoaJuridica(int cnpj)
        {
            //select * from pessoajuridica where id = ?
            return _context.pessoajuridica            
            .Include(e => e.endereco)
            .Include(e => e.endereco.cidade)
            .Include(e => e.endereco.cidade.estado)
            .Include(r => r.representante)
            .Include(r=> r.representante.contato)
            .Include(r => r.representante.endereco)
            .Include(r => r.representante.endereco.cidade)
            .Include(r => r.representante.endereco.cidade.estado)
            .Include(c => c.contato)
            .SingleOrDefault(e => e.cnpj == cnpj);          
        }

        //cadastra um novo pessoajuridica na tabela
        public bool CadastrarPessoaJuridica(PessoaJuridica pessoajuridica)
        {
            bool resp = true;
            try{
                //insert into pessoajuridica (nome, uf, ativo) values (?, ?, ?)
                _context.pessoajuridica.Add(pessoajuridica);
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

        //atualiza os dados do pessoajuridica cadastrado
        public bool AtualizaPessoaJuridica(PessoaJuridica pessoajuridica)
        {
            try{
                //update pessoajuridica set nome = ?, uf = ?, ativo = ? where id = ?
                _context.pessoajuridica.Update(pessoajuridica);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex){
                return false;
            }            
        }

        //excluir um pessoajuridica cadastrado
        public bool ExcluirPessoaJuridica(int cnpj)
        {
            return true;
        } 
    }    
}