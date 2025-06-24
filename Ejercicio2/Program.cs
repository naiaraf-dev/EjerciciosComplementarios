namespace Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UsuarioController controlador = new UsuarioController();

            controlador.AgregarUsuario(new Dedu("Juan Pérez"));
            controlador.AgregarUsuario(new UA("Unidad Académica - Facultad X"));
            controlador.AgregarUsuario(new Estudiante("María López"));

            controlador.MostrarModulos();
        }
    }

    public interface IUsuarioModulo
    {
        List<string> ListarModulos();
        string Nombre { get; }  // para identificar el usuario en la lista
    }

    public class Dedu : IUsuarioModulo
    {
        public string Nombre { get; private set; }

        public Dedu(string nombre)
        {
            Nombre = nombre;
        }

        public List<string> ListarModulos()
        {
            return new List<string> { "Gestión de Cursos", "Estadísticas", "Soporte", "Administración" };
        }
    }

    public class UA : IUsuarioModulo
    {
        public string Nombre { get; private set; }

        public UA(string nombre)
        {
            Nombre = nombre;
        }

        public List<string> ListarModulos()
        {
            return new List<string> { "Gestión de Cursos", "Estadísticas" };
        }
    }

    public class Estudiante : IUsuarioModulo
    {
        public string Nombre { get; private set; }

        public Estudiante(string nombre)
        {
            Nombre = nombre;
        }

        public List<string> ListarModulos()
        {
            return new List<string> { "Gestión de Cursos" };
        }
    }

    public class UsuarioController
    {
        private List<IUsuarioModulo> usuarios = new List<IUsuarioModulo>();

        public void AgregarUsuario(IUsuarioModulo usuario)
        {
            usuarios.Add(usuario);
        }

        public void MostrarModulos()
        {
            Console.WriteLine("--- Módulos accesibles por usuario ---");
            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"\nUsuario: {usuario.Nombre}");
                List<string> modulos = usuario.ListarModulos();

                foreach (string modulo in modulos)
                {
                    Console.WriteLine($"- {modulo}");
                }
            }
        }
    }
}
