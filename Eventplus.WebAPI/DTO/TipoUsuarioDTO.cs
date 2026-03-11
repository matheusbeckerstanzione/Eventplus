using System.ComponentModel.DataAnnotations;

namespace Eventplus.WebAPI.DTO;

public class TipoUsuarioDTO
{

    [Required(ErrorMessage = "O Tipo do Usuario obrigatorio")]
    public string? Titulo { get; set; }



}
