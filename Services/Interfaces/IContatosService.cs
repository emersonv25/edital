using System.Collections.Generic;
using edital.Model;

namespace edital.Services.Interfaces
{
    public interface IContatosService
    {
        //retorna todos os Contatos cadastrados
        List<Contato> GetContatos(); 
        //retorna o Contato que eu passar o id
        Contato GetContato(int id);
        //cadastra um novo Contato na tabela
        bool CadastrarContato(Contato Contato);
        //atualiza os dados do Contato cadastrado
        bool AtualizaContato(Contato Contato);
        //excluir um Contato cadastrado
        bool ExcluirContato(int id);
    }    
}