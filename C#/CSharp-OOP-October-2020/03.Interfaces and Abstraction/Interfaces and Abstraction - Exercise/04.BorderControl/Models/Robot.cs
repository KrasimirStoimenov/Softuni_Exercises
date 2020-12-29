using _04.BorderControl.Interface;

namespace _04.BorderControl.Models
{
    public class Robot : IControlable
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; private set; }
        public string Id { get; private set; }
    }
}
