**ReadMe**

Team: 	ThreeOfAKind

``Authors: David Cordle
	 Nathan Bangal
	 Michael Troller``

Description: Implimentation of a 2D platforming Engine.

**Features that differ from standard Super Mario Brothers(Sprint six features and how to test them):**

*Added two new powerups:*
* **Super Crown**: Gives mario the ability to double jump (Called by jumping while already mid-air)
* **Gravity Orb**: Gives mario the ability to change the orientation of his own gravity (Called by pressing the ability button, x)

These powerups will spawn when mario is in a big state or higher and he hits an item block(There is a random chance to recieve a Fire Flower, Super Crown, or a Gravity Orb).

*Added an enemy powerup system:*

Enemies can now pick up all powerups(Mushrooms, FireFlowers, SuperCrown, GravityOrb, and Star). Picking an item up will cause the apearance of an enemy to change and give the enemy 
new behavior in the form of extra health, size, new physics, and better AI.

*Enemy Types:*
* **Big Enemy** (*enemies pick up either a mushroom or a fire flower*) - The enemy grows twice in size and gains an extra life similar to mario's interaction with a mushroom.  The enemy 
also recieves a basic ai boost and is able to follow Mario around instead of waiting for mario to come to him.

* **Jump Enemy** (*enemies pick up either a super crown or a gravity Orb*) - The enemy changes color to differentiate itself. When mario gets close to the enemy, the enemy will jump away 
at a fast speed when mario is attacking and when mario returns to a vulnerable position on the ground will run back to attack him. This casuses the player to have to attack 
the enemy from the right distance and to follow through with the attack to be succsesful.

* **Star Enemy** (*enemies pick up a Star*) - The enemy changes to a constantly changing color to differentiate itself from other enemies. This enemy has 
increased speed and will follow mario with the ability to jump over obstacles, forcing mario to not stop moving or else risk getting hit. Star enemies cannot take damage unless it 
is fall damage.

*To test the new enemy features, go down the very first pipe you see. this will bring you to a room to test each special type of enemy*

**Work Manifest (As of Version 2):**

* David Cordle: Implemented and designed Main mario, and associated factory functions.

* Nathan Bangal: Implemented and designed Other Objects, Powerups, and Blocks, assisted with command interface.

* Micheal Troller: Implemented and designed Sprite factory, implemented command interface, and set up the the MarioGameClass.


**Work Manifest (As of Version 3):**

* David Cordle: Adjusted mario motion states, implemented mario health states, implemented mario movement and state transitions, and planning.

* Nathan Bengal: Implemented a collision detection and worked with Michael on a collision response system.

* Michael Troller: Implemented a data-driven sprite machine, implemented a level-loader and a test level, transformed existing sprites into 
game objects, and worked with Nathan to build a collision response System.


**Work Manifest (As of Version 4.1):**

* David Cordle: Co-author for mario physics.

* Nathan Bengal: Implemented item physics, enemy physics, and block movement (bumping). Added collisions to handler. Co-author for mario physics.

* Michael Troller: Implemented the camera, camera manager, fireballs for fire mario, co-author for mario physics.


**Work Manifest (As of Version 4.2):**
* David Cordle: Refactored the Game Object Manager portion of level.cs and collision detection.

* Nathan Bengal: Refactored enemy behavior, block behavior, and collision handling.

* Michael Troller: Refactored Mario physics, mario state transitions, and mario collison responses.


**Work Manifest (As of Version 5.1):**
* David Cordle: Implemented sounds, HUD, and score system.

* Nathan Bengal: Implemented Castle, flagpole, flagpole animations, and winning the game.

* Michael Troller: Implemented hidden level.

**Work Manifest (As of Version 6.1):**
* David Cordle: Implemented new Mario power ups and their abilities, added new art for mario and powerups.

* Nathan Bengal: Worked with Michael to implement enemy power up effects, including a power state system, numerous physiscs classes, and numerous ai classes. In adition, 
added all new enemy art.

* Michael Troller: Worked with Michael to implement enemy power up effects, including a power state system, numerous physiscs classes, and numerous ai classes. In addition, 
abstracted enemies into one enemy abstract class and two subclasses handling enemy specific behavior.

Installation: executable not implimented at this time, Enter Repository for three of a kind and change it to MarioGame, From there clone the master and build/run.
Tag Name: SprintThreeInitialImplimentation

Built With: Visual Studio 2019 Enterprise.

Version: 5.1.

Liscense: For use by Authors, Graders, and The Ohio State University for grading, education, and non-commercial use only. Not to be replicated for the purposes of Commercial business or by other students under any conditions.

*Warnings to ignore:*
* CA1811 - Background objects are used when the level is loader, but they aren't explicitly ever created (no upstream callers).
* CA1819 - We were told by graders to use property instead of method, but visual studio advises a method. This only occurs for position and velocity.
* CA1812 - Basically the same as CA1811
* CA1801 - All handlers have a level parameter to make creation easy even though a couple handlers never use level
