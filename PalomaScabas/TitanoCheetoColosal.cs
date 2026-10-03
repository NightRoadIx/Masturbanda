namespace MonitoreoVehiculo
{
    class TitanoCheetoColosal
    {
        public static void Main()
        {
            
        }
    }

    // Se genera una interfaz IMedible, que indica si
    // un sensor puede medir algún valor
    // Al usar interfaces, preferir el nombre con una "I" incial
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
            return 69.0;
        }

       public void Calibrar(double factor)
        {
            this.factor = factor;
            Calibrado = true;
        }
    }

}