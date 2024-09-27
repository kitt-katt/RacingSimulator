using RacingSimulator.Models;
using RacingSimulator.Transports;

namespace RacingSimulator;

internal static class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать в симулятор гонок!");

        RaceType raceType = GetRaceTypeFromUser();
        double distance = GetRaceDistanceFromUser();
        Weather weather = GetWeatherFromUser();

        Race race = new Race(distance, raceType, weather);

        List<Transport> availableTransports = new List<Transport>
        {
            new BabaYaga(),
            new Broom(),
            new Boots(),
            new PumpkinCarriage(),
            new Carpet(),
            new HutOnChickenLegs(),
            new Centaur(),
            new FlyingShip()
        };

        RegisterTransportsForRace(race, availableTransports);

        try
        {
            DisplayRaceResults(race);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // Получение типа гонки
    static RaceType GetRaceTypeFromUser()
    {
        while (true)
        {
            Console.WriteLine("Выберите тип гонки: 1 - Наземная, 2 - Воздушная, 3 - Смешанная");
            if (int.TryParse(Console.ReadLine(), out int raceTypeInput) && raceTypeInput >= 1 && raceTypeInput <= 3)
            {
                return raceTypeInput switch
                {
                    1 => RaceType.Ground,
                    2 => RaceType.Air,
                    3 => RaceType.Mixed,
                    _ => throw new InvalidOperationException("Неверный тип гонки.")
                };
            }
            else
            {
                Console.WriteLine("Неверный ввод. Попробуйте снова.");
            }
        }
    }

    // Получение дистанции гонки
    static double GetRaceDistanceFromUser()
    {
        while (true)
        {
            Console.WriteLine("Введите дистанцию гонки (в условных единицах):");
            if (double.TryParse(Console.ReadLine(), out double distance) && distance > 0)
            {
                return distance;
            }
            else
            {
                Console.WriteLine("Неверный ввод. Дистанция должна быть положительным числом. Попробуйте снова.");
            }
        }
    }

    // Получение погодных условий
    static Weather GetWeatherFromUser()
    {
        while (true)
        {
            Console.WriteLine("Выберите погодные условия: 1 - Солнечно, 2 - Дождь, 3 - Ветрено, 4 - Туман, 5 - Шторм");
            if (int.TryParse(Console.ReadLine(), out int weatherInput) && weatherInput >= 1 && weatherInput <= 5)
            {
                WeatherType weatherType = weatherInput switch
                {
                    1 => WeatherType.Sunny,
                    2 => WeatherType.Rainy,
                    3 => WeatherType.Windy,
                    4 => WeatherType.Foggy,
                    _ => throw new InvalidOperationException("Неверный тип погоды.")
                };
                return new Weather(weatherType);
            }
            else
            {
                Console.WriteLine("Неверный ввод. Попробуйте снова.");
            }
        }
    }

    // Регистрация транспортных средств
    static void RegisterTransportsForRace(Race race, List<Transport> availableTransports)
    {
        Console.WriteLine("Доступные транспортные средства:");
        for (int i = 0; i < availableTransports.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableTransports[i].Name}");
        }

        while (true)
        {
            Console.WriteLine("Введите номера транспортных средств, которые хотите зарегистрировать (через запятую):");
            string[] selectedTransports = Console.ReadLine().Split(',');

            bool registrationSuccessful = true;

            foreach (string selection in selectedTransports)
            {
                if (int.TryParse(selection.Trim(), out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= availableTransports.Count)
                {
                    try
                    {
                        race.RegisterTransport(availableTransports[selectedIndex - 1]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        registrationSuccessful = false;
                    }
                }
                else
                {
                    Console.WriteLine("Неверный номер транспортного средства. Попробуйте снова.");
                    registrationSuccessful = false;
                }
            }

            if (registrationSuccessful && race.ParticipantsCount > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Регистрация не удалась. Повторите ввод.");
            }
        }
    }

    // Вывод результатов гонки
    static void DisplayRaceResults(Race race)
    {
        Console.WriteLine("Результаты гонки:");

        var raceResults = race.GetRaceResults();

        foreach (var result in raceResults)
        {
            Console.WriteLine($"{result.Transport.Name}: {result.Time:F0} условных единиц времени");
        }

        Transport winner = raceResults.First().Transport;
        Console.WriteLine($"\nПобедитель гонки: {winner.Name}");
    }
}
