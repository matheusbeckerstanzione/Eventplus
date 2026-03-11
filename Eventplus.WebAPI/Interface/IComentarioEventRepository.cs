using Eventplus.WebAPI.Models;

namespace Eventplus.WebAPI.Interface;

public interface IComentarioEventRepository
{
    void Cadastrar(ComentarioEvento comentarioEvento);

    void Deletar(Guid IdComentarioEvento);
    List<ComentarioEvento> List(Guid IdEvento);
    ComentarioEvento BuscarPorIdUsuario(Guid IdUsuario, Guid IdEventos);

    List<ComentarioEvento> ListarSomenteExibe(Guid IdEvento);
}
