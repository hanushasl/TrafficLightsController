using System;
using TrafficLights.BL;

namespace TrafficLights.ConsoleClient
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome in traffic lights control system!!!");
      Console.WriteLine("===========================================");

      ITrafficIntersectionSystem tis = new TrafficIntersectionSystem();
    }
  }
}
