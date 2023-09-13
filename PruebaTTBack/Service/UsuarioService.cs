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

        public List<PersonasVM> GetAllUsuarios()
        {
            List<PersonasVM> personasVMs = new List<PersonasVM>();
            var consuulta = (from usuarios in _context.Users
                             join departamentos in _context.Departamentos
                             on usuarios.idDepartamento equals departamentos.id
                             join cargo in _context.Cargos
                             on usuarios.idCargo equals cargo.id
                             where  usuarios.estado == true
                             select new
                             {
                                 usuarios.id,
                                 usuarios.primerNombre,
                                 usuarios.segundoNombre,
                                 usuarios.primerApellido,
                                 usuarios.segundoApellido,
                                 Estado = usuarios.estado,
                                 Email = usuarios.Correo,
                                 Usuario = usuarios.usuario,
                                 idCargo = cargo.id,
                                 NombreCargo = cargo.nombre,
                                 idDeparameto = departamentos.id,
                                 NombreDepartamento = departamentos.nombre
                                
                             }
                             ).ToList();
            foreach (var item in consuulta)
            {
                PersonasVM persona = new PersonasVM
                {
                    Id = item.id,
                    PrimerNombre = item.primerNombre,
                    SegundoNombre = item.segundoNombre,
                    PrimerApellido = item.primerApellido,
                    SegundoApellido = item.segundoApellido,
                    NombreCargo = item.NombreCargo,
                    IdCargo = item.idCargo,
                    IdDepartamento = item.idDeparameto,
                    NombreDepartamento = item.NombreDepartamento,
                    Estado = item.Estado, 
                    Email = item.Email,
                    Usuario = item.Usuario
                };
                personasVMs.Add(persona);
            }


            return personasVMs;
        }

        public ResponseVM SetUsuario(PersonasVM personasVM)
        {
            ResponseVM respuesta = new ResponseVM();
            try
            {
                var existe = _context.Users.Where(s => s.usuario == personasVM.Usuario).Any();
                if (!existe)
                {
                    Users user = new Users
                    {
                        primerApellido = personasVM.PrimerApellido,
                        segundoApellido = personasVM.SegundoApellido,
                        primerNombre = personasVM.PrimerNombre,
                        segundoNombre = personasVM.SegundoNombre,
                        idDepartamento = personasVM.IdDepartamento,
                        idCargo = personasVM.IdCargo,
                        usuario = personasVM.Usuario,
                        estado = true,
                        Correo = personasVM.Email
                    };
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    respuesta.Ejecutado = true;
                    respuesta.Mensaje = "Usuario registrado correctamente";

                }
                else
                {
                    respuesta.Ejecutado = false;
                    respuesta.Mensaje = "Usuario ya existe";
                }
            }
            catch (Exception ex)
            {

                respuesta.Ejecutado = false;
                respuesta.Mensaje = $"Ocurrio un error: {ex.Message}" ;
            }
           

            return respuesta;
        }

        public ResponseVM DeleteUsuario(PersonasVM personasVM)
        {
            ResponseVM respuesta = new ResponseVM();
            try
            {
                var existe = _context.Users.Where(s => s.usuario == personasVM.Usuario && s.estado == true).FirstOrDefault();
                if (existe != null)
                {
                    existe.estado = false;
                    
                    _context.SaveChanges();
                    respuesta.Ejecutado = true;
                    respuesta.Mensaje = "Usuario Eliminado correctamente";

                }
                else
                {
                    respuesta.Ejecutado = false;
                    respuesta.Mensaje = "Usuario no existe";
                }
            }
            catch (Exception ex)
            {

                respuesta.Ejecutado = false;
                respuesta.Mensaje = $"Ocurrio un error: {ex.Message}";
            }


            return respuesta;
        }

        public ResponseVM UpdateUsuario(PersonasVM personasVM)
        {
            ResponseVM respuesta = new ResponseVM();
            try
            {
                var existe = _context.Users.Where(s => s.usuario == personasVM.Usuario &&  s.estado == true).FirstOrDefault();
                if (existe != null)
                {
                    existe.primerApellido = personasVM.PrimerApellido;
                    existe.primerNombre = personasVM.PrimerNombre;
                    existe.segundoNombre = personasVM.SegundoNombre;
                    existe.segundoApellido = personasVM.SegundoApellido;
                    existe.Correo = personasVM.Email;

                    _context.SaveChanges();
                    respuesta.Ejecutado = true;
                    respuesta.Mensaje = "Usuario actualizado correctamete";

                }
                else
                {
                    respuesta.Ejecutado = false;
                    respuesta.Mensaje = "Usuario no existe";
                }
            }
            catch (Exception ex)
            {

                respuesta.Ejecutado = false;
                respuesta.Mensaje = $"Ocurrio un error: {ex.Message}";
            }


            return respuesta;
        }
    }
}
