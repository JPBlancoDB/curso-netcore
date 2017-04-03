using System;
using System.Collections.Generic;
using System.Linq;
using Curso.Modelos;
using Curso.Repositorios.Contratos;

namespace Curso.Repositorios
{
    public class TareasRepository : ITareasRepository
    {
        private readonly ITareaDbContextFactory _contexto;

        public TareasRepository(ITareaDbContextFactory contexto)
        {
            _contexto = contexto;
        }
        public IList<Tarea> ObtenerListaTareas()
        {
            using (var db = _contexto.CrearTareaDbContext())
            {
                return db.Tareas.ToList();
            }
        }

        public Tarea ObtenerTarea(int id)
        {
            using(var db = _contexto.CrearTareaDbContext())
            {
                return db.Tareas.FirstOrDefault(where=>where.Id == id);
            }
        }

        public void AgregarTarea(Tarea tarea)
        {
            using(var db = _contexto.CrearTareaDbContext())
            {
                db.Add(tarea);

                db.SaveChanges();
            }
        }

        public void ActualizarTarea(int idTarea, Tarea tarea)
        {
            using(var db = _contexto.CrearTareaDbContext())
            {
                var tareaData = db.Tareas.Find(idTarea);

                tareaData.Descripcion = tarea.Descripcion;
                tareaData.Pendiente = tarea.Pendiente;

                db.SaveChanges();
            }
        }

        public void EliminarTarea(int idTarea)
        {
            using (var db = _contexto.CrearTareaDbContext())
            {
                db.Tareas.Remove(db.Tareas.Find(idTarea));

                db.SaveChanges();
            }
        }
    }
}