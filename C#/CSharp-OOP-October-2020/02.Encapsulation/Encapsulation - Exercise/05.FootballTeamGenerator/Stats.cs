using System;

namespace _05.FootballTeamGenerator
{
    public class Stats
    {
        private const int STATS_MIN_VALUE = 0;
        private const int STATS_MAX_VALUE = 100;
        private const string INVALID_STATS_RANGE_MESSAGE = "{0} should be between 0 and 100.";

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                if (!ValidateRange(value))
                {
                    throw new ArgumentException(string.Format(INVALID_STATS_RANGE_MESSAGE, nameof(this.Endurance)));
                }
                this.endurance = value;
            }
        }
        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                if (!ValidateRange(value))
                {
                    throw new ArgumentException(string.Format(INVALID_STATS_RANGE_MESSAGE, nameof(this.Sprint)));
                }
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
                if (!ValidateRange(value))
                {
                    throw new ArgumentException(string.Format(INVALID_STATS_RANGE_MESSAGE, nameof(this.Dribble)));
                }
                this.dribble = value;
            }
        }
        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                if (!ValidateRange(value))
                {
                    throw new ArgumentException(string.Format(INVALID_STATS_RANGE_MESSAGE, nameof(this.Passing)));
                }
                this.passing = value;
            }
        }
        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                if (!ValidateRange(value))
                {
                    throw new ArgumentException(string.Format(INVALID_STATS_RANGE_MESSAGE, nameof(this.Shooting)));
                }
                this.shooting = value;
            }
        }

        public double GetSkillLevel()
        {
            double skillLevel = (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.00;
            return skillLevel;
        }
        private bool ValidateRange(int value)
        {
            if (value < STATS_MIN_VALUE || value > STATS_MAX_VALUE)
            {
                return false;
            }
            return true;
        }
    }
}
