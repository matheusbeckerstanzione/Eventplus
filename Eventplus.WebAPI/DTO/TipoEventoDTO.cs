using System.ComponentModel.DataAnnotations;

namespace Eventplus.WebAPI.DTO;

public class TipoEventoDTO
{
    [Required(ErrorMessage = "O titulo do tipo de evento e obrigatorio")]
    public string? Titulo { get; set; }
}
