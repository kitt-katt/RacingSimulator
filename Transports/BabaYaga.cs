// Ступа Бабы Яги


namespace RacingSimulator.Transports;


using RacingSimulator.Models;

public class BabaYaga : GroundTransport
{
    public BabaYaga() : base("Ступа Бабы Яги", 10, 5, 2) { }

    public override double CalculateRaceTime(double distance, Weather weather)
    {
        double adjustedSpeed = AdjustSpeedForWeather(weather);  // Модифицируем скорость с учетом погоды
        return distance / adjustedSpeed;
    }
}
