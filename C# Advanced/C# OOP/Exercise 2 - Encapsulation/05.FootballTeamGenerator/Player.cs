using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private double endurance;
        private double sprint;
        private double dribble;
        private double passing;
        private double shooting;

        private const int minStat = 0;
        private const int maxStat = 100;

        public Player(string name, double endurance, double sprint, double dribble, double passing, double shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrWhiteSpace(value, "A name should not be empty.");

                this.name = value;
            }
        }

        public double Endurance
        {
            get => this.endurance;
            private set
            {
                Validator.ThrowIfNumberISNotInRange(value, minStat, maxStat, $"{nameof(this.Endurance)} should be between {minStat} and {maxStat}.");

                this.endurance = value;
            }
        }
        public double Sprint
        {
            get => this.sprint;
            private set
            {
                Validator.ThrowIfNumberISNotInRange(value, minStat, maxStat, $"{nameof(this.Sprint)} should be between {minStat} and {maxStat}.");

                this.sprint = value;
            }
        }
        public double Dribble
        {
            get => this.dribble;
            private set
            {
                Validator.ThrowIfNumberISNotInRange(value, minStat, maxStat, $"{nameof(this.Dribble)} should be between {minStat} and {maxStat}.");

                this.dribble = value;
            }
        }
        public double Passing
        {
            get => this.passing;
            private set
            {
                Validator.ThrowIfNumberISNotInRange(value, minStat, maxStat, $"{nameof(this.Passing)} should be between {minStat} and {maxStat}.");

                this.passing = value;
            }
        }
        public double Shooting
        {
            get => this.shooting;
            private set
            {
                Validator.ThrowIfNumberISNotInRange(value, minStat, maxStat, $"{nameof(this.Shooting)} should be between {minStat} and {maxStat}.");

                this.shooting = value;
            }
        }

        public double AverageSkill
        {
            get => Math.Round((this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0);
        }

    }
}
