using Eventplus.WebAPI.Models;

namespace Eventplus.WebAPI.Interface;

public interface IUsuarioRepository
{
    void Cadastrar(Usuario usuario);

    Usuario BuscarPorIdUsuario(Guid IdUsuario);

    Usuario BuscarPorEmailSenha(string email, string senha);


}
