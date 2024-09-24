// Абстрактный класс для всех видов транспорта


namespace RacingSimulator.Models
{
    public abstract class Transport
    {
        public string Name { get; }
        public double Speed { get; }

        protected Transport(string name, double speed)
        {
            Name = name;
            Speed = speed;
        }

        public abstract double CalculateRaceTime(double distance, Weather weather);

        // Общая логика для модификации скорости под влиянием погоды
        protected double AdjustSpeedForWeather(Weather weather)
        {
            return Speed * weather.GetSpeedModifier(this);
        }
    }
}
