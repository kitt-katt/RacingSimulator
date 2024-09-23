// Абстракция для наземных транспортных средств


namespace RacingSimulator.Models
{
    public abstract class GroundTransport : Transport
    {
        public double TimeBeforeRest { get; }
        public double RestDuration { get; }

        protected GroundTransport(string name, double speed, double timeBeforeRest, double restDuration)
            : base(name, speed)
        {
            TimeBeforeRest = timeBeforeRest;
            RestDuration = restDuration;
        }

        public override double CalculateRaceTime(double distance)
        {
            double time = 0;
            double coveredDistance = 0;
            int restCount = 0;

            while (coveredDistance < distance)
            {
                if (coveredDistance + Speed * TimeBeforeRest <= distance)
                {
                    coveredDistance += Speed * TimeBeforeRest;
                    time += TimeBeforeRest;
                    time += RestDuration * (1 + restCount); // увеличиваем время отдыха
                    restCount++;
                }
                else
                {
                    time += (distance - coveredDistance) / Speed;
                    coveredDistance = distance;
                }
            }

            return time;
        }
    }
}
