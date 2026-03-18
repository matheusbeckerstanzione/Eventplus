using System.ComponentModel.DataAnnotations;

namespace Eventplus.WebAPI.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O Email eh obrigatorio para se logar!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A Senha eh obrigatoria para se logar!")]
        public string? Senha { get; set; }
    }
}
