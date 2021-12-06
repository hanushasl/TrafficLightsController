namespace TrafficLights.BL
{
  public class StateTransition : IStateTransition
  {
    /// <inheritdoc />
    public TrafficState InitialState { get; }

    /// <inheritdoc />
    public TransitionCommand Command { get; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="initialState">Initial state of the transition.</param>
    /// <param name="command">Transition command.</param>
    public StateTransition(TrafficState initialState, TransitionCommand command)
    {
      InitialState = initialState;
      Command = command;
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
      return obj is StateTransition other && other.InitialState == this.InitialState &&
             other.Command == this.Command;
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
      return 17 + 31 * InitialState.GetHashCode() + 31 * Command.GetHashCode();
    }
  }
}
