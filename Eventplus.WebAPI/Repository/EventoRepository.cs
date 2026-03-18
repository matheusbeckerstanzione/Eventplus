using Eventplus.WebAPI.DbContextEvent;
using Eventplus.WebAPI.Interface;
using Eventplus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Eventplus.WebAPI.Repository;

public class EventoRepository : IEventoRepository
{

    private readonly EventContext _context;
    
    public EventoRepository(EventContext context)
    {
        _context = context; 
    }


    /// <summary>
    /// Atualiza um evento usando o rastreamento automatico
    /// </summary>
    /// <param name="Id"> o id do evento a ser atualizada</param>
    /// <param name="tipoEvento"> novos dados do evento</param>
    public void Atualizar(Guid id, Evento Evento)
    {
        var EventoBuscado = _context.Eventos.Find(id);

        if (EventoBuscado != null)
        {
            EventoBuscado.DataEvento = Evento.DataEvento;
            EventoBuscado.Nome = Evento.Nome;
            EventoBuscado.Descricao = Evento.Descricao;

            //savechanges detecta mudanca na propiedade "titulo" automaticamente
            _context.SaveChanges();
        }
    }


    /// <summary>
    /// Busca um evento por id 
    /// </summary>
    /// <param name="id">id do  evento a ser buscador</param>
    /// <returns> um objeto do Evento com as informacoes do evento buscado</returns>
    public Evento BuscarPorId(Guid Id)
    {
        return _context.Eventos.Find(Id);
    }

    /// <summary>
    /// Cadastra um novo evento
    /// </summary>
    /// <param name="tipoEvento">O  evento a ser cadastrado</param>
    public void Cadastrar(Evento Evento)
    {
       _context.Eventos.Add(Evento);
        _context.SaveChanges();
    }

    /// <summary>
    /// Deleta um evento 
    /// </summary>
    /// <param name="Id">Ele recebe um evento a ser deletado</param>
    public void Deletar(Guid Id)
    {
        var EventoBuscado = _context.Eventos.Find(Id);

        if (EventoBuscado != null)
        {
            _context.Eventos.Remove(EventoBuscado);
            _context.SaveChanges();
        }
    }

    public List<Evento> List()
    {
        return _context.Eventos.OrderBy(Eventos => Eventos.Idevento).ToList();
    }


    /// <summary>
    /// Metodo que lista eventos filtrando pelas presencas de um usuario
    /// </summary>
    /// <param name="IdUsuario">id do usuario para filtragem</param>
    /// <returns>lista de eventos filtrados usuario</returns>
    public List<Evento> ListarPorId(Guid IdUsuario)
    {
        return _context.Eventos
            .Include(e => e.IdtipoEventoNavigation)
            .Include(e => e.IdtipoEventoNavigation)
            .Where(e => e.Presencas.Any(p => p.Idusuario == IdUsuario && p.Situacao == true)).ToList();
    }

    /// <summary>
    /// Metodo que retorna proximos eventos que vao acontecer
    /// </summary>
  
    /// <returns>Lista de proximos eventos</returns>
    public List<Evento> ListProximos()
    {
       return _context.Eventos
            .Include(e => e.IdtipoEventoNavigation)
            .Include(e => e.IdinstituicaoNavigation)
            .Where(e => e.DataEvento >= DateTime.Now)
            .OrderBy(e => e.DataEvento)
            .ToList();
    }
}
