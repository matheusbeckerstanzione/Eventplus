using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Eventplus.WebAPI.Models;

[Table("Evento")]
public partial class Evento
{
    [Key]
    [Column("IDEvento")]
    public Guid Idevento { get; set; }

    [StringLength(100)]
    public string Nome { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime DataEvento { get; set; }

    [Column(TypeName = "text")]
    public string Descricao { get; set; } = null!;

    [Column("IDTipoEvento")]
    public Guid? IdtipoEvento { get; set; }

    [Column("IDInstituicao")]
    public Guid? Idinstituicao { get; set; }

    [InverseProperty("IdeventoNavigation")]
    public virtual ICollection<ComentarioEvento> ComentarioEventos { get; set; } = new List<ComentarioEvento>();

    [ForeignKey("Idinstituicao")]
    [InverseProperty("Eventos")]
    public virtual Instituicao? IdinstituicaoNavigation { get; set; }

    [ForeignKey("IdtipoEvento")]
    [InverseProperty("Eventos")]
    public virtual TipoEvento? IdtipoEventoNavigation { get; set; }

    [InverseProperty("IdeventoNavigation")]
    public virtual ICollection<Presenca> Presencas { get; set; } = new List<Presenca>();
}
