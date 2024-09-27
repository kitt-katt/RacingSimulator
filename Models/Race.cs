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

        public int ParticipantsCount => _participants.Count;

        public List<(Transport Transport, double Time)> GetRaceResults()
        {
            return _participants
                .Select(t => (t, t.CalculateRaceTime(Distance, Weather)))
                .OrderBy(result => result.Item2)  // Сортируем по времени
                .ToList();
        }
    }
