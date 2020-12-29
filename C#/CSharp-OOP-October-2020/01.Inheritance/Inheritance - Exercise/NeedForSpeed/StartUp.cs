using NeedForSpeed.Vehicle.Car;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main()
        {
            Car car = new Car(200,200);
            car.Drive(25.5);

            SportCar sport = new SportCar(500, 150);
            sport.Drive(30.6);
        }
    }
}
