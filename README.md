unity-ucs
=========

Universal GUI co-ordinate system for Unity 3D.

This is an early implementation of universal OpenGL style screen co-ordinates for Unity GUI.  It provides conversion functions for X and Y co-ordinates from -1.0 to 1.0 into 2D screen space, allowing you to generate GUIs more or less independent of the screen resolution.

A simple example to draw a box in the center of the screen on all resolutions would be:

``
GUI.Box (UCS.ConvertRect(new Rect(-1.0f, -1.0f, 2.0f, 2.0f)), "Test");
``

## Perfect Squares

This code attempts to compensate for differences in aspect ratios automatically, but provides a minimum of 2 units on each axis with 0.0x0.0 being the center of the screen.  You can get the actual full available screenspace using ``GetWidth()`` and ``GetHeight()``.

So for instance on a 320x480 screen, this will return 2.0 and 3.0 respectively, meaning you can place objects from -1.5f on the Y axis.

Hopefully that makes sense!
