using System.Collections.Generic;
using edital.Model;

namespace edital.Services.Interfaces
{
    public interface IEditalService
    {
        //retorna todos os edital cadastrados
        List<Edital> GetEditais(); 
        //retorna o edital que eu passar o id
        Edital GetEdital(int id);
        //cadastra um novo edital na tabela
        bool CadastrarEdital(Edital edital);
        //atualiza os dados do edital cadastrado
        bool AtualizaEdital(Edital edital);
        //excluir um edital cadastrado
        bool ExcluirEdital(int id);
    }    
}