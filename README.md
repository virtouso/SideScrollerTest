# SideScrollerTest

## General Explanation

* some feature look overengineering for simple project but needed to show to i design a flexible and testable system.
* Input       Arrows: Horizontal Move                Right-Shift: Shooting       Space: Jump

## Important Features

* used MVC to seperate logic from monobehaviours. its makes logix easier to test without play mode testing. 
(because of lack of time i could not apply MVC on all classes.)

* used MVVM  to bind UI to some live changing number like plater health to health bar. so healthbar automaticallly updates.

* used an automated level missions system. in level there are chunk of missions that new chunk run after a mission chunk ends.
it helps faster level scenario definitions. some classes derive from "BaseMission". these classes read other components to read mission is done.
on mission done they raise event on "MissionsList" and after that its descides with config what to do next.
"MissionsList" works with "Mission Manager".

* levels has 2 scenes. a logic scene that is shared between scenes and  Level that has structure

* using dependency injection to resolving dependencies.

* using feature based namespaces to add more cohesion to the code.

* object pooling for bullets

* a dynamic system for applying damage for defferent types of enemies and cheching friendly fire.

* enemies use a simple state machine

* By Using Build Config Before PlayMode you can swith between Keyboard and GamePad


## Things Could Be Better

* Wanted to add graphics but didnt have enough time
* for some parts it was better to use better architecture or add "Signal Bus" architecture for indirect dependency and more flexiblity.
* moving some "serializefield" properties that are configuation and dont change to "ScriptableObject For Cleaner Structure"

