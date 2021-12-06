using System;
using System.Collections.Generic;
using Xunit;

namespace TrafficLights.BL.Tests
{
  public class StateMachineTests
  {
    #region Test class memebers
    // member fields
    private IDictionary<StateTransition, TrafficState> DummyTransitions;

    // helper functions
    IDictionary<StateTransition, TrafficState> GetDummyStateTransitions()
    {
      IDictionary<StateTransition, TrafficState> transitions = new Dictionary<StateTransition, TrafficState>
      {
        { new StateTransition(TrafficState.S0, TransitionCommand.T1), TrafficState.S1 },
        { new StateTransition(TrafficState.S1, TransitionCommand.T2), TrafficState.S2 },
        { new StateTransition(TrafficState.S2, TransitionCommand.T3), TrafficState.S3 },
        { new StateTransition(TrafficState.S3, TransitionCommand.T0), TrafficState.S0 },
      };

      return transitions;
    }
    #endregion
    /// <summary>
    /// Test that CurrentState property is initialized properly.
    /// </summary>
    [Fact]
    public void CurrentStateTest()
    {
      // arrange
      var transitions = GetDummyStateTransitions();
      IStateMachine sm = new StateMachine(transitions, TrafficState.S0);

      // assert
      Assert.Equal(TrafficState.S0, sm.CurrentState);
    }

    /// <summary>
    /// Test that state machine returns next state properly (without changing CurrentState).
    /// </summary>
    [Fact]
    public void GetNextStateTest()
    {
      // arrange
      var transitions = GetDummyStateTransitions();
      IStateMachine sm = new StateMachine(transitions, TrafficState.S0);

      // act
      TrafficState actualNextState = sm.GetNextState(TransitionCommand.T1);

      // assert
      Assert.Equal(TrafficState.S1, actualNextState);
    }

    [Fact]
    public void GetNextStateThrowsExceptionUponInvalidTransitionTest()
    {
      // arrange
      var transitions = new Dictionary<StateTransition, TrafficState>();
      IStateMachine sm = new StateMachine(transitions, TrafficState.S0);

      // act

      // assert
      Assert.Throws<InvalidOperationException>(() => sm.GetNextState(TransitionCommand.T1));
    }

    /// <summary>
    /// Test that state machine updates CurrentState properly.
    /// </summary>
    [Fact]
    public void MoveNextStateTest()
    {
      // arrange
      var transitions = GetDummyStateTransitions();
      IStateMachine sm = new StateMachine(transitions, TrafficState.S0);

      // act
      TrafficState actualNextState = sm.MoveNextState(TransitionCommand.T1);

      // assert
      Assert.Equal(TrafficState.S1, actualNextState);
      Assert.Equal(TrafficState.S1, sm.CurrentState);
    }
  }
}
