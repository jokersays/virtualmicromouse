# newmouse v24
## shift godot
## pixel graphics
- 16x16 squares
  - 18x18 cm, 1.2 cm wall --> 16.8 cm floor
  - 18 / 1.2 = 15 --> "half-tile" wall, resp. 30x30 tiles
  - 1.2 cm sq. posts --> 4 tiles
  - 1 tile eq .6 cm sq
  - Start in corner: top (north) open, limit west & south, wall east
## misc


# virtualmicromouse CW23

## first steps
- DONE vorbereitung
  - installation (unity, accounts)
  - beispiel ansehen --> gemeinsam!
  - projekt anlegen & repo initialisieren
- DONE grober plan fuer 1. prototyp
  - labyrinth
  - maus
    - 2D top down movement: https://stuartspixelgames.com/2018/06/24/simple-2d-top-down-movement-unity-c/
  - menue?
    - start button --> maus läuft los
  - grid-based movement
  - 90° turns

## refinement 1
- DONE better movement
- DONE automatic (complete) run
- DONE ui controls

## refinement 2
- verschiedene levels
  - DONE vorgegeben
  - REF3 dynamisch
- DONE maus-auto-select
- DONE ziel definieren (und erkennen)
- DONE player prefab

## refinement 3
- DONE dynamic levels
  - maze generation --> binary 2d array
  - tilemap generation from array
