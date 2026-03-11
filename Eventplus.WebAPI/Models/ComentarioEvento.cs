using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Eventplus.WebAPI.Models;

[Table("ComentarioEvento")]
public partial class ComentarioEvento
{
    [Key]
    public Guid IdComentarioEvento { get; set; }

    [StringLength(500)]
    public string? Descricao { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DataComentario { get; set; }

    public bool Exibe { get; set; }

    public Guid? IdEvento { get; set; }

    public Guid? IdUsuario { get; set; }

    [ForeignKey("IdEvento")]
    [InverseProperty("ComentarioEventos")]
    public virtual Evento? IdEventoNavigation { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("ComentarioEventos")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
