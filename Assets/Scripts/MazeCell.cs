using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell
{
    public int row;
    public int column;
    
    public Boolean visited;

    public Boolean wallLeft;
    public Boolean wallRight;
    public Boolean wallTop;
    public Boolean wallBottom;

    public MazeCell()
    {
        visited = false;
        wallLeft = true;
        wallRight = true;
        wallTop = true;
        wallBottom = true;
    }
    
    public MazeCell( int positionRow, int positionColumn)
    {
        row = positionRow;
        column = positionColumn;
        visited = false;
        wallLeft = true;
        wallRight = true;
        wallTop = true;
        wallBottom = true;
    }

}
