using Curso.Repositorios.Contratos;
using Microsoft.EntityFrameworkCore;

namespace Curso.Repositorios.Contexto
{
    public class TareaDbContextFactory : ITareaDbContextFactory
    {
        public TareaDbContext CrearTareaDbContext()
        {
            return new TareaDbContext();
        }
    }
}