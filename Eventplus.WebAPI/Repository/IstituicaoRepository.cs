using Eventplus.WebAPI.BdContextEvent;
using Eventplus.WebAPI.Interface;
using Eventplus.WebAPI.Models;

namespace Eventplus.WebAPI.Repository;

public class IstituicaoRepository : IInstituicaoRepository
{

    private readonly EventContext _context;

    public IstituicaoRepository(EventContext context)
    {
        _context = context;
    }
    public void Atualizar(Guid Id, Instituicao instituicao)
    {
        var InstituicaoBuscado = _context.Instituicaos.Find(Id);

        if (instituicao != null)
        {
           InstituicaoBuscado.Cnpj = instituicao.Cnpj;
            InstituicaoBuscado.Endereco = instituicao.Endereco;
            InstituicaoBuscado.NomeFantasia = instituicao.NomeFantasia;

            //savechanges detecta mudanca na propiedade "titulo" automaticamente
            _context.SaveChanges();


        }
    }

    public Instituicao BuscarPorId(Guid Id)
    {
        return _context.Instituicaos.Find(Id)!;
    }

    public void Cadastrar(Instituicao instituicao)
    {
        _context.Instituicaos.Add(instituicao);
        _context.SaveChanges();
    }

    public void Detelar(Guid Id)
    {
        var InstituicaoBuscado = _context.Instituicaos.Find(Id);

        if (InstituicaoBuscado != null)
        {
            _context.Instituicaos.Remove(InstituicaoBuscado);
            _context.SaveChanges();
        }
    }

    public List<Instituicao> Listar()
    {
        return _context.Instituicaos.OrderBy(Instituicao => Instituicao.IdInstituicao).ToList();
    }
}
