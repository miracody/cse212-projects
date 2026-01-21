using System;
using System.Collections.Generic;

public class Maze
{
    // Directions: [0] = Left, [1] = Right, [2] = Up, [3] = Down
    private readonly Dictionary<(int, int), bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<(int, int), bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    public void MoveLeft()
    {
        var directions = _mazeMap[(_currX, _currY)];
        if (!directions[0] || !_mazeMap.ContainsKey((_currX - 1, _currY)))
            throw new InvalidOperationException("Can't go that way!");
        _currX -= 1;
    }

    public void MoveRight()
    {
        var directions = _mazeMap[(_currX, _currY)];
        if (!directions[1] || !_mazeMap.ContainsKey((_currX + 1, _currY)))
            throw new InvalidOperationException("Can't go that way!");
        _currX += 1;
    }

    public void MoveUp()
    {
        var directions = _mazeMap[(_currX, _currY)];
        if (!directions[2] || !_mazeMap.ContainsKey((_currX, _currY + 1)))
            throw new InvalidOperationException("Can't go that way!");
        _currY += 1;
    }
public void MoveDown()
{
    var directions = _mazeMap[(_currX, _currY)];
    // directions[3] should represent "down"
    if (!directions[3] || !_mazeMap.ContainsKey((_currX, _currY + 1)))
        throw new InvalidOperationException("Can't go that way!");
    _currY += 1;  // ✅ moving down increases Y
}


    /// <summary>
    /// Returns the current status of the maze (location).
    /// Must match the test expectation exactly.
    /// </summary>
    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
