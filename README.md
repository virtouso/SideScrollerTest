# SideScrollerTest

## General Explanation

* some feature look overengineering for simple project but needed to show to i design a flexible and testable system.


## Important Features

* used MVC to seperate logic from monobehaviours. its makes logix easier to test without play mode testing. 
(because of lack of time i could not apply MVC on all classes.)

* used MVVM  to bind UI to some live changing number like plater health to health bar. so healthbar automaticallly updates.

* used an automated level missions system. in level there are chunk of missions that new chunk run after a mission chunk ends.
it helps faster level scenario definitions. some classes derive from "BaseMission". these classes read other components to read mission is done.
on mission done they raise event on "MissionsList" and after that its descides with config what to do next.
"MissionsList" works with "Mission Manager".

* levels has 2 scenes. a logic scene that is shared between scenes and 


## Things Could Be Better