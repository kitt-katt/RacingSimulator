// Модель гонки, которая будет управлять соревнованиями.

namespace RacingSimulator.Models;


public class Race
{
    public double Distance { get; }
    public RaceType Type { get; }
    public Weather Weather { get; }

    private List<Transport> _participants = new List<Transport>();

    public Race(double distance, RaceType type, Weather weather)
    {
        Distance = distance;
        Type = type;
        Weather = weather;
    }

    public void RegisterTransport(Transport transport)
    {
        if ((Type == RaceType.Ground && transport is GroundTransport) ||
            (Type == RaceType.Air && transport is AirTransport) ||
            Type == RaceType.Mixed)
        {
            _participants.Add(transport);
        }
        else
        {
            throw new InvalidOperationException($"Транспорт {transport.Name} не может участвовать в гонке типа {Type}.");
        }
    }

    public Transport StartRace()
    {
        if (_participants.Count == 0)
        {
            throw new InvalidOperationException("Невозможно начать гонку без участников.");
        }

        return _participants.OrderBy(t => t.CalculateRaceTime(Distance, Weather)).First();
    }
}
