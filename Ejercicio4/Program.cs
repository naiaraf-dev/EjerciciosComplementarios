namespace Ejercicio4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NotificacionController controlador = new NotificacionController();

            controlador.AgregarNotificacion(new EmailNotificacion("Bienvenido al sistema", "juan@mail.com"));
            controlador.AgregarNotificacion(new SmsNotificacion("Su código es 1234", "+5491123456789"));
            controlador.AgregarNotificacion(new NotificacionInterna("Tienes una nueva tarea asignada", "Maria"));

            controlador.EnviarMasivo();
        }
    }

    public abstract class Notificacion
    {
        public string Mensaje { get; set; }
        public string Destinatario { get; set; }

        public Notificacion(string mensaje, string destinatario)
        {
            Mensaje = mensaje;
            Destinatario = destinatario;
        }

        public abstract void Enviar();
    }

    public class EmailNotificacion : Notificacion
    {
        public EmailNotificacion(string mensaje, string destinatario)
            : base(mensaje, destinatario) { }

        public override void Enviar()
        {
            Console.WriteLine($"Enviando Email a {Destinatario}: {Mensaje}");
        }
    }

    public class SmsNotificacion : Notificacion
    {
        public SmsNotificacion(string mensaje, string destinatario)
            : base(mensaje, destinatario) { }

        public override void Enviar()
        {
            Console.WriteLine($"Enviando SMS a {Destinatario}: {Mensaje}");
        }
    }

    public class NotificacionInterna : Notificacion
    {
        public NotificacionInterna(string mensaje, string destinatario)
            : base(mensaje, destinatario) { }

        public override void Enviar()
        {
            Console.WriteLine($"Notificación interna para {Destinatario}: {Mensaje}");
        }
    }

    public class NotificacionController
    {
        private List<Notificacion> notificaciones = new List<Notificacion>();

        public void AgregarNotificacion(Notificacion notificacion)
        {
            notificaciones.Add(notificacion);
        }

        public void EnviarMasivo()
        {
            Console.WriteLine("--- Envío masivo de notificaciones ---");
            foreach (var notificacion in notificaciones)
            {
                notificacion.Enviar();
            }
        }
    }
}
