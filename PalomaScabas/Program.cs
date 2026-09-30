
// una sola linea
/*
 * varias lineas
 */

/// <summary>
/// Clase principal del programa de monitoreo de sensores de vehículo.
/// </summary>
namespace MonitoreoVehiculo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inicialización de los 4 sensores usando la clase Sensor
            Sensor[] sensores = new Sensor[]
            {
                new Sensor("Temperatura", "°C", 90.0, esAlertaPorMinimo: false),
                new Sensor("RPM", "rpm", 7000.0, esAlertaPorMinimo: false),
                new Sensor("Nivel de combustible", "litros", 0, esAlertaPorMinimo: true),
                new Sensor("Presión del múltiple", "KPa", 100.0, esAlertaPorMinimo: false),
                new SensorTemperatura("Sensor Derivado", "°C", 30.0)
            };

            // <Wrapper> (envoltorio)
            // Para las listas de objetos se ocupa
            // Lista<WrapperClase> nombreLista = new Lista<WrapperClaseConstructor>();
            List<Sensor> lista = new List<Sensor>();
            lista.Add(
                new Sensor("Presión del múltiple", "KPa", 100.0, esAlertaPorMinimo: false)
            );

            // Procesamiento de lecturas para cada sensor
            /*foreach (Sensor s in sensores)
            {
                s.Leer();
            }

            Console.WriteLine("\n------ Resultados ------");
            foreach (Sensor s in sensores)
            {
                s.MostrarReporte();
                if(s.enAlerta())
                    Console.WriteLine("\n[Alerta] El sensor de Temperatura ha excedido el umbral.");
            }*/

            // Crear dos objetos para ver la diferencia de comportamiento entre la clase base y la clase derivada
            Sensor sensorBase = new Sensor("Sensor Base", "unidad", 50.0);
            SensorTemperatura sensorDerivado = new SensorTemperatura("Sensor Derivado", "°C", 30.0);

            Sensor sensorPolimorfico = new Sensor("Sensor Polimórfico");       }
    }

    /// <summary>
    /// Clase que representa un sensor de vehículo, con atributos y métodos para capturar y analizar lecturas.
    /// <c> esto es código </c>
    /// </summary>
    class Sensor
    {
        // Atributos de la clase
        private string Nombre;
        private string Unidad;
        private double Umbral;
        private double CapacidadTanque;
        private bool EsAlertaPorMinimo;
        private double[] Lecturas;

        public string Nombre1
        {
            // atributo de lectura
            get { return Nombre; }
        }

        public string Unidad1
        {
            // atributo de lectura
            get { return Unidad; }
        }

        public double Umbral1
        {
            // atributo de lectura
            get { return Umbral; }
        }

        public double CapacidadTanque1
        {
            // atributo de lectura
            get { return CapacidadTanque; }
        }

        public bool EsAlertaPorMinimo1
        {
            // atributo de lectura
            get { return EsAlertaPorMinimo; }
        }

        public double[] Lecturas1
        {
            // atributo de lectura
            get { return Lecturas; }
            // atributo de escritura
            set
            {
                if (value.Length <= 0)
                    // throw -> Lanzar
                    // Exception -> Error en la ejecucion
                    throw new ArgumentException("Las lecturas no pueden estar vacías");
                Lecturas = value;
            }
        }

        public Sensor(string nombre, string unidad, double umbral, bool esAlertaPorMinimo = false)
        {
            Nombre = nombre;
            Unidad = unidad;
            Umbral = umbral;
            EsAlertaPorMinimo = esAlertaPorMinimo;
            Lecturas = new double[0];
            CapacidadTanque = 0;
            Console.WriteLine("Sensor padre");
        }

        public Sensor(string nombre)
        {
            Nombre = nombre;
            Unidad = "unidad";
            Umbral = 0;
            EsAlertaPorMinimo = false;
            Lecturas = new double[0];
            CapacidadTanque = 0;
        }

        // Funciones
        /// <summary>
        /// aquí se capturan las lecturas del sensor, incluyendo validación de datos y manejo de excepciones.
        /// basado en el nombre del sensor, se solicita información adicional como la capacidad del tanque para el sensor de nivel de combustible.
        /// cuando se ingresan las lecturas, se asegura que sean números válidos y se almacenan en el arreglo de lecturas del sensor.
        /// </summary>
        public void Leer()
        {
            // Demostración de captura de excepción al intentar asignar un arreglo de tamaño 0
            try
            {
                Lecturas1 = new double[0];
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\n[Prueba de excepción]: Se detectó una validación en {Nombre1} -> {ex.Message}");
            }

            int maxDatos;
            Console.Write($"\nIngresa la cantidad de lecturas del sensor {Nombre1}: ");
            while (!int.TryParse(Console.ReadLine(), out maxDatos) || maxDatos <= 0)
            {
                Console.Write("Dato inválido, intente de nuevo: ");
            }

            // Arreglo temporal para llenar los datos
            double[] datosTemporal = new double[maxDatos];

            // Comprobación sin cambios de mayúsculas/minúsculas
            if (Nombre1.Equals("Nivel de combustible", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write($"Capacidad máxima de combustible ({Unidad1}): ");
                while (!double.TryParse(Console.ReadLine(), out CapacidadTanque) || CapacidadTanque <= 0)
                {
                    Console.Write("Dato inválido, intente de nuevo: ");
                }

                // El umbral de alerta al 10% de la capacidad ingresada
                Umbral = CapacidadTanque * 0.10;

                Console.WriteLine($"--- Captura de datos de {Nombre1} ---");
                for (int i = 0; i < maxDatos; i++)
                {
                    Console.Write($"Lectura {i + 1} de {maxDatos} ({Unidad1}): ");
                    while (!double.TryParse(Console.ReadLine(), out datosTemporal[i]))
                    {
                        Console.Write("Dato inválido, intente de nuevo: ");
                    }
                }
            }
            else
            {
                Console.WriteLine($"--- Captura de datos: {Nombre1} ---");
                for (int i = 0; i < maxDatos; i++)
                {
                    Console.Write($"Lectura {i + 1} de {maxDatos} ({Unidad1}): ");
                    while (!double.TryParse(Console.ReadLine(), out datosTemporal[i]))
                    {
                        Console.Write("Dato inválido, intente de nuevo: ");
                    }
                }
            }

            // Asignación de Lecturas1
            Lecturas1 = datosTemporal;
        }

        public double Promedio()
        {
            if (Lecturas1.Length == 0) return 0;
            double suma = 0;
            foreach (double l in Lecturas1)
                suma += l;
            return suma / Lecturas1.Length;
        }

        public double Maxima()
        {
            if (Lecturas1.Length == 0) return 0;
            double max = Lecturas1[0];
            foreach (double l in Lecturas1)
                if (l > max) max = l;
            return max;
        }

        public double Minima()
        {
            if (Lecturas1.Length == 0) return 0;
            double min = Lecturas1[0];
            foreach (double l in Lecturas1)
                if (l < min) min = l;
            return min;
        }

        public bool EvaluarAlerta()
        {
            if (EsAlertaPorMinimo1)
                return Minima() < Umbral1;
            else
                return Maxima() > Umbral1;
        }

        public void MostrarReporte()
        {
            double prom = Promedio();
            bool hayAlerta = EvaluarAlerta();

            Console.WriteLine($"\nSensor: {Nombre1}");

            if (CapacidadTanque1 > 0)
            {
                Console.WriteLine($"Capacidad del tanque: {CapacidadTanque1:F2} {Unidad1}");
            }

            Console.WriteLine($"Promedio        : {prom:F2} {Unidad1}");

            if (EsAlertaPorMinimo1)
            {
                Console.WriteLine($"Mínimo          : {Minima():F2} {Unidad1}");
                Console.WriteLine($"Umbral Mín (10%): {Umbral1:F2} {Unidad1}");
            }
            else
            {
                Console.WriteLine($"Máximo          : {Maxima():F2} {Unidad1}");
                Console.WriteLine($"Umbral Máx      : {Umbral1:F2} {Unidad1}");
            }

            if (hayAlerta)
                Console.WriteLine("      ¡Límite excedido!");
        }

        public virtual bool enAlerta()
        {
            return Maxima() > Umbral;
        }
    }

    // Herencia 
    // Clase Sensor de Temperatura que hereda de Sensor
    class SensorTemperatura : Sensor
    {
        public SensorTemperatura(string nombre, string unidad, double umbral)
            : base(nombre, unidad, umbral)
        {
            Console.WriteLine("Sensor clase hija");
        }

        public override bool enAlerta()
        {
            return Minima() < Umbral1;
        }

        // Método adicional específico para el sensor de temperatura
        public void MostrarEstado()
        {
            double promedio = Promedio();
            if (promedio > Umbral1)
            {
                Console.WriteLine($"[Alerta] La temperatura promedio ({promedio:F2} {Unidad1}) excede el umbral ({Umbral1:F2} {Unidad1}).");
            }
            else
            {
                Console.WriteLine($"La temperatura promedio ({promedio:F2} {Unidad1}) está dentro del rango seguro.");
            }
        }
    }
}