namespace Ryazantcev__353503_Lab5.Domain
{
    public class Car
    {
        public Engine Engine { get; set; }  

        public Car(Engine engine)
        {
            Engine = engine;
        }

        public Car() { }
        
    }
}
