// Абстракция для воздушных транспортных средств

namespace RacingSimulator.Models;


public abstract class AirTransport : Transport
{
    public double AccelerationFactor { get; }

    protected AirTransport(string name, double speed, double accelerationFactor)
        : base(name, speed)
    {
        AccelerationFactor = accelerationFactor;
    }

    public override double CalculateRaceTime(double distance, Weather weather)
    {
        double adjustedSpeed = AdjustSpeedForWeather(weather);  // Учитываем погодные условия
        // Используем модифицированную скорость с коэффициентом ускорения
        return distance / (adjustedSpeed * AccelerationFactor);
    }
}
