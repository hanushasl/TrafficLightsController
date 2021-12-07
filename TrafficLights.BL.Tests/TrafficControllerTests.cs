using System;
using Moq;
using System.Collections;
using System.Collections.Generic;
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
    public void StartTest()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Test that Stop method stops the system properly.
    /// </summary>
    [Fact]
    public void StopTest()
    {
      throw new NotImplementedException();
    }
  }
}
