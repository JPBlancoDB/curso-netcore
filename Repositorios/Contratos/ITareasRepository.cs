using System.Collections.Generic;
using Curso.Modelos;

namespace Curso.Repositorios.Contratos
{
    public interface ITareasRepository
    {
        IList<Tarea> ObtenerListaTareas();
        Tarea ObtenerTarea(int id);
        void AgregarTarea(Tarea tarea);

        void ActualizarTarea(int idTarea, Tarea tarea);
        void EliminarTarea(int id);
    } 
}