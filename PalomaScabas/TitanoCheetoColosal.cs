namespace MonitoreoVehiculo
{
    class TitanoCheetoColosal
    {
        public static void Main()
        {
            
        }
    }

    interface IMedible
    {
        double Medir();
    }

    interface ICalibrable
    {
        bool Calibrado { get; }
        void Calibrar(double factor);
    }

    class SensorDePrueba : IMedible, ICalibrable
    {
        private double factor = 1.0;
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