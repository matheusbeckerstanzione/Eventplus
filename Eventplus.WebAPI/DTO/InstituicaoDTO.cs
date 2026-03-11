using System.ComponentModel.DataAnnotations;

namespace Eventplus.WebAPI.DTO
{
    public class InstituicaoDTO
    {

        [Required(ErrorMessage = "O titulo do tipo de evento e obrigatorio")]
        public string? NomeFantasia { get; set; }
    }
}
