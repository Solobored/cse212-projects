using System;
using System.Collections.Generic;

/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out bool[] movements))
        {
            if (movements[0]) // Index 0 is 'left'
            {
                int nextX = _currX - 1;
                // Check if the destination is within the maze boundaries
                if (_mazeMap.ContainsKey((nextX, _currY)))
                {
                    _currX = nextX;
                }
                else
                {
                    // Moving left is allowed from current cell, but destination is out of bounds
                    throw new InvalidOperationException("Can't go that way!");
                }
            }
            else
            {
                // Wall in the left direction from current cell
                throw new InvalidOperationException("Can't go that way!");
            }
        }
        else
        {
            // Current location not found in map, treat as a wall
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out bool[] movements))
        {
            if (movements[1]) // Index 1 is 'right'
            {
                int nextX = _currX + 1;
                // Check if the destination is within the maze boundaries
                if (_mazeMap.ContainsKey((nextX, _currY)))
                {
                    _currX = nextX;
                }
                else
                {
                    // Moving right is allowed from current cell, but destination is out of bounds
                    throw new InvalidOperationException("Can't go that way!");
                }
            }
            else
            {
                // Wall in the right direction from current cell
                throw new InvalidOperationException("Can't go that way!");
            }
        }
        else
        {
            // Current location not found in map, treat as a wall
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out bool[] movements))
        {
            if (movements[2]) // Index 2 is 'up'
            {
                int nextY = _currY - 1; // Fixed: up decreases y
                // Check if the destination is within the maze boundaries
                if (_mazeMap.ContainsKey((_currX, nextY)))
                {
                    _currY = nextY;
                }
                else
                {
                    // Moving up is allowed from current cell, but destination is out of bounds
                    throw new InvalidOperationException("Can't go that way!");
                }
            }
            else
            {
                // Wall in the up direction from current cell
                throw new InvalidOperationException("Can't go that way!");
            }
        }
        else
        {
            // Current location not found in map, treat as a wall
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out bool[] movements))
        {
            if (movements[3]) // Index 3 is 'down'
            {
                int nextY = _currY + 1; // Fixed: down increases y
                // Check if the destination is within the maze boundaries
                if (_mazeMap.ContainsKey((_currX, nextY)))
                {
                    _currY = nextY;
                }
                else
                {
                    // Moving down is allowed from current cell, but destination is out of bounds
                    throw new InvalidOperationException("Can't go that way!");
                }
            }
            else
            {
                // Wall in the down direction from current cell
                throw new InvalidOperationException("Can't go that way!");
            }
        }
        else
        {
            // Current location not found in map, treat as a wall
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
