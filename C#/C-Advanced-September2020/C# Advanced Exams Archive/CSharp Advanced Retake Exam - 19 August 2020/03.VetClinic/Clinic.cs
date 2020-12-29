using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> pets;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.pets = new List<Pet>();
        }

        public int Count => this.pets.Count;

        public int Capacity { get; set; }

        public void Add(Pet pet)
        {
            if (pets.Count < Capacity)
            {
                pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            return this.pets.Remove(pets.FirstOrDefault(x => x.Name == name));
        }

        public Pet GetPet(string name, string owner)
        {
            return this.pets.FirstOrDefault(x => x.Name == name && x.Owner == owner);
        }

        public Pet GetOldestPet()
        {
            var sortedPets = this.pets.OrderByDescending(x => x.Age).ToList();
            var oldestPet = sortedPets[0];

            return oldestPet;
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
