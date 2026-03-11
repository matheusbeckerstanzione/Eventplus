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
    public Guid IdTipoUsuario { get; set; }

    [StringLength(50)]
    public string Titulo { get; set; } = null!;
}
