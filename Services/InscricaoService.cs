using System.Linq;
using System.Collections.Generic;
using edital.Data;
using edital.Model;
using edital.Services.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;

namespace edital.Services
{
    public class InscricaoService : IInscricaoService
    {
        private readonly ApplicationDbContext _context;
        
        public InscricaoService(ApplicationDbContext context)
        {
            _context = context;
        }

        //retorna todos os inscricao cadastrados
        public List<Inscricao> GetInscricoes()
        {
            List<Inscricao> inscricao = new List<Inscricao>();
            //select * from inscricao
            inscricao =  _context.inscricao         
            .Include(p => p.pessoajuridica)
            .Include(p => p.pessoajuridica.contato)
            .Include(p => p.pessoajuridica.endereco)
            .Include(p => p.pessoajuridica.endereco.cidade)
            .Include(p => p.pessoajuridica.endereco.cidade.estado)
            .Include(p => p.pessoajuridica.representante)
            .Include(p => p.pessoajuridica.representante.contato)
            .Include(p => p.pessoajuridica.representante.endereco)
            .Include(p => p.pessoajuridica.representante.endereco.cidade)
            .Include(p => p.pessoajuridica.representante.endereco.cidade.estado)
            .Include(s => s.segmento)
            .Include(s => s.segmento.edital)
            .ToList();

            return inscricao;
        }

        //retorna o inscricao que eu passar o cnpj
        public Inscricao GetInscricao(int cnpj)
        {

            //select * from inscricao where id = ?
            Inscricao inscricao = new Inscricao();
            inscricao = _context.inscricao
            .Include(p => p.pessoajuridica)
            .Include(p => p.pessoajuridica.contato)
            .Include(p => p.pessoajuridica.endereco)
            .Include(p => p.pessoajuridica.endereco.cidade)
            .Include(p => p.pessoajuridica.endereco.cidade.estado)
            .Include(p => p.pessoajuridica.representante)
            .Include(p => p.pessoajuridica.representante.contato)
            .Include(p => p.pessoajuridica.representante.endereco)
            .Include(p => p.pessoajuridica.representante.endereco.cidade)
            .Include(p => p.pessoajuridica.representante.endereco.cidade.estado)
            .Include(s => s.segmento)
            .Include(s => s.segmento.edital)
            .SingleOrDefault(e => e.pessoajuridica.cnpj == cnpj);

            //return _context.inscricao.SingleOrDefault(e => e.pessoajuridica.cnpj == cnpj);  
            return inscricao;        
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
        public bool ExcluirInscricao(int id)
        {
            return true;
        } 
    }    
}