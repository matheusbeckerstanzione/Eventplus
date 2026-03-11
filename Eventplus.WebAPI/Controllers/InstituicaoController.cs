using Eventplus.WebAPI.DTO;
using Eventplus.WebAPI.Interface;
using Eventplus.WebAPI.Models;
using Eventplus.WebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eventplus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstituicaoController : ControllerBase
{

    private IInstituicaoRepository _instituicaoRepository;

    public InstituicaoController(IInstituicaoRepository instituicaoRepository)
    {
        _instituicaoRepository = instituicaoRepository;
    }


    /// <summary>
    /// Endpoid da api que faz a chamada para o metodo de listar 
    /// </summary>
    /// <returns>ele retorna um statos code 200 e a lista da instituicao </returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_instituicaoRepository.Listar());
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da api que faz a chamada para o metodo de buscar por id
    /// </summary>
    /// <param name="id">id da instituicao</param>
    /// <returns>status code 200 e a instituicao</returns>

    [HttpGet("{id}")]

    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_instituicaoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);

        }
    }


    /// <summary>
    /// Endpoind da api que faz a chamada para o metodo de cadastro tipo de evento
    /// </summary>
    /// <param name="tipoEvento"> tipo de evento a ser cadastrado</param>
    /// <returns>status code 201 e o tipo de evento a ser cadastrado</returns>
    [HttpPost]

    public IActionResult Cadastrar(InstituicaoDTO instituicao)
    {
        try
        {

            var novaInstituicao = new Instituicao
            {
                NomeFantasia = instituicao.NomeFantasia!
            };

            _instituicaoRepository.Cadastrar(novaInstituicao);
            return StatusCode(201, novaInstituicao);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }


    /// <summary>
    /// Endpoit da api que faz a chamada de um metodo de atualizar um tipo de evento 
    /// </summary>
    /// <param name="id">Id do tipo evento a ser atualizado</param>
    /// <param name="tipoEvento">tipo de evento com dados</param>
    /// <returns>Status code 204 e o tipo de evento atualizado</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, InstituicaoDTO instituicao)
    {
        try
        {
            var InstituicaoAtualizado = new Instituicao
            {
                NomeFantasia = instituicao.NomeFantasia!
            };


            _instituicaoRepository.Atualizar(id, InstituicaoAtualizado);
            return StatusCode(204, instituicao);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }


    /// <summary>
    /// Endpoint da api que faz a chamada para o metodo de deletar um tipo de evento
    /// </summary>
    /// <param name="id">id do tipo do evento excluido</param>
    /// <returns>Status code 204</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _instituicaoRepository.Detelar(id);
            return NoContent();
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

}
