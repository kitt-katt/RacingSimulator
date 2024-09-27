// Метла

namespace RacingSimulator.Transports;


using RacingSimulator.Models;

public class Broom : AirTransport
{
    public Broom() : base("Метла", 20, 1.1) { }

    public override double CalculateRaceTime(double distance, Weather weather)
    {
        double adjustedSpeed = AdjustSpeedForWeather(weather);
        return distance / (adjustedSpeed * AccelerationFactor);
    }
}