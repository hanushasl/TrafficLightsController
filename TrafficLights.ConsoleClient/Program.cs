﻿using System;
using System.Collections.Generic;
using TrafficLights.BL;

namespace TrafficLights.ConsoleClient
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome in traffic lights control system!!!");
      Console.WriteLine("===========================================");

      // construct traffic intersection system
      ITrafficIntersectionSystem tis = new TrafficIntersectionSystem();

      // construct state transitions and system state machine
      IDictionary<StateTransition, TrafficState> transitions = new Dictionary<StateTransition, TrafficState>
      {
        { new StateTransition(TrafficState.Reset, TransitionCommand.T0), TrafficState.S0},
        { new StateTransition(TrafficState.S0, TransitionCommand.T1), TrafficState.S1},
        { new StateTransition(TrafficState.S1, TransitionCommand.T2), TrafficState.S2},
        { new StateTransition(TrafficState.S2, TransitionCommand.T3), TrafficState.S3},
        { new StateTransition(TrafficState.S3, TransitionCommand.T0), TrafficState.S0}
      };
      IStateMachine sm = new StateMachine(transitions, TrafficState.S0);

      // construct state durations look-up table
      const int ResetDuration = 10_000;
      const int TrafficRunning = 30_000;
      const int TrafficStopping = 3_000;
      Dictionary<TrafficState, int> sd = new Dictionary<TrafficState, int>
      {
        { TrafficState.Reset, ResetDuration },
        { TrafficState.S0, TrafficRunning },
        { TrafficState.S1, TrafficStopping },
        { TrafficState.S2, TrafficRunning },
        { TrafficState.S3, TrafficStopping },
      };

      // construct system controller
      ITrafficController controller = new TrafficController(tis, sm, sd);
    }
  }
}
