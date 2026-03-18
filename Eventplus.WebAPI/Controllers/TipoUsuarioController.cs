using Eventplus.WebAPI.DTO;
using Eventplus.WebAPI.Interface;
using Eventplus.WebAPI.Models;
using Eventplus.WebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eventplus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoUsuarioController : ControllerBase
{
    private ITipoUsuarioRepository _tipoUsuarioRepository;

    public TipoUsuarioController(ITipoUsuarioRepository tipoUsuarioRepository)
    {
        _tipoUsuarioRepository = tipoUsuarioRepository;
    }

    /// <summary>
    /// Endpoid da api que faz a chamada para o metodo de listar 
    /// </summary>
    /// <returns>eleretorna um statos code 200 e alista de tipo de eventos</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }


    /// <summary>
    /// Endpoint da api que faz a chamada para o metodo de buscar por id
    /// </summary>
    /// <param name="id">id do tipo de evento buscado</param>
    /// <returns>status code 200 e o tipo de Usuario buscado</returns>
    [HttpGet("{id}")]

    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_tipoUsuarioRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);

        }
    }


    /// <summary>
    /// Endpoind da api que faz a chamada para o metodo de cadastro tipo de Usuario
    /// </summary>
    /// <param name="tipoEvento"> tipo de Usuario a ser cadastrado</param>
    /// <returns>status code 201 e o tipo de Usuario a ser cadastrado</returns>
    [HttpPost]

    public IActionResult Cadastrar(TipoUsuarioDTO tipoUsuario)
    {
        try
        {

            var novoTipoUsuario = new TipoUsuario
            {
                Titulo = tipoUsuario.Titulo!
            };

            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);
            return StatusCode(201, novoTipoUsuario);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoit da api que faz a chamada de um metodo de atualizar um tipo de um Usuario
    /// </summary>
    /// <param name="id">Id do tipo Usuario a ser atualizado</param>
    /// <param name="tipoEvento">tipo de Usuario com dados</param>
    /// <returns>Status code 204 e o tipo de Usuario atualizado</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, TipoUsuarioDTO tipoUsuario)
    {
        try
        {
            var TipoUsuarioAtualizado = new TipoUsuario
            {
                Titulo = tipoUsuario.Titulo!
            };


            _tipoUsuarioRepository.Atualizar(id, TipoUsuarioAtualizado);
            return StatusCode(204, tipoUsuario);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }




}
