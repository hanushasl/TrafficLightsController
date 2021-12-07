namespace TrafficLights.BL
{
  /// <summary>
  /// Running state enum.
  /// </summary>
  public enum RunningState
  {
    Running,
    Stopped
  }

  /// <summary>
  /// Traffic controller interface.
  ///
  /// Traffic controller controls the traffic intersection system.
  /// The controller is supposed to be the only place that modifies traffic
  /// intersection states.
  /// </summary>
  public interface ITrafficController
  {
    /// <summary>
    /// Traffic intersection system the controller controls.
    /// </summary>
    ITrafficIntersectionSystem TrafficIntersectionSystem { get; }

    /// <summary>
    /// Traffic intersection system state machine.
    /// </summary>
    IStateMachine StateMachine { get; }

    /// <summary>
    /// Running state of the controller.
    /// </summary>
    RunningState State { get; }

    /// <summary>
    /// Start traffic intersection system.
    /// </summary>
    /// <returns>True if the system was successfully started. False otherwise.</returns>
    bool Start();

    /// <summary>
    /// Stop traffic intersection system.
    /// </summary>
    /// <returns>True if the system was successfully stopped. False otherwise.</returns>
    bool Stop();
  }
}