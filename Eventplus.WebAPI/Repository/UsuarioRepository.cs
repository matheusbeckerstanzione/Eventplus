using Eventplus.WebAPI.DbContextEvent;
using Eventplus.WebAPI.Interface;
using Eventplus.WebAPI.Models;
using Eventplus.WebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace Eventplus.WebAPI.Repository;

public class UsuarioRepository : IUsuarioRepository
{

    private readonly EventContext _context;

        public UsuarioRepository(EventContext context)
    {
        _context = context; 
    }

    /// <summary>
    /// ele busca o usuario pelo email e valida
    /// </summary>
    /// <param name="email">Email do usuario</param>
    /// <param name="senha">Senha do usuario</param>
    /// <returns>Usuario buscado e validado</returns>
    public Usuario BuscarPorEmailSenha(string email, string senha)
    {
        var usuarioBuscado = _context.Usuarios.Include(usuario => usuario.IdtipoUsuarioNavigation).FirstOrDefault(usuario => usuario.Email == email);

        if (usuarioBuscado == null)
        { 
           bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha);

            if (confere)
            {
                return usuarioBuscado;
            }
        }

        return null;
    }

    /// <summary>
    /// Busca um usuario pelo id, incluindo os dados do seu tipo usuario
    /// </summary>
    /// <param name="IdUsuario">id do usuario a ser buscado</param>
    /// <returns>Usuario buscado</returns>
    public Usuario BuscarPorIdUsuario(Guid IdUsuario)
    {
        return _context.Usuarios.Include(usuario => usuario.IdtipoUsuarioNavigation)
            .FirstOrDefault(usuario => usuario.Idusuario== IdUsuario);
    }

    /// <summary>
    /// Cadastrar um novo usuario com a senha criptografada
    /// </summary>
    /// <param name="usuario">Usuario ser cadastrado</param>
    public void Cadastrar(Usuario usuario)
    {
       usuario.Senha = Criptografia.GerarHash(usuario.Senha);

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }
}
