using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int weight;

        private const int minWeight = 1;
        private const int maxWeight = 200;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException($"Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException($"Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }

        public int Weight
        {
            get => this.weight;
            private set
            {
                if (value < minWeight || value > maxWeight)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{minWeight}..{maxWeight}].");
                }
                this.weight = value;
            }
        }

        public double DoughCalories()
        {
            double flourTypeCalories = 0;
            if (this.FlourType.ToLower() == "white")
            {
                flourTypeCalories = 1.5;
            }
            else if (this.FlourType.ToLower() == "wholegrain")
            {
                flourTypeCalories = 1.0;
            }

            double bakingTechniqueCalories = 0;
            if (this.BakingTechnique.ToLower() == "crispy")
            {
                bakingTechniqueCalories = 0.9;
            }
            else if (this.BakingTechnique.ToLower() == "chewy")
            {
                bakingTechniqueCalories = 1.1;
            }
            else if (this.BakingTechnique.ToLower() == "homemade")
            {
                bakingTechniqueCalories = 1.0;
            }

            return (this.Weight * 2.0) * flourTypeCalories * bakingTechniqueCalories;
        }
    }
}
