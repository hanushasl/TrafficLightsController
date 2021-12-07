using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TrafficLights.BL
{
  public class TrafficController : ITrafficController
  {
    /// <inheritdoc />
    public ITrafficIntersectionSystem TrafficIntersectionSystem { get; }

    /// <inheritdoc />
    public IStateMachine StateMachine { get; }

    // background worker running the control routine
    private BackgroundWorker _bw = new BackgroundWorker();

    // state durations
    private Dictionary<TrafficState, int> _stateDurations;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="trafficIntersectionSystem">Traffic intersection system to control.</param>
    /// <param name="stateMachine">Traffic intersection system state machine.</param>
    /// <param name="stateDurations">State durations look-up table.</param>
    public TrafficController(ITrafficIntersectionSystem trafficIntersectionSystem, IStateMachine stateMachine, Dictionary<TrafficState, int> stateDurations)
    {
      // initialize members
      TrafficIntersectionSystem = trafficIntersectionSystem;
      StateMachine = stateMachine;
      _stateDurations = stateDurations;

      // setup background worker
      _bw.WorkerSupportsCancellation = true;
      _bw.DoWork += ControlRoutine;
    }

    // controlling routine run by BackgroundWorker thread
    private async void ControlRoutine(object? sender, DoWorkEventArgs e)
    {
      TrafficState state = StateMachine.CurrentState;
      TransitionCommand command =
        StateMachine.StateTransitions.Keys.FirstOrDefault(x => x.InitialState == state)!.Command;
      while (!_bw.CancellationPending)
      {
        bool success = TrafficIntersectionSystem.SetState(state);
        if (!success)
        {
          throw new InvalidOperationException($"Could not set traffic intersection state {state}.");
        }

        await Task.Delay(_stateDurations[state]);

        state = StateMachine.MoveNextState(command);
      }
    }

    /// <inheritdoc />
    public bool Start()
    {
      throw new System.NotImplementedException();
    }

    /// <inheritdoc />
    public bool Stop()
    {
      throw new System.NotImplementedException();
    }
  }
}
