using Eventplus.WebAPI.Models;

namespace Eventplus.WebAPI.Interface;

public interface ITipoEventoRepository
{

    void Cadastrar(TipoEvento tipoEvento);

    void Deletar(Guid Id);

    List<TipoEvento> Listar();

    TipoEvento BuscarPorId(Guid id);

    void Atualizar(Guid Id, TipoEvento tipoEvento);
}
