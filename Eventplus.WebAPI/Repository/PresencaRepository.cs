using Eventplus.WebAPI.DbContextEvent;
using Eventplus.WebAPI.Interface;
using Eventplus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Eventplus.WebAPI.Repository;

public class PresencaRepository : IPresencaRepository
{
    private readonly EventContext _context;

    public PresencaRepository(EventContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Metodo que alterna a situacao da presenca
    /// </summary>
    /// <param name="Id">id da presenca a ser alterado</param>
    public void Atualizar(Guid Id)
    {
        var presencaBuscada = _context.Presencas.Find(Id);

        if(presencaBuscada != null)
        {
            presencaBuscada.Situacao = !presencaBuscada.Situacao;

            _context.SaveChanges(); 
        }
    }

    public Presenca BuscarPorId(Guid Id)
    {
        return _context.Presencas.Include(p => p.IdeventoNavigation)
            .ThenInclude(e => e!.IdinstituicaoNavigation)
            .FirstOrDefault(p => p.Idpresenca == Id);
    }

    public void Deletar(Guid Id)
    {
        var presencaBuscado = _context.Presencas.Find(Id);

        if (presencaBuscado != null)
        {
            _context.Presencas.Remove(presencaBuscado);
            _context.SaveChanges();
        }
    }

    public void Inscrever(Presenca presenca)
    {
        _context.Presencas.Add(presenca);
        _context.SaveChanges();
    }

    public List<Presenca> Listar()
    {
        return _context.Presencas.OrderBy(Presenca => Presenca.Situacao).ToList();
    }

    /// <summary>
    /// metodo que lista as presencas de um usuario especifico
    /// </summary>
    /// <param name="IdUsuario">id do usuario para filtragem</param>
    /// <returns>lista de presencas de um usuario</returns>
    public List<Presenca> ListarMinhas(Guid IdUsuario)
    {
        return _context.Presencas.Include(p => p.IdeventoNavigation)
            .ThenInclude(e => e!.IdinstituicaoNavigation)
            .Where(p => p.Idusuario == IdUsuario).ToList();
    }
}
