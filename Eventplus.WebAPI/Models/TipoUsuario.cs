using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Eventplus.WebAPI.Models;

[Table("TipoUsuario")]
public partial class TipoUsuario
{
    [Key]
    [Column("IDTipoUsuario")]
    public Guid IdtipoUsuario { get; set; }

    [StringLength(50)]
    public string Titulo { get; set; } = null!;

    [InverseProperty("IdtipoUsuarioNavigation")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
