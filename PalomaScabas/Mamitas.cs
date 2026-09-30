namespace MonitoreoVehiculo
{
    public class Mamitas
    {
        static void Main(string[] args)
        {
            // Instanciar un objeto Instrumento
            // Instrumento britany = new Instrumento("Britany Pérez");
            // var toma cualquier tipo de dato
            // y se instancia una lista de objetos tipo Instrumento
            // pero que se construyen a partir de las clases hijas
            var tablero = new List<Instrumento> { new Velocimetro() };
        }
    }

    // Clase abstracta
    abstract class Instrumento
    {
        // La variable nombre no debe ser nula
        // osease SIEMPRE debe tener un valor
        private string? nombre;
        public string? Nombre 
        { 
            get { return nombre; } 
        }

        // Constructor
        // es protegido, por que ya no va a instanciar
        // una clase
        protected Instrumento(string neim)
        {
            this.nombre = neim;
            Console.WriteLine($"Objeto {neim}");
        }
        
        // este método no va a estar definido en
        // la clase padre, solamente se declara
        public abstract double Leer();
    }

    // Herencia o clase hija
    class Velocimetro : Instrumento
    {
        // Constructor
        public Velocimetro() : base("Velocimetro")
        { }

        public override double Leer()
        {
            return 120.0;
        }

    }
}