# BowlingScoreboard
## Description
This is a simple engine for calculation and keeping track of bowling’s scores. 
The engine is designed in accordance to event sourcing pattern. The event sourcing provides capability of keeping track of every events in the system, which fits the requirement. 
The engine consists of bowling game, scorebroker, frame and roll. The bowling game keeps track of frame score, frame bonus, rolling balls and applying of frame to the broker. The frame and roll are used as event type in order to store information about rolling ball, strike, spare as well as total score. The scorebroker keeps all closed frames applied by bowling game.  Typically if the dependency injection is used by application the scorebroker and bowling game can be registered as single instance. But only for one game a time. In case of multi games the engine should be extended so the game and events (frames) persisted and lifetimescope is used for registration.

## Test 
There are three tests in BowlingSoreboardTest, which tests basic functionality as well as gutter game and perfect game
## Demo
The BowlingScore.App is a console app, which roll the balls and display the result in the end of game.

## System Requirement
1. .Net core 3 sdk for building and running. 
2.  Visual Studio 2019 (v16.3 or later) for development  
 