namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private string favouriteFood;

        protected Animal(string name, string favouriteFood)
        {
            this.Name = name;
            this.FavouriteFood = favouriteFood;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }
        public string FavouriteFood
        {
            get
            {
                return this.favouriteFood;
            }
            private set
            {
                this.favouriteFood = value;
            }
        }

        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my fovourite food is {this.FavouriteFood} ";
        }
    }
}
