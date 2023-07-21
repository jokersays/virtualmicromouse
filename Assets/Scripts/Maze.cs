using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    private MazeCell[,] maze;
    public int mazeSize;

    public void startMaze()
    {
        maze = new MazeCell[mazeSize,mazeSize];
        for (int row = 0; row < mazeSize; row++)
        {
            for (int column = 0; column < mazeSize; column++)
            {
                maze[row, column] = new MazeCell(row, column);
            }
        }
        
        GenerateMaze();
        //print maze in log
        for (int row = 0; row < mazeSize; row++)
        {
             string rowmsg = "|";
            for (int column = 0; column < mazeSize; column++)
            {
                if (maze[row, column].wallBottom)
                {
                    rowmsg += "_";
                }
                else
                {
                    rowmsg += " ";
                }

                if (maze[row, column].wallRight)
                {
                    rowmsg += "|";
                }
                else
                {
                    rowmsg += " ";
                }
            }

            Debug.Log(rowmsg);
            
        }
        
    }

    private void GenerateMaze()
    {
        Debug.Log("start GenerateMaze");
        HandleCell(maze[0,0]);
    }

    private void HandleCell(MazeCell cell)
    {
        Debug.Log("start HandleCell for cell " + cell.row + ";" + cell.column);
        cell.visited = true;

        while (GetNeighborNotVisited(cell, out MazeCell nextCell))
        {
            RemoveWallsBetweenCells(cell, nextCell);
            HandleCell(nextCell);
        }
    }

    private bool GetNeighborNotVisited (MazeCell currentCell, out MazeCell nextCell)
    {
        Debug.Log("start GetNeighborNotVisited for cell " +currentCell.row +";" +currentCell.column);
        List<MazeCell> notVisitedNeighbors = new List<MazeCell>();
        //check upper cell
        if ((currentCell.row + 1) < mazeSize && !maze[currentCell.row+1, currentCell.column].visited)
        {
            notVisitedNeighbors.Add(maze[currentCell.row + 1, currentCell.column]);
            Debug.Log("GetNeighborNotVisited - added upper cell");
        }
        
        //check lower cell
        if (0 <= (currentCell.row - 1) && !maze[currentCell.row-1, currentCell.column].visited)
        {
            notVisitedNeighbors.Add(maze[currentCell.row - 1, currentCell.column]);
            Debug.Log("GetNeighborNotVisited - added lower cell");
        }

        //check right cell
        if ((currentCell.column + 1) < mazeSize && !maze[currentCell.row, currentCell.column+1].visited)
        {
            notVisitedNeighbors.Add(maze[currentCell.row, currentCell.column+1]);
            Debug.Log("GetNeighborNotVisited - added right cell");
        }
        //check left cell
        if (0 <= (currentCell.column - 1) && !maze[currentCell.row, currentCell.column+-1].visited)
        {
            notVisitedNeighbors.Add(maze[currentCell.row, currentCell.column-1]);
            Debug.Log("GetNeighborNotVisited - added left cell");
        }
        
        if (notVisitedNeighbors.Count == 0)
        {
            Debug.Log("all neighbors are visited");
            nextCell = null;
            return false;
        }
    
        int index = Random.Range(0, notVisitedNeighbors.Count);
        Debug.Log("next cell" + notVisitedNeighbors[index].row +", " +notVisitedNeighbors[index].column);
        nextCell = notVisitedNeighbors[index];
        return true;
    }

    private void RemoveWallsBetweenCells(MazeCell firstCell, MazeCell secondCell)
    {
        //firstCell is below secondCell
        if (firstCell.row != secondCell.row && firstCell.row==(secondCell.row-1) )
        {
            firstCell.wallTop = false;
            secondCell.wallBottom = false;
        }
        //firstCell is above secondCell
        if (firstCell.row != secondCell.row && firstCell.row==(secondCell.row+1) )
        {
            firstCell.wallBottom = false;
            secondCell.wallTop = false;
        }
        //firstCell is left of secondCell
        if (firstCell.column != secondCell.column && firstCell.column==(secondCell.column-1) )
        {
            firstCell.wallRight = false;
            secondCell.wallLeft = false;
        }
        //firstCell is right of secondCell
        if (firstCell.column != secondCell.column && firstCell.column==(secondCell.column+1) )
        {
            firstCell.wallLeft = false;
            secondCell.wallRight = false;
        }
    }
}
