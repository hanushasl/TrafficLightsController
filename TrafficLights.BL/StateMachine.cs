using System;
using System.Collections.Generic;

namespace TrafficLights.BL
{
  public class StateMachine : IStateMachine
  {
    /// <inheritdoc />
    public TrafficState CurrentState { get; private set; }

    /// <inheritdoc />
    public IDictionary<StateTransition, TrafficState> StateTransitions { get; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="transitions">State transitions table.</param>
    /// <param name="initialState">Initial state.</param>
    public StateMachine(IDictionary<StateTransition, TrafficState> transitions, TrafficState initialState)
    {
      StateTransitions = transitions;
      CurrentState = initialState;
    }

    /// <inheritdoc />
    public TrafficState GetNextState(TransitionCommand command)
    {
      StateTransition transition = new StateTransition(CurrentState, command);
      if (!StateTransitions.TryGetValue(transition, out var nextState))
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
