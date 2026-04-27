namespace Racing.models
{
    public class Car
   {
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public double Acceleration { get; set; }
 
        public Car(string name, int maxSpeed, double acceleration)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            Acceleration = acceleration;
        }
    }
}