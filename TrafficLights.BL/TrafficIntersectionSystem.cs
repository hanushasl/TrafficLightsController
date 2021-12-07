using System;
using System.Diagnostics;

namespace TrafficLights.BL
{
  public class TrafficIntersectionSystem : ITrafficIntersectionSystem
  {
    /// <inheritdoc />
    public TrafficState CurrentState { get; private set; }

    // stopwatch for logging purposes
    private readonly Stopwatch _stopWatch = new Stopwatch();

    public TrafficIntersectionSystem()
    {
      _stopWatch.Start();
    }

    /// <inheritdoc />
    public bool SetState(TrafficState state)
    {
      CurrentState = state;
      Console.WriteLine($"State changed to: {state} after {_stopWatch.Elapsed.TotalSeconds:f0} seconds.");
      _stopWatch.Restart();
      return true;
    }
  }
}