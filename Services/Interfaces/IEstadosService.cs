using System.Collections.Generic;
using edital.Model;

namespace edital.Services.Interfaces
{
    public interface IEstadosService
    {
        //retorna todos os estados cadastrados
        List<Estado> GetEstados(); 
        //retorna o estado que eu passar o id
        Estado GetEstado(int id);
        //cadastra um novo estado na tabela
        bool CadastrarEstado(Estado estado);
        //atualiza os dados do estado cadastrado
        bool AtualizaEstado(Estado estado);
        //excluir um estado cadastrado
        bool ExcluirEstado(int id);
    }    
}