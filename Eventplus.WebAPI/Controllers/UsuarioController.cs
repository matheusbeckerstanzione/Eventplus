using Eventplus.WebAPI.DTO;
using Eventplus.WebAPI.Interface;
using Eventplus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eventplus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }


    /// <summary>
    /// Endpoit da api que faz a chamada para o metodo que busca o usuario por id
    /// </summary>
    /// <param name="id">Id usuario a ser buscado</param>
    /// <returns>status code 200 e o usuario buscado</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_usuarioRepository.BuscarPorIdUsuario(id));
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoit da api que faz a chamada para o metodo de cadastrar
    /// </summary>
    /// <param name="usuario">Usuario a ser cadastrado</param>
    /// <returns>Status code 201 e o usuario cadastrado</returns>
    [HttpPost]
    public IActionResult Cadastrar(UsuarioDTO usuario)
    {
        try
        {
            var novoUsuario = new Usuario
            {
                Nome = usuario.Nome,
                Senha = usuario.Senha,
                Email = usuario.Email,
                IdtipoUsuario = usuario.IdTipoUsuario
            };
            _usuarioRepository.Cadastrar(novoUsuario);
            return StatusCode(201, novoUsuario);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }
}
