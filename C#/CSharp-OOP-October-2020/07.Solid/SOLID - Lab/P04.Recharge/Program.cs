namespace P04.Recharge
{
    using System;

    class Program
    {
        static void Main()
        {
            IWorker emp = new Employee("22");
            IWorker robot = new Robot("21", 150);

            emp.Work(15);
            robot.Work(12);
        }
    }
}
