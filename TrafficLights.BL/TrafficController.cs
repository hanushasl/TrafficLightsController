namespace TrafficLights.BL
{
  public class TrafficController : ITrafficController
  {
    /// <inheritdoc />
    public ITrafficIntersectionSystem TrafficIntersectionSystem { get; }

    /// <inheritdoc />
    public IStateMachine StateMachine { get; }

    /// <inheritdoc />
    public bool Start()
    {
      throw new System.NotImplementedException();
    }

    /// <inheritdoc />
    public bool Stop()
    {
      throw new System.NotImplementedException();
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="trafficIntersectionSystem">Traffic intersection system to control.</param>
    /// <param name="stateMachine">Traffic intersection system state machine.</param>
    public TrafficController(ITrafficIntersectionSystem trafficIntersectionSystem, IStateMachine stateMachine)
    {
      TrafficIntersectionSystem = trafficIntersectionSystem;
      StateMachine = stateMachine;
    }
  }
}
