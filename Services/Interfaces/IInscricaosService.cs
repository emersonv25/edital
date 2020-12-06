using System.Collections.Generic;
using edital.Model;

namespace edital.Services.Interfaces
{
    public interface IInscricaosService
    {
        //retorna todos os inscricaos cadastrados
        List<Inscricao> GetInscricaos(); 
        //retorna o inscricao que eu passar o id
        Inscricao GetInscricao(int cnpj);
        //cadastra um novo inscricao na tabela
        bool CadastrarInscricao(Inscricao inscricao);
        //atualiza os dados do inscricao cadastrado
        bool AtualizaInscricao(Inscricao inscricao);
        //excluir um inscricao cadastrado
        bool ExcluirInscricao(int cnpj);
    }    
}