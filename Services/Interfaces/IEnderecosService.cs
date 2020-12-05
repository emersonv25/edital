using System.Collections.Generic;
using edital.Model;

namespace edital.Services.Interfaces
{
    public interface IEnderecosService
    {
        //retorna todos os Enderecos cadastrados
        List<Endereco> GetEnderecos(); 
        //retorna o Endereco que eu passar o id
        Endereco GetEndereco(int id);
        //cadastra um novo Endereco na tabela
        bool CadastrarEndereco(Endereco endereco);
        //atualiza os dados do Endereco cadastrado
        bool AtualizaEndereco(Endereco endereco);
        //excluir um Endereco cadastrado
        bool ExcluirEndereco(int id);
    }    
}