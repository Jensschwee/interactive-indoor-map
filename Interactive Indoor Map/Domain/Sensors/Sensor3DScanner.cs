namespace Domain.Sensors
{
    class Sensor3DScanner : Sensor
    {
        public int Occupants { get; set; }

        public Sensor3DScanner(string name) : base(name) { }
        
        public void AddOccupant()
        {
            Occupants++;
        }

        public void RemoveOccupant()
        {
            Occupants--;
        }
    }
}
