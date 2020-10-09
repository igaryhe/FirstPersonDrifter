# First Person Drifter
Dead simple first person character controller written in C# for Unity3D.

Originally compiled by @torahhorse [http://torahhorse.com]
benjamin.esposito@gmail.com and maintained by [Jack A
Perkins](https://github.com/jackaperkins/first-person-drifter). This version is
modified by Dan, substitute `Unity.Input` with `UnityEngine.InputSystem`, also
made it a package which you could easily add through package manager

## Features
First person drifter improves on Unity's default first person controller in a few ways:

- smooths mouse input
- adds optional run mode, air control, sliding on slopes
- adds head bob to camera
- adds mouse lock (and unlock with ESC)

It also comes with some optional stuffs:

- camera fade in
- right click zoom (good for looking at art and shit)
- script for resetting player if they fall below a certain height
- pause menu that handles:
    + quit game
    + field of view
    + sensitivity
    + invert mouse y axis (a lot of gamers ask 4 this)

## How To Use
Drop the `Player` prefab into a scene, get rid of the Main Camera that unity makes
for you. hit play.  if you want the pause menu (accessed by pressing ESC) drop
the `PauseMenu` prefab into the scene.  if you don't want any optional stuff, use
the `PlayerVanilla` prefab.

if you want to allow the player to run, simply tick the `Enable Running` in the
`First Person Drifter` component.

If you're getting the error 'There are 2 Audio Listeners in the scene' that
means you have another camera in the scene, probably the default one called Main
Camera. delete that.

*****************

A drifting game is a piece of art software that people walk around in for the
hell of it (see: proteus). I made this package bc i want to encourage artists &
non-programmers to make more drifting games and 2 provide users w/ controls that
behave in ways they expect.
