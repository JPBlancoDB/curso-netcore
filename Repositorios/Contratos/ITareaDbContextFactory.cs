using Curso.Repositorios.Contexto;

namespace Curso.Repositorios.Contratos
{
    public interface ITareaDbContextFactory
    {
        TareaDbContext CrearTareaDbContext();
    }
}