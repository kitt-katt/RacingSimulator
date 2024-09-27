// Сапоги-скороходы

namespace RacingSimulator.Transports;


using RacingSimulator.Models;

public class Boots : GroundTransport
{
    public Boots() : base("Сапоги-скороходы", 15, 6, 1) { }

    public override double CalculateRaceTime(double distance, Weather weather)
    {
        // Экспоненциальное снижение времени на гонку c учетом погоды
        double adjustedSpeed = AdjustSpeedForWeather(weather);
        return Math.Exp(distance / Speed) / 10 * adjustedSpeed;
    }
}
