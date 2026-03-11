using Eventplus.WebAPI.Models;

namespace Eventplus.WebAPI.Interface;

public interface IInstituicaoRepository
{
    void Cadastrar(Instituicao instituicao);

    void Detelar(Guid Id);

    List<Instituicao> Listar();

    Instituicao BuscarPorId(Guid Id);

    void Atualizar(Guid Id, Instituicao instituicao);
}
