using Xunit;

namespace TrafficLights.BL.Tests
{
  /// <summary>
  /// Traffic intersection system tests.
  /// </summary>
  public class TrafficIntersectionSystemTests
  {
    /// <summary>
    /// Test that SetState sets new state properly.
    /// </summary>
    [Fact]
    public void SetStateTest()
    {
      // arrange
      TrafficState expectedState = TrafficState.S0;
      ITrafficIntersectionSystem tis = new TrafficIntersectionSystem();

      // act
      tis.SetState(expectedState);

      // assert
      Assert.Equal(expectedState, tis.CurrentState);
    }
  }
}
