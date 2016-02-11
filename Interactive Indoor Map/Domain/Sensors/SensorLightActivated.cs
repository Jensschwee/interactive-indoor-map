namespace Domain.Sensors
{
    class SensorLightActivated : Sensor
    {
        public bool Activated { get; set; }

        public SensorLightActivated(string name) : base(name) { }
    }
}
