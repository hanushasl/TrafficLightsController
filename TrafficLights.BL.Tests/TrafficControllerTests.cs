using System;
using Moq;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace TrafficLights.BL.Tests
{
  /// <summary>
  /// Traffic controller test
  /// </summary>
  public class TrafficControllerTests
  {
    /// <summary>
    /// Test that controller gets initialized correctly.
    /// </summary>
    [Fact]
    public void InitializationTest()
    {
      // arrange
      Mock<IDictionary<StateTransition, TrafficState>> transitions =
        new Mock<IDictionary<StateTransition, TrafficState>>();
      TrafficState initialState = TrafficState.Reset;
      IStateMachine sm = new StateMachine(transitions.Object, initialState);
      ITrafficIntersectionSystem tis = new TrafficIntersectionSystem();
      Dictionary<TrafficState, int> sd = new Dictionary<TrafficState, int>
      {
        { TrafficState.Reset, 10000 },
        { TrafficState.S0, 30_000 },
        { TrafficState.S1, 3_000 },
        { TrafficState.S2, 30_000 },
        { TrafficState.S3, 3_000 },
      };

      // act
      ITrafficController controller = new TrafficController(tis, sm, sd);

      // assert
      Assert.Equal(tis, controller.TrafficIntersectionSystem);
      Assert.Equal(sm, controller.StateMachine);
    }

    /// <summary>
    /// Test that Start method starts the system properly.
    /// </summary>
    [Fact]
    public async void StartTest()
    {
      // arrange
      Mock<ITrafficIntersectionSystem> tis = new Mock<ITrafficIntersectionSystem>();
      tis.Setup(x => x.SetState(It.IsAny<TrafficState>())).Returns(true);

      TrafficState initialState = TrafficState.Reset;
      IDictionary<StateTransition, TrafficState> transitions = new Dictionary<StateTransition, TrafficState>
      {
        { new StateTransition(TrafficState.Reset, TransitionCommand.T0), TrafficState.S0 },
        { new StateTransition(TrafficState.S0, TransitionCommand.T1), TrafficState.S1 },
        { new StateTransition(TrafficState.S1, TransitionCommand.T2), TrafficState.S2 },
        { new StateTransition(TrafficState.S2, TransitionCommand.T3), TrafficState.S3 },
        { new StateTransition(TrafficState.S3, TransitionCommand.T0), TrafficState.S0 }
      };
      IStateMachine sm = new StateMachine(transitions, initialState);

      const int ResetDuration = 10;
      const int TrafficRunning = 30;
      const int TrafficStopping = 3;
      Dictionary<TrafficState, int> sd = new Dictionary<TrafficState, int>
      {
        { TrafficState.Reset, ResetDuration },
        { TrafficState.S0, TrafficRunning },
        { TrafficState.S1, TrafficStopping },
        { TrafficState.S2, TrafficRunning },
        { TrafficState.S3, TrafficStopping },
      };

      ITrafficController controller = new TrafficController(tis.Object, sm, sd);

      // act
      controller.Start();
      RunningState actualState = controller.State;
      await Task.Delay(1000);
      controller.Stop();

      // assert
      Assert.Equal(RunningState.Running, actualState);
    }

    /// <summary>
    /// Test that Stop method stops the system properly.
    /// </summary>
    [Fact]
    public void StopTest()
    {
      // arrange
      Mock<ITrafficIntersectionSystem> tis = new Mock<ITrafficIntersectionSystem>();
      tis.Setup(x => x.SetState(It.IsAny<TrafficState>())).Returns(true);

      TrafficState initialState = TrafficState.Reset;
      IDictionary<StateTransition, TrafficState> transitions = new Dictionary<StateTransition, TrafficState>
      {
        { new StateTransition(TrafficState.Reset, TransitionCommand.T0), TrafficState.S0 },
        { new StateTransition(TrafficState.S0, TransitionCommand.T1), TrafficState.S1 },
        { new StateTransition(TrafficState.S1, TransitionCommand.T2), TrafficState.S2 },
        { new StateTransition(TrafficState.S2, TransitionCommand.T3), TrafficState.S3 },
        { new StateTransition(TrafficState.S3, TransitionCommand.T0), TrafficState.S0 }
      };
      IStateMachine sm = new StateMachine(transitions, initialState);

      const int ResetDuration = 10;
      const int TrafficRunning = 30;
      const int TrafficStopping = 3;
      Dictionary<TrafficState, int> sd = new Dictionary<TrafficState, int>
      {
        { TrafficState.Reset, ResetDuration },
        { TrafficState.S0, TrafficRunning },
        { TrafficState.S1, TrafficStopping },
        { TrafficState.S2, TrafficRunning },
        { TrafficState.S3, TrafficStopping },
      };

      ITrafficController controller = new TrafficController(tis.Object, sm, sd);

      // act
      controller.Start();
      Assert.Equal(RunningState.Running, controller.State);
      controller.Stop();
      RunningState actualState = controller.State;

      // assert
      Assert.Equal(RunningState.Stopped, actualState);
    }
  }
}
