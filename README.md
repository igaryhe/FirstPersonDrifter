# First Person Drifter
Code compiled by @torahhorse [http://torahhorse.com] benjamin.esposito@gmail.com

Git version maintained by Jack A Perkins

Modified by Dan, substitute `Unity.Input` with `UnityEngine.InputSystem`

dead simple first person character controller written in c# for unity3d
requires
first person drifter improves on unitys default first person controller in a few ways:

- smooths mouse input
- adds optional run mode, air control, sliding on slopes
- adds head bob to camera
- adds mouse lock (and unlock with ESC)

it also comes with some optional stuff that i want you to use in your drifting game

- camera fade in
- right click zoom (good for looking at art and shit)
- script for resetting player if they fall below a certain height
- pause menu that handles:
    + quit game
    + field of view
    + sensitivity
    + invert mouse y axis (a lot of gamers ask 4 this)

## How To Use
drop the Player prefab into a scene, get rid of the Main Camera that unity makes for you. hit play.
if you want the pause menu (accessed by pressing ESC) drop the PauseMenu prefab into the scene.
if you don't want any optional stuff, use the PlayerVanilla prefab.

if you want to allow the player to run, you need to go to Edit > Project Settings > Input
and add a new entry named "Run". change the 'positive button' to whatever you like, i recommend "left shift"

if you're getting the error 'There are 2 Audio Listeners in the scene' that means you have another camera
in the scene, probably the default one called Main Camera. delete that.

*****************

a drifting game is a piece of art software that people walk around in for the hell of it (see: proteus)
i made this package bc i want to encourage artists & non-programmers to make more drifting games
and 2 provide users w/ controls  that behave in waays they expect

you can use this for whatever purposes, commercial or noncommercial.
like all my endeavors, i stole most of the code from ppl smarter than me