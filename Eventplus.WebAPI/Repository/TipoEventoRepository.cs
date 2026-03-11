using Eventplus.WebAPI.BdContextEvent;
using Eventplus.WebAPI.Interface;
using Eventplus.WebAPI.Models;

namespace Eventplus.WebAPI.Repository;

public class TipoEventoRepository : ITipoEventoRepository
{

    private readonly EventContext _context;

    //meu construtor para injecao de dependencias
    public TipoEventoRepository(EventContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Atualiza um tipo de evento usando o rastreamento automatico
    /// </summary>
    /// <param name="Id"> o id do tipo evento a ser atualizada</param>
    /// <param name="tipoEvento"> novos dados do tipo evento</param>
    public void Atualizar(Guid Id, TipoEvento tipoEvento)
    {
        var tipoEventoBuscado = _context.TipoEventos.Find(Id);

        if(tipoEvento != null)
        {
            tipoEventoBuscado.Titulo = tipoEvento.Titulo;

            //savechanges detecta mudanca na propiedade "titulo" automaticamente
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca um tipo de evento por id 
    /// </summary>
    /// <param name="id">id do tipo evento a ser buscador</param>
    /// <returns> um objeto do tipoEvento com as informacoes do tipo evento buscado</returns>
    public TipoEvento BuscarPorId(Guid id)
    {
        return _context.TipoEventos.Find(id)!;
    }


    /// <summary>
    /// Cadastra um novo tipo de evento
    /// </summary>
    /// <param name="tipoEvento">O tipo de evento a ser cadastrado</param>
    public void Cadastrar(TipoEvento tipoEvento)
    {
        _context.TipoEventos.Add(tipoEvento);
        _context.SaveChanges();
    }

    /// <summary>
    /// Deleta um tipo de evento 
    /// </summary>
    /// <param name="Id">Ele recebe um tipo de evento a ser deletado</param>
    public void Deletar(Guid Id)
    {
        var tipoEventoBuscado = _context.TipoEventos.Find(Id);

        if(tipoEventoBuscado != null)
        {
            _context.TipoEventos.Remove(tipoEventoBuscado);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca a lista de tipo eventos
    /// </summary>
    
    /// <returns>Uma lista de tipo evento</returns>
    public List<TipoEvento> Listar()
    {
        return _context.TipoEventos.OrderBy(tipoEvento => tipoEvento.Titulo).ToList();
    }
}
