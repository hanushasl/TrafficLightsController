namespace TrafficLights.BL
{
  /// <summary>
  /// State transition interface.
  /// </summary>
  public interface IStateTransition
  {
    /// <summary>
    /// Initial state of the transition.
    /// </summary>
    TrafficState InitialState { get; }

    /// <summary>
    /// Transition command of the transition.
    /// </summary>
    TransitionCommand Command { get; }
  }
}