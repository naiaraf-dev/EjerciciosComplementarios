namespace Ejercicio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RegistroActividadesController controlador = new RegistroActividadesController();

            controlador.AgregarRegistro(new Usuario("Ana"));
            controlador.AgregarRegistro(new Curso("Matemática Avanzada"));
            controlador.AgregarRegistro(new Inscripcion("Ana", "Matemática Avanzada"));

            controlador.GenerarReporte();
        }
    }

    public interface IRegistrable
    {
        string ObtenerLog();
    }

    public class Usuario : IRegistrable
    {
        public string Nombre { get; set; }

        public Usuario(string nombre)
        {
            Nombre = nombre;
        }

        public string ObtenerLog()
        {
            return $"Usuario '{Nombre}' accedió al sistema.";
        }
    }

    public class Curso : IRegistrable
    {
        public string Titulo { get; set; }

        public Curso(string titulo)
        {
            Titulo = titulo;
        }

        public string ObtenerLog()
        {
            return $"Curso '{Titulo}' fue creado o modificado.";
        }
    }

    public class Inscripcion : IRegistrable
    {
        public string NombreUsuario { get; set; }
        public string NombreCurso { get; set; }

        public Inscripcion(string usuario, string curso)
        {
            NombreUsuario = usuario;
            NombreCurso = curso;
        }

        public string ObtenerLog()
        {
            return $"Usuario '{NombreUsuario}' se inscribió en el curso '{NombreCurso}'.";
        }
    }

    public class RegistroActividadesController
    {
        private List<IRegistrable> registros = new List<IRegistrable>();

        public void AgregarRegistro(IRegistrable registro)
        {
            registros.Add(registro);
        }

        public void GenerarReporte()
        {
            Console.WriteLine("--- Reporte de actividad del sistema ---");
            foreach (var registro in registros)
            {
                Console.WriteLine(registro.ObtenerLog());
            }
        }
    }
}
