using System.ComponentModel.DataAnnotations;

namespace Eventplus.WebAPI.DTO;

public class EventoDTO
{
    [Required(ErrorMessage = "O nome do evento e obrigatorio")]
    public string Nome { get; set; }


    [Required(ErrorMessage = "A data do evento e obrigatorio")]
    public DateTime DataEvento { get; set; }


    [Required(ErrorMessage = "A descricao do evento e obrigatorio")]
    public string Descricao { get; set; }


}
