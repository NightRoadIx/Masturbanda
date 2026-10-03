namespace MonitoreoVehiculo
{
    class TitanoCheetoColosal
    {
        public static void Main()
        {
            // Pero se puede instanciar un objeto a partir
            // de la interfaz de la que heredan
            var revision = new List<IDiagnosticable>
            {
                new Bateria(),
                new Neumatico(),
                new PastillaDeFreno()
            };

            foreach (IDiagnosticable componente in revision)
                Console.WriteLine(componente.Diagnostico());
            }
    }

    // Se genera una interfaz IMedible, que indica si
    // un sensor puede medir algún valor
    // Al usar interfaces, preferir el nombre con una "I" incial
    // seguido de un adjetivo, ya que la interfaz indica ¿qué es 
    // lo que puede hacer la clase?
    interface IMedible
    {
        // Aquí solamente se coloca un método solamente definido
        double Medir();
    }

    interface ICalibrable
    {
        // También es posible colocar un atributo
        // que tenga el formato de lectura/escritura
        bool Calibrado { get; }
        void Calibrar(double factor);
    }

    // Las clases pueden heredar de múltiples interfaces
    // Estas le indican que debe incluir a fuerzas
    class SensorDePrueba : IMedible, ICalibrable
    {
        private double factor = 1.0;
        // Como la propiedad se modificará al interior de
        // la clase, se incluye un private set
        public bool Calibrado { get; private set; }

        public double Medir()
        {
            return 69.0 * factor;
        }

       public void Calibrar(double factor)
        {
            this.factor = factor;
            Calibrado = true;
        }
    }

    // O se puede crear una interfaz de este estilo
    interface IDiagnosticable
    {
        string Diagnostico();
    }

    // Y se usa para 3 clases que no tienen nada que ver
    // entre ellas, que al abstraer el problema, no habría
    // forma de modelar una clase padre en común
    // OJO: Una clase puede heredar de UNA clase y de varias
    // interfaces, siempre siguiendo el orden que la clase
    // va primero que las interfaces
    class Bateria : IDiagnosticable
    {
        public string Diagnostico()
        {
            return "Batería: 12.4 V, estado bueno";
        }
    }

    class Neumatico : IDiagnosticable
    {
        public string Diagnostico()
        {
            return "Neumático: 32 psi, desgaste 20 %";
        }
    }

    class PastillaDeFreno : IDiagnosticable
    {
        public string Diagnostico()
        {
            return "Pastilla: 4 mm restantes, cambio sugerido";
        }
    }    

}