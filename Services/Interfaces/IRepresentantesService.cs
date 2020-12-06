using System.Collections.Generic;
using edital.Model;

namespace edital.Services.Interfaces
{
    public interface IRepresentantesService
    {
        //retorna todos os representantes cadastrados
        List<Representante> GetRepresentantes(); 
        //retorna o representante que eu passar o id
        Representante GetRepresentante(int id);
        //cadastra um novo representante na tabela
        bool CadastrarRepresentante(Representante representante);
        //atualiza os dados do representante cadastrado
        bool AtualizaRepresentante(Representante representante);
        //excluir um representante cadastrado
        bool ExcluirRepresentante(int id);
    }    
}