using System;
using System.Collections.Generic;
using Eventplus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Eventplus.WebAPI.DbContextEvent;

public partial class EventContext : DbContext
{
    public EventContext()
    {
    }

    public EventContext(DbContextOptions<EventContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ComentarioEvento> ComentarioEventos { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Instituicao> Instituicaos { get; set; }

    public virtual DbSet<Presenca> Presencas { get; set; }

    public virtual DbSet<TipoEvento> TipoEventos { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EventPlus;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ComentarioEvento>(entity =>
        {
            entity.HasKey(e => e.IdcomentarioEvento).HasName("PK__Comentar__968EA69E7B83FAB9");

            entity.Property(e => e.IdcomentarioEvento).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdeventoNavigation).WithMany(p => p.ComentarioEventos).HasConstraintName("FK__Comentari__IDEve__75A278F5");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.ComentarioEventos).HasConstraintName("FK__Comentari__IDUsu__76969D2E");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.Idevento).HasName("PK__Evento__E63053020740BD59");

            entity.Property(e => e.Idevento).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdinstituicaoNavigation).WithMany(p => p.Eventos).HasConstraintName("FK__Evento__IDInstit__6D0D32F4");

            entity.HasOne(d => d.IdtipoEventoNavigation).WithMany(p => p.Eventos).HasConstraintName("FK__Evento__IDTipoEv__6C190EBB");
        });

        modelBuilder.Entity<Instituicao>(entity =>
        {
            entity.HasKey(e => e.Idinstituicao).HasName("PK__Institui__4E7E9AF3E060777A");

            entity.Property(e => e.Idinstituicao).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Presenca>(entity =>
        {
            entity.HasKey(e => e.Idpresenca).HasName("PK__Presenca__FF9F967F208E5B7D");

            entity.Property(e => e.Idpresenca).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdeventoNavigation).WithMany(p => p.Presencas).HasConstraintName("FK__Presenca__IDEven__70DDC3D8");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Presencas).HasConstraintName("FK__Presenca__IDUsua__71D1E811");
        });

        modelBuilder.Entity<TipoEvento>(entity =>
        {
            entity.HasKey(e => e.IdtipoEvento).HasName("PK__TipoEven__EF36F33EE9E80A96");

            entity.Property(e => e.IdtipoEvento).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdtipoUsuario).HasName("PK__TipoUsua__5328975470FC8D3B");

            entity.Property(e => e.IdtipoUsuario).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PK__Usuario__52311169AD2D9602");

            entity.Property(e => e.Idusuario).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdtipoUsuarioNavigation).WithMany(p => p.Usuarios).HasConstraintName("FK__Usuario__IDTipoU__68487DD7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
