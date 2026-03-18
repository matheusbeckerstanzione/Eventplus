using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Eventplus.WebAPI.Models;

[Table("Instituicao")]
[Index("Cnpj", Name = "UQ__Institui__AA57D6B4D36FAC23", IsUnique = true)]
public partial class Instituicao
{
    [Key]
    [Column("IDInstituicao")]
    public Guid Idinstituicao { get; set; }

    [StringLength(100)]
    public string? NomeFantasia { get; set; }

    [StringLength(100)]
    public string? Endereco { get; set; }

    [Column("CNPJ")]
    [StringLength(14)]
    public string Cnpj { get; set; } = null!;

    [InverseProperty("IdinstituicaoNavigation")]
    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}
