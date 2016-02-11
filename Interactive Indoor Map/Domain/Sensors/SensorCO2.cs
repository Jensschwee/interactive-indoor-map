namespace Domain.Sensors
{
    class SensorCO2 : Sensor
    {
        public int PPM { get; set; }

        public SensorCO2(string name) : base(name) { }
    }
}
