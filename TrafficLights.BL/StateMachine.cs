using System;
using System.Collections.Generic;

namespace TrafficLights.BL
{
  public class StateMachine : IStateMachine
  {
    /// <inheritdoc />
    public TrafficState CurrentState { get; private set; }

    // state transitions
    private readonly IDictionary<StateTransition, TrafficState> _transitions;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="transitions">State transitions table.</param>
    /// <param name="initialState">Initial state.</param>
    public StateMachine(IDictionary<StateTransition, TrafficState> transitions, TrafficState initialState)
    {
      _transitions = transitions;
      CurrentState = initialState;
    }


    /// <inheritdoc />
    public TrafficState GetNextState(TransitionCommand command)
    {
      StateTransition transition = new StateTransition(TrafficState.S0, TransitionCommand.T1);
      if (!_transitions.TryGetValue(transition, out var nextState))
      {
        throw new InvalidOperationException($"Invalid transition: {CurrentState} -> {command}.");
      }

      return nextState;
    }

    /// <inheritdoc />
    public TrafficState MoveNextState(TransitionCommand command)
    {
      CurrentState = GetNextState(command);

      return CurrentState;
    }
  }
}
