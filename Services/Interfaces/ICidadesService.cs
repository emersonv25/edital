using System.Collections.Generic;
using edital.Model;

namespace edital.Services.Interfaces
{
    public interface ICidadesService
    {
        //retorna todos os Cidades cadastrados
        List<Cidade> GetCidades(); 
        //retorna o Cidade que eu passar o id
        Cidade GetCidade(int id);
        //cadastra um novo Cidade na tabela
        bool CadastrarCidade(Cidade Cidade);
        //atualiza os dados do Cidade cadastrado
        bool AtualizaCidade(Cidade Cidade);
        //excluir um Cidade cadastrado
        bool ExcluirCidade(int id);
    }    
}