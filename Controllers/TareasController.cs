using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Modelos;
using Curso.Repositorios.Contratos;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Controllers
{
    [Route("api/[controller]")]
    public class TareasController : Controller
    {
        private readonly ITareasRepository _tareasRepository;
        
        public TareasController(ITareasRepository tareasRepository)
        {
            _tareasRepository = tareasRepository;
        }

        [HttpGet]
        public IEnumerable<Tarea> Get() => _tareasRepository.ObtenerListaTareas();

        [HttpGet("{id}")]
        public Tarea Get(int id) => _tareasRepository.ObtenerTarea(id);

        [HttpPost]
        public void Post([FromBody]Tarea tarea) => _tareasRepository.AgregarTarea(tarea);

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Tarea tarea) => _tareasRepository.ActualizarTarea(id, tarea);

        [HttpDelete("{id}")]
        public void Delete(int id) => _tareasRepository.EliminarTarea(id);
    }
}
