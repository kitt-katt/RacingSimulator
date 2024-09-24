// Сапоги-скороходы

namespace RacingSimulator.Transports
{
    using RacingSimulator.Models;

    public class Boots : GroundTransport
    {
        public Boots() : base("Сапоги-скороходы", 15, 6, 1) { }

        public override double CalculateRaceTime(double distance)
        {
            // Экспоненциальное снижение времени на гонку
            return Math.Exp(distance / Speed) / 10;
        }
    }
}
