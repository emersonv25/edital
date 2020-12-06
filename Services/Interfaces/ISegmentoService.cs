using System.Collections.Generic;
using edital.Model;

namespace edital.Services.Interfaces
{
    public interface ISegmentosService
    {
        //retorna todos os segmentos cadastrados
        List<Segmento> GetSegmentos(); 
        //retorna o segmento que eu passar o id
        Segmento GetSegmento(int id);
        //cadastra um novo segmento na tabela
        bool CadastrarSegmento(Segmento segmento);
        //atualiza os dados do segmento cadastrado
        bool AtualizaSegmento(Segmento segmento);
        //excluir um segmento cadastrado
        bool ExcluirSegmento(int id);
    }    
}