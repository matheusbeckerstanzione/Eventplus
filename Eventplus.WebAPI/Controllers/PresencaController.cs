using Eventplus.WebAPI.DTO;
using Eventplus.WebAPI.Interface;
using Eventplus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eventplus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PresencaController : ControllerBase
{

    private IPresencaRepository _presencaRepository;

    public PresencaController(IPresencaRepository presencaRepository)
    {
        _presencaRepository = presencaRepository;
    }




    /// <summary>
    /// Endpoit da api que retorna uma lista de usuario
    /// </summary>
    /// <returns>Status code 200 e uma lista de proximo</returns>
    [HttpGet("ListarMinhas/{IdUsuario}")]
    public IActionResult ListarMinhas(Guid IdUsuario)
    {
        try
        {
            return Ok(_presencaRepository.ListarMinhas(IdUsuario));
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
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
            return Ok(_presencaRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);

        }
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
            return Ok(_presencaRepository.Listar());
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoind da api que faz a chamada para o metodo de cadastro do evento
    /// </summary>
    /// <param name="tipoEvento"> evento a ser cadastrado</param>
    /// <returns>status code 201 e o evento a ser cadastrado</returns>
    [HttpPost]

    public IActionResult Inscrever(PresencaDTO presenca)
    {
        try
        {

            var novaPresenca = new Presenca
            {
                Situacao = presenca.Situacao,
                Idusuario = presenca.Idusuario,
                Idevento = presenca.Idevento
            };

            _presencaRepository.Inscrever(novaPresenca);
            return StatusCode(201, novaPresenca);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoit da api que faz a chamada de um metodo de atualizar um evento 
    /// </summary>
    /// <param name="id">Id do evento a ser atualizado</param>
    /// <param name="tipoEvento"> evento com dados</param>
    /// <returns>Status code 204 e o evento atualizado</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, PresencaDTO presenca)
    {
        try
        {
            var PresencaAtualizado = new Presenca
            {
                Situacao = presenca.Situacao!
            };


            _presencaRepository.Atualizar(id);
            return StatusCode(204, presenca);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da api que faz a chamada para o metodo de deletar um evento
    /// </summary>
    /// <param name="id">id do evento excluido</param>
    /// <returns>Status code 204</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _presencaRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }


}
