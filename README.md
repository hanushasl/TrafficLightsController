# TrafficLightsController
Simple traffic lights controller is supposed to control a simple traffic intersection.

## Requirements:
Intersection has four traffic directions:
1. North
2. West
3. South
4. East

Cars are comming from all directions. The goal is to control the traffic lights so that there are no collisions.
Traffic lights currently only have red and green, but this might change as well as the timings of the states.

As a simplest solution the following was chosen:
Two opposite traffic directions are always enabled at the same time, the other two (perpendicular) are stopped.
Thus, there are five different states of the traffic lights system:

```
Reset - All directions stopped.
S0 - North-South directions enabled, East-West stopped.
S1 - North-South directions stopping, East-West stopped.
S2 - North-South directions stopped, East-West enabled.
S3 - North-South directions stopped, East-West stopping.
```

## Sequence diagram

The following sequence diagram describes roughly how the system workflow works. You may find the source Visio file in the Design folder of this repository.

![SimpleTrafficLightsSystemDiagrams_Sequence](https://user-images.githubusercontent.com/67586713/145014698-22038f84-d7ac-4c15-841a-947b72b4b170.png)
