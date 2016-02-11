namespace Domain.Sensors
{
    class SensorLumen : Sensor
    {
        public int Lumen { get; set; }

        public SensorLumen(string name) : base(name) { }
    }
}
