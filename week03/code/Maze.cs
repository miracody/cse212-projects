using System;
using System.Collections.Generic;

public class Maze
{
    private readonly Dictionary<(int, int), bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<(int, int), bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Check to see if you can move left. If you can, then move. If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        var directions = _mazeMap[(_currX, _currY)];
        if (!directions[0])
            throw new InvalidOperationException("Can't go that way!");
        _currX -= 1;
    }

    /// <summary>
    /// Check to see if you can move right. If you can, then move. If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        var directions = _mazeMap[(_currX, _currY)];
        if (!directions[1])
            throw new InvalidOperationException("Can't go that way!");
        _currX += 1;
    }

    /// <summary>
    /// Check to see if you can move up. If you can, then move. If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        var directions = _mazeMap[(_currX, _currY)];
        if (!directions[2])
            throw new InvalidOperationException("Can't go that way!");
        _currY += 1;
    }

    /// <summary>
    /// Check to see if you can move down. If you can, then move. If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        var directions = _mazeMap[(_currX, _currY)];
        if (!directions[3])
            throw new InvalidOperationException("Can't go that way!");
        _currY -= 1;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
