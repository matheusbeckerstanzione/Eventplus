using Eventplus.WebAPI.Models;

namespace Eventplus.WebAPI.Interface;

public interface IPresencaRepository
{
    void Inscrever(Presenca presenca);

    void Deletar(Guid Id);

    List<Presenca> Listar();

    Presenca BuscarPorId(Guid Id);

    void Atualizar(Guid Id);

    List<Presenca> ListarMinhas(Guid IdUsuario);
}
