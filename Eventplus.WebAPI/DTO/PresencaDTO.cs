using System.ComponentModel.DataAnnotations;

namespace Eventplus.WebAPI.DTO;

public class PresencaDTO
{
    [Required(ErrorMessage = "A situacao da presenca e obrigatorio")]
    public bool Situacao { get; set; }
    public Guid Idusuario { get; set; }

    public Guid Idevento { get; set; }
}
