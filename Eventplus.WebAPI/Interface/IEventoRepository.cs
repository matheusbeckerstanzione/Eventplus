using Eventplus.WebAPI.Models;

namespace Eventplus.WebAPI.Interface;

public interface IEventoRepository
{
    void Cadastrar(Evento Evento);

    void Deletar(Guid Id);

    List<Evento> List();

    List<Evento> ListarPorId(Guid IdUsuario);

    List<Evento> ListProximos();
    Evento BuscarPorId(Guid Id);

    void Atualizar(Guid id, Evento Evento);
}
