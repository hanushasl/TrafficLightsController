namespace TrafficLights.BL
{
  /// <summary>
  /// State machine interface.
  /// </summary>
  public interface IStateMachine
  {
    /// <summary>
    /// Current state.
    /// </summary>
    TrafficState CurrentState { get; }

    /// <summary>
    /// Get next state based on current state and transition command.
    /// </summary>
    /// <param name="command">Transition command.</param>
    /// <returns>Next state.</returns>
    TrafficState GetNextState(TransitionCommand command);

    /// <summary>
    /// Move state machine to the next state based on current state and transition command.
    /// </summary>
    /// <param name="command">Transition command.</param>
    /// <returns>New current state.</returns>
    TrafficState MoveNextState(TransitionCommand command);
  }
}