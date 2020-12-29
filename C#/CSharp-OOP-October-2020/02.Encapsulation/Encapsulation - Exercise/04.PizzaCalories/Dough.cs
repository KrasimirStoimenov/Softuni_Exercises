using System;
using System.Collections.Generic;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private const int DEFAULT_DOUGH_CALORIES_PER_GRAM = 2;
        private const string INVALID_TYPE_MESSAGE = "Invalid type of dough.";
        private const int DOUGH_MIN_WEIGHT = 1;
        private const int DOUGH_MAX_WEIGHT = 200;
        private const string INVALID_WEIGHT_MESSAGE = "Dough weight should be in the range [1..200].";

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            set
            {
                if (!FlourTypes.IsValidFlourType(value))
                {
                    throw new Exception(INVALID_TYPE_MESSAGE);
                }

                this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            set
            {
                if (!BakingTechniques.IsValidBakingTechnique(value))
                {
                    throw new Exception(INVALID_TYPE_MESSAGE);
                }
                this.bakingTechnique = value;
            }
        }
        public int Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value < DOUGH_MIN_WEIGHT || value > DOUGH_MAX_WEIGHT)
                {
                    throw new Exception(INVALID_WEIGHT_MESSAGE);
                }
                this.weight = value;
            }
        }

        public double TotalCalories()
        {
            double flourModifier = FlourTypes.GetModifier(this.FlourType);
            double bakingTechniqueModifier = BakingTechniques.GetModifier(this.BakingTechnique);
            double totalCalories = DEFAULT_DOUGH_CALORIES_PER_GRAM * this.Weight * flourModifier * bakingTechniqueModifier;
            return totalCalories;
        }

        private static class FlourTypes
        {
            private static Dictionary<string, double> flourTypes = new Dictionary<string, double>()
            {
            { "white" , 1.5 },
            { "wholegrain",1.0 },
            };
            public static bool IsValidFlourType(string type)
            {
                if (flourTypes.ContainsKey(type.ToLower()))
                {
                    return true;
                }

                return false;
            }
            public static double GetModifier(string type)
            {
                return flourTypes[type.ToLower()];
            }

        }

        private static class BakingTechniques
        {
            private static Dictionary<string, double> bakingTechniques = new Dictionary<string, double>()
            {
                { "crispy",0.9 },
                { "chewy", 1.1 },
                { "homemade", 1.0}
            };
            public static bool IsValidBakingTechnique(string type)
            {
                if (bakingTechniques.ContainsKey(type.ToLower()))
                {
                    return true;
                }

                return false;
            }
            public static double GetModifier(string type)
            {
                return bakingTechniques[type.ToLower()];
            }
        }
    }
}
