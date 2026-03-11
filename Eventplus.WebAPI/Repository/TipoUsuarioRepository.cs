using Eventplus.WebAPI.BdContextEvent;
using Eventplus.WebAPI.Interface;
using Eventplus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

public class TipoUsuarioRepository : ITipoUsuarioRepository

{

    private readonly EventContext _context;

    public TipoUsuarioRepository(EventContext context)
    {
        _context = context;
    }


    // <summary>
    /// Atualiza um tipo de Usuario usando o rastreamento automatico
    /// </summary>
    /// <param name="Id"> o id do tipoUsuario a ser atualizada</param>
    /// <param name="tipoEvento"> novos dados do tipo evento</param>

    public void Atualizar(Guid Id, TipoUsuario tipoUsuario)
    {
        var tipoUsuarioBuscado = _context.TipoUsuarios.Find(Id);

        if (tipoUsuario != null)
        {
            tipoUsuarioBuscado.IdTipoUsuario = tipoUsuario.IdTipoUsuario;

            //savechanges detecta mudanca na propiedade "titulo" automaticamente
            _context.SaveChanges();
        }

    }

    public TipoUsuario BuscarPorId(Guid id)
    {
        return _context.TipoUsuarios.Find(id)!;
        
    }

    public void Cadastrar(TipoUsuario tipoUsuario)
    {
        _context.TipoUsuarios.Add(tipoUsuario);
        _context.SaveChanges();
    }

    public void Deletar(Guid Id)
    {
        var tipoUsuarioBuscado = _context.TipoUsuarios.Find(Id);

        if (tipoUsuarioBuscado != null)
        {
            _context.TipoUsuarios.Remove(tipoUsuarioBuscado);
            _context.SaveChanges();
            
        }
    }

    public List<TipoUsuario> Listar()
    {
        return _context.TipoUsuarios.OrderBy(tipoUsuario => tipoUsuario.IdTipoUsuario).ToList();
    }
}
