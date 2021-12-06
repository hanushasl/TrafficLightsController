namespace TrafficLights.BL
{
  /// <summary>
  /// Traffic intersection system interface.
  ///
  /// Defines properties and operations of a traffic intersection system.
  /// </summary>
  public interface ITrafficIntersectionSystem
  {
    /// <summary>
    /// Current traffic intersection system state.
    /// </summary>
    TrafficState CurrentState { get; }

    /// <summary>
    /// Set traffic intersection system state.
    /// </summary>
    /// <param name="state">New traffic system state.</param>
    /// <returns>True if successful, false otherwise.</returns>
    bool SetState(TrafficState state);
  }
}