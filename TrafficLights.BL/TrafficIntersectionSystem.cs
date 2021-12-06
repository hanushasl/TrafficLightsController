namespace TrafficLights.BL
{
  public class TrafficIntersectionSystem : ITrafficIntersectionSystem
  {
    /// <inheritdoc />
    public TrafficState CurrentState { get; private set; }

    /// <inheritdoc />
    public bool SetState(TrafficState state)
    {
      CurrentState = state;
      return true;
    }
  }
}