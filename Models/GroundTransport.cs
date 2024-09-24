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

        public override double CalculateRaceTime(double distance, Weather weather)
        {
            double time = 0;
            double coveredDistance = 0;
            int restCount = 0;
            double adjustedSpeed = AdjustSpeedForWeather(weather);

            while (coveredDistance < distance)
            {
                if (coveredDistance + adjustedSpeed * TimeBeforeRest <= distance)
                {
                    coveredDistance += adjustedSpeed * TimeBeforeRest;
                    time += TimeBeforeRest;
                    time += RestDuration * (1 + restCount); // увеличиваем время отдыха в зависимости от порядкового номера
                    restCount++;
                }
                else
                {
                    time += (distance - coveredDistance) / adjustedSpeed;
                    coveredDistance = distance;
                }
            } 

            return time;
        }
    }
}
