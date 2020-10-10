# First Person Drifter
Dead simple first person character controller for Unity3D.

Originally compiled by [@torahhorse](http://torahhorse.com) and maintained by
[Jack A Perkins](https://github.com/jackaperkins/first-person-drifter). This
version substitutes `Unity.Input` with `UnityEngine.InputSystem`, also made it
compatible with package manager.

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
    + invert mouse y axis
    
This package also has controller support built-in.

## How To Use
- Drop the `Player` prefab into a scene and delete the default `Main Camera`
- If you don't want any optional stuff, use the `PlayerVanilla` prefab
- If you want to allow the player to run, simply tick the `Enable Running` in
the `First Person Drifter` component.
- If you want to use the pause menu, drag the `Menu` prefab into you scene. Make
sure to create a `Canvas` in advance, and convert the `EventSystem` into using
the new Input Systum.
- Disable the `FadeIn` in `Menu` if you don't want the fade in animation at the
beginning.
