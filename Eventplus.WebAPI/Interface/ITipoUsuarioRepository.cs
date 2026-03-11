using Eventplus.WebAPI.Models;

namespace Eventplus.WebAPI.Interface;


public interface ITipoUsuarioRepository
{
    void Cadastrar(TipoUsuario tipoUsuario);

    void Deletar(Guid Id);

    List<TipoUsuario> Listar();

    TipoUsuario BuscarPorId(Guid id);

    void Atualizar(Guid Id, TipoUsuario tipoUsuario);
}
