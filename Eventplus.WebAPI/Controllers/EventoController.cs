using Eventplus.WebAPI.DTO;
using Eventplus.WebAPI.Interface;
using Eventplus.WebAPI.Models;
using Eventplus.WebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eventplus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventoController : ControllerBase
{

    private IEventoRepository _eventoRepository;

    public EventoController(IEventoRepository eventoRepository) 
    { 
        _eventoRepository = eventoRepository;
    }


    /// <summary>
    /// Endpoit da api que faz a chamada de listar eventos filtrado por usuario
    /// </summary>
    /// <param name="idUsuario">id do usuario para filtragem</param>
    /// <returns>lista de eventos filtrados por usuarios</returns>
    [HttpGet("Usuario/{idUsuario}")]
    public IActionResult ListarPorId(Guid idUsuario)
    {
        try
        {
            return Ok(_eventoRepository.ListarPorId(idUsuario));
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Endpoit da api que faz a chamda para o metodo de listar os proximos eventos
    /// </summary>
    /// <returns>Status code 200 e uma lista de proximo</returns>
    [HttpGet("ListarProximos")]
    public IActionResult BuscarProximos()
    {
        try
        {
            return Ok(_eventoRepository.ListProximos());
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
            return Ok(_eventoRepository.BuscarPorId(id));
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
    public IActionResult List()
    {
        try
        {
            return Ok(_eventoRepository.List());
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

    public IActionResult Cadastrar(EventoDTO evento)
    {
        try
        {

            var novoEvento = new Evento
            {
                Nome = evento.Nome!,
                DataEvento = evento.DataEvento!,
                Descricao = evento.Descricao!,
            };

            _eventoRepository.Cadastrar(novoEvento);
            return StatusCode(201, novoEvento);
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
    public IActionResult Atualizar(Guid id, EventoDTO evento)
    {
        try
        {
            var EventoAtualizado = new Evento
            {
                Nome = evento.Nome!
            };


            _eventoRepository.Atualizar(id, EventoAtualizado);
            return StatusCode(204, evento);
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
            _eventoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }
}
