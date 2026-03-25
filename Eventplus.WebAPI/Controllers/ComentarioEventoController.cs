using Azure;
using Azure.AI.ContentSafety;
using Eventplus.WebAPI.DTO;
using Eventplus.WebAPI.Interface;
using Eventplus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eventplus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComentarioEventoController : ControllerBase
{
    private readonly IComentarioEventRepository _comentarioEventRepository;

    private readonly ContentSafetyClient _contentSafetyClient;


    public ComentarioEventoController(ContentSafetyClient contentSafetyClient, IComentarioEventRepository comentarioEventRepository)
    {
        _contentSafetyClient = contentSafetyClient;
        _comentarioEventRepository = comentarioEventRepository;
    }


    [HttpPost]
    public async Task<IActionResult> Post(ComentarioEventoDTO comentarioEvento)
    {
        try
        {
            if (string.IsNullOrEmpty(comentarioEvento.Descricao))
            {
                return BadRequest("o texto a ser moderado nao pode estar vazio");
            }

            var request = new AnalyzeTextOptions(comentarioEvento.Descricao);

            Response<AnalyzeTextResult> response = await _contentSafetyClient.AnalyzeTextAsync(request);


            bool temConteudoImpropio = response.Value.CategoriesAnalysis.Any(c => c.Severity > 0);

            var novoComentario = new ComentarioEvento
            {
                Idevento = comentarioEvento.Idevento,
                Idusuario = comentarioEvento.Idusuario,
                Descricao = comentarioEvento.Descricao,
                Exibe = temConteudoImpropio,
                DataComentario = DateTime.Now

            };

            _comentarioEventRepository.Cadastrar(novoComentario);

            return StatusCode(201, novoComentario);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }
}
