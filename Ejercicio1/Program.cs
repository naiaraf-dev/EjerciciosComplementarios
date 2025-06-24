namespace Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ControladorUsuarios controlador = new ControladorUsuarios();

            controlador.AgregarUsuario(new Admin("Carla", "carla@admin.com"));
            controlador.AgregarUsuario(new Editor("Luis", "luis@editor.com"));
            controlador.AgregarUsuario(new Lector("Ana", "ana@lector.com"));

            controlador.MostrarPermisos();
        }
    }

    // Clase abstracta base
    public abstract class Usuario
    {
        public string nombre { get; set; }
        public string email { get; set; }

        public Usuario(string nombre, string email)
        {
            this.nombre = nombre;
            this.email = email;
        }

        // Método abstracto a implementar por cada rol
        public abstract void VerPermisos();
    }

    // Admin con todos los permisos
    public class Admin : Usuario
    {
        public Admin(string nombre, string email) : base(nombre, email) { }

        public override void VerPermisos()
        {
            Console.WriteLine($"[Admin] {nombre} - Permisos: Crear, Editar, Eliminar, Ver.");
        }
    }

    // Editor con permisos de edición
    public class Editor : Usuario
    {
        public Editor(string nombre, string email) : base(nombre, email) { }

        public override void VerPermisos()
        {
            Console.WriteLine($"[Editor] {nombre} - Permisos: Editar, Ver.");
        }
    }

    // Lector con permisos de solo lectura
    public class Lector : Usuario
    {
        public Lector(string nombre, string email) : base(nombre, email) { }

        public override void VerPermisos()
        {
            Console.WriteLine($"[Lector] {nombre} - Permisos: Ver únicamente.");
        }
    }

    public class ControladorUsuarios
    {
        private List<Usuario> listaUsuarios = new List<Usuario>();

        public void AgregarUsuario(Usuario usuario)
        {
            listaUsuarios.Add(usuario);
        }

        public void MostrarPermisos()
        {
            Console.WriteLine("\n--- Permisos de los Usuarios ---");
            foreach (Usuario u in listaUsuarios)
            {
                u.VerPermisos();
            }
        }
    }
}
