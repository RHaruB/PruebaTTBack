using DataBase;
using PruebaTTBack.ViewModels;

namespace PruebaTTBack.Service
{
    public class UsuarioService : IUsuario
    {
        PruebaContext _context;

        public UsuarioService(PruebaContext context)
        {
            _context = context; 
        }

        public List<CatalogoVM> GetAllCargos()
        {
            List<CatalogoVM> Lista = new List<CatalogoVM>();

            var consulta = _context.Cargos.ToList();
            foreach (var item in consulta)
            {
                CatalogoVM cargo = new CatalogoVM
                {
                    Descripcion = item.nombre,
                    ID = item.id
                };
                Lista.Add(cargo);
            }

            return Lista;
        }

        public List<CatalogoVM> GetAllDepartamentos()
        {
            List<CatalogoVM> Lista = new List<CatalogoVM>();

            var consulta = _context.Departamentos.ToList();
            foreach (var item in consulta)
            {
                CatalogoVM departamento = new CatalogoVM
                {
                    Descripcion = item.nombre,
                    ID = item.id
                };
                Lista.Add(departamento);
            }

            return Lista;
        }
    }
}
