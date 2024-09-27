namespace RacingSimulator.Models;
    

public class Weather
{
    public WeatherType Type { get; }

    public Weather(WeatherType type)
    {
        Type = type;
    }

    // Определим влияние погоды на скорость транспорта в зависимости от его типа
    public double GetSpeedModifier(Transport transport)
    {
        return transport switch
        {
            GroundTransport => GetGroundTransportModifier(),
            AirTransport => GetAirTransportModifier(),
            _ => 1.0
        };
    }

    private double GetGroundTransportModifier()
    {
        return Type switch
        {
            WeatherType.Sunny => 1.0,   // Солнечно - никаких изменений
            WeatherType.Rainy => 0.7,   // Дождь снижает скорость
            WeatherType.Windy => 0.9,   // Ветер немного снижает скорость
            WeatherType.Foggy => 0.5,   // Туман снижает скорость из-за плохой видимости
            _ => 1.0
        };
    }

    private double GetAirTransportModifier()
    {
        return Type switch
        {
            WeatherType.Sunny => 1.0,   // Солнечно - никаких изменений
            WeatherType.Rainy => 1.0,   // Дождь - никаких изменений
            WeatherType.Windy => 0.2,   // Сильный ветер замедляет воздушные ТС
            WeatherType.Foggy => 0.5,   // Туман снижает скорость из-за плохой видимости
            _ => 1.0
        };
    }
}
