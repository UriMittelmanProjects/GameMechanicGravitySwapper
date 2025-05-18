# Gravity Flip 2D Platformer

A simple 2D platformer prototype in Unity featuring dynamic gravity flipping and tight movement controls.

## Controls

- **Move Left/Right**: `A` / `D`
- **Jump**:
  - `W` to jump when gravity is pulling **downward** (normal).
  - `S` to jump when gravity is pulling **upward** (reversed).
- **Flip Gravity**: `G`

## Features

- **Gravity Flip Mechanic**: Flip the direction of gravity at any time using the `G` key.
- **Directional Jumping**: Context-sensitive jump key (`W` or `S`) based on current gravity orientation.
- **Smooth Wall Sliding**: Player naturally slides down walls without sticking.
- **Single Jump**: Jump is only available when grounded -- no infinite air jumping.

## Project Duration

This project took about **1-2 hours** to complete, including:
- Setting up player movement and physics.
- Implementing gravity reversal.
- Adding accurate ground detection and jump logic.
- Fine-tuning for wall sliding behavior and friction fixes.

## Challenges Faced

- **Jump Restriction Logic**: Preventing mid air jumping required careful state management.
- **Wall Cling Behavior**: Unity's default physics often cause the player to stick to walls; solving this required tweaking friction and applying extra downward force.
- **Gravity Contextual Controls**: Making jump keys respond differently depending on gravity direction added complexity to input logic.
