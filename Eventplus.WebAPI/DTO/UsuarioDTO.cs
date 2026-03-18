using System.ComponentModel.DataAnnotations;

namespace Eventplus.WebAPI.DTO;

public class UsuarioDTO
{
    [Required(ErrorMessage = "O nome do usuario e obrigatorio")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "O email do usuario e obrigatorio")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "A senha do usuario e obrigatorio")]
    public string? Senha { get; set;}

    public Guid IdTipoUsuario { get; set; }

}
