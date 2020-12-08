using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using edital.Data;
using edital.Model;
using edital.Services;
using edital.Services.Interfaces;
/* 
## 2º Avaliação de Tópicos Integradores
### Centro Universitário Maurício de Nassau
### Análise e Desenvolvimento de Sistemas
### Alunos : 
* Emerson de Jesus Santos - 16017157
* Matheus Felipe Vieira Santiago - 16016955
*/
namespace edital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscricaoController : ControllerBase
    {
        private readonly IInscricaoService _inscricaoService;
        private readonly IPessoaJuridicaService _pessoaJuridicaService;
        private readonly ISegmentosService _segmentoService;
        private readonly ICidadesService _cidadeService;
        private readonly IEstadosService _estadoService;


        public InscricaoController(IInscricaoService inscricaoService,
        IPessoaJuridicaService pessoaJuridicaService = null, ISegmentosService segmentoService = null,
        ICidadesService cidadesService = null, IEstadosService estadoService = null)
        {
            _cidadeService = cidadesService;
            _inscricaoService = inscricaoService;
            _pessoaJuridicaService = pessoaJuridicaService;
            _segmentoService = segmentoService;
            _estadoService = estadoService;
        }

        // GET: api/Inscricao
        [HttpGet]
        public ActionResult<List<Inscricao>> GetInscricoes()
        {
            return _inscricaoService.GetInscricoes();
        }

        // GET: api/Inscricao/5

        [HttpGet("{cnpj}")]
        public ActionResult<Inscricao> GetInscricao(int cnpj)
        {
            return _inscricaoService.GetInscricao(cnpj);
        }

        // PUT: api/Inscricao/5

        [HttpPut("{cnpj}")]
        public ActionResult<Inscricao> PutInscricao(int cnpj, Inscricao inscricao)
        {
            if (cnpj != inscricao.pessoajuridica.cnpj)
            {
                return BadRequest();
            }

            bool resp = _inscricaoService.AtualizaInscricao(inscricao);
            if (!resp)
            {
                return NotFound();
            }

            inscricao = _inscricaoService.GetInscricao(cnpj);

            return inscricao;
        }

        // POST: api/Inscricao
        [HttpPost]
        public ActionResult<string> PostInscricao(Inscricao novoInscricao)
        {

            bool resp;
           // resp = _inscricaoService.CadastrarInscricao(novoInscricao);

            
            if (novoInscricao.pessoajuridica == null || novoInscricao.segmento == null)
            {
                resp = false;
            }
            else if (novoInscricao.pessoajuridica.cnpj > 0 && novoInscricao.segmento.id > 0)
            {

                PessoaJuridica pessoaJuridica = _pessoaJuridicaService.GetPessoaJuridica(novoInscricao.pessoajuridica.cnpj);

                Segmento segmento = _segmentoService.GetSegmento(novoInscricao.segmento.id);

                Inscricao inscricao = new Inscricao();
                if(pessoaJuridica != null) {
                    inscricao.pessoajuridica = pessoaJuridica;
                }
                else{
                    inscricao.pessoajuridica = novoInscricao.pessoajuridica;
                }
                
                if(segmento != null){
                    inscricao.segmento = segmento;
                } else{
                    inscricao.segmento = novoInscricao.segmento;
                }
                
                Cidade cidade = _cidadeService.GetCidade(inscricao.pessoajuridica.endereco.cidade.id);
                if(cidade != null){
                    inscricao.pessoajuridica.endereco.cidade = cidade;


                }else{
                    inscricao.pessoajuridica.endereco.cidade.id = 0;
                }

                Estado estado = _estadoService.GetEstado(inscricao.pessoajuridica.endereco.cidade.estado.id);
                if(estado != null){ 
                    inscricao.pessoajuridica.endereco.cidade.estado = estado;
                }else{
                    inscricao.pessoajuridica.endereco.cidade.estado.id = 0;
                }

                Cidade cidadeR = _cidadeService.GetCidade(inscricao.pessoajuridica.representante.endereco.cidade.id);
                if(cidadeR != null){
                    inscricao.pessoajuridica.representante.endereco.cidade = cidadeR;

                }else{
                    inscricao.pessoajuridica.representante.endereco.cidade.id =0;
                }
                
                Estado estadoR = _estadoService.GetEstado(inscricao.pessoajuridica.representante.endereco.cidade.estado.id);
                if(estadoR != null){ 
                    inscricao.pessoajuridica.representante.endereco.cidade.estado = estadoR;
                }else{
                    inscricao.pessoajuridica.representante.endereco.cidade.estado.id = 0;
                }


                inscricao.nomeiniciativa = novoInscricao.nomeiniciativa;
                inscricao.objetivos = novoInscricao.objetivos;
                inscricao.publicoalvo = novoInscricao.publicoalvo;
                inscricao.flgativo = inscricao.flgativo;
                


                resp = _inscricaoService.CadastrarInscricao(inscricao);
            }
            else
            {
                resp = _inscricaoService.CadastrarInscricao(novoInscricao);
            }
            


            if (resp)
            {
                return "Solicitação executada com sucesso!";
            }
            else
            {
                return "Falha ao executar a solicitação!";
            }
        }

        /*  // DELETE: api/Inscricao/5
         [HttpDelete("{id}")]
          public ActionResult<Inscricao> DeletePaciente(int id)
          {

          }*/


    }
}
