using System.Collections.Generic;
using edital.Model;

namespace edital.Services.Interfaces
{
    public interface IInscricaoService
    {
        //retorna todos os inscricao cadastrados
        List<Inscricao> GetInscricoes(); 
        //retorna o inscricao que eu passar o id
        Inscricao GetInscricao(int id);
        //cadastra um novo inscricao na tabela
        bool CadastrarInscricao(Inscricao inscricao);
        //atualiza os dados do inscricao cadastrado
        bool AtualizaInscricao(Inscricao inscricao);
        //excluir um inscricao cadastrado
        bool ExcluirInscricao(int cnpj);
    }    
}