using PruebaTTBack.ViewModels;

namespace PruebaTTBack.Service
{
    public interface IUsuario
    {
        public List<CatalogoVM> GetAllDepartamentos();
        public List<CatalogoVM> GetAllCargos();
    }
}
