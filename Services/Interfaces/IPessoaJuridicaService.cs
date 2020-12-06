using System.Collections.Generic;
using edital.Model;

namespace edital.Services.Interfaces
{
    public interface IPessoaJuridicaService
    {
        //retorna todos os estados cadastrados
        List<PessoaJuridica> GetPessoaJuridicas(); 
        //retorna o estado que eu passar o id
        PessoaJuridica GetPessoaJuridica(int cnpj);
        //cadastra um novo estado na tabela
        bool CadastrarPessoaJuridica(PessoaJuridica estado);
        //atualiza os dados do estado cadastrado
        bool AtualizaPessoaJuridica(PessoaJuridica estado);
        //excluir um estado cadastrado
        bool ExcluirPessoaJuridica(int cnpj);
    }    
}