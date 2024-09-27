// Летучий корабль:


namespace RacingSimulator.Transports;


using RacingSimulator.Models;

public class FlyingShip : AirTransport
{
    public FlyingShip() : base("Летучий корабль", 30, 1.3) { }
}