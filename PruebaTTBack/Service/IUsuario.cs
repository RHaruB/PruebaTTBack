using PruebaTTBack.ViewModels;

namespace PruebaTTBack.Service
{
    public interface IUsuario
    {
        public List<CatalogoVM> GetAllDepartamentos();
        public List<CatalogoVM> GetAllCargos();
        public List<PersonasVM> GetAllUsuarios();

        public ResponseVM SetUsuario(PersonasVM personasVM);
        public ResponseVM DeleteUsuario(PersonasVM personasVM);
        public ResponseVM UpdateUsuario(PersonasVM personasVM);
    }
}
