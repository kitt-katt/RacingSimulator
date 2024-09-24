namespace RacingSimulator
{
    using RacingSimulator.Models;
    using RacingSimulator.Transports;
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в симулятор гонок!");
            Console.WriteLine("Выберите тип гонки: 1 - Наземная, 2 - Воздушная, 3 - Смешанная");

            int raceTypeInput = int.Parse(Console.ReadLine());
            RaceType raceType = raceTypeInput switch
            {
                1 => RaceType.Ground,
                2 => RaceType.Air,
                3 => RaceType.Mixed,
                _ => throw new InvalidOperationException("Неверный тип гонки.")
            };


            Console.WriteLine("Введите дистанцию гонки (в условных единицах):");
            double distance = double.Parse(Console.ReadLine());

            Race race = new Race(distance, raceType);   // создаем гонку с указанными парметрами

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

            Console.WriteLine("Доступные транспортные средства:");
            for (int i = 0; i < availableTransports.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableTransports[i].Name}");
            }

            Console.WriteLine("Введите номера транспортных средств, которые хотите зарегистрировать (через запятую):");
            string[] selectedTransports = Console.ReadLine().Split(',');

            foreach (string selection in selectedTransports)
            {
                int selectedIndex = int.Parse(selection.Trim()) - 1;

                if (selectedIndex >= 0 && selectedIndex < availableTransports.Count)
                {
                    try
                    {
                        race.RegisterTransport(availableTransports[selectedIndex]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine($"{selectedIndex} - Неверный номер транспортного средства!");
                }
            }

            try
            {
                Transport winner = race.StartRace();
                Console.WriteLine($"Победитель гонки: {winner.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
