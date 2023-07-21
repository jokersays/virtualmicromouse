using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGeneration : MonoBehaviour
{

    private Tilemap tilemap;

    private int[,] GenerateRandomMap(int width, int height)
    {
        int[,] map = new int[width, height];
        for (int i = 0; i < map.GetUpperBound(0); i++)
        {
            for (int j = 0; j < map.GetUpperBound(1); j++)
            {
                map[i, j] = Mathf.RoundToInt(Random.value);
            }
        }
        return map;
    }

    public int xSize;
    public int ySize;

    public void Start()
    {
        //int[,] randomMap = GenerateRandomMap(xSize, ySize);
        int[,] wallMap = CalculateWallMapFromMaze();
        Tile blueBlock = Resources.Load<Tile>("block_1");
        tilemap = GetComponent<Tilemap>();

        GenerateTilemap(wallMap, tilemap, blueBlock);
        //CleanStart(tilemap, Vector3Int.zero);

    }

    private int[,] CalculateWallMapFromMaze()
    {
        //Maze maze = GetComponent<Maze>();
        //maze.startMaze();

        Maze maze = new Maze();

        // new size
        int[,] map = new int[maze.mazeSize * 3 + 1, maze.mazeSize * 3 + 1];

        // loop maze.maze
        for (int x = 0; x < maze.mazeSize; x++)
        {
            for (int y = 0; y < maze.mazeSize; y++)
            {
                int nextX = (y * 3) + 1;
                int nextY = (x * 3) + 1;
                if (maze.maze[x, y].wallLeft)
                {
                    map[nextX - 1, nextY + 2] = 1;
                    map[nextX - 1, nextY + 1] = 1;
                    map[nextX - 1, nextY - 0] = 1;
                    map[nextX - 1, nextY - 1] = 1;
                }
                if (maze.maze[x, y].wallRight)
                {
                    map[nextX + 2, nextY + 2] = 1;
                    map[nextX + 2, nextY + 1] = 1;
                    map[nextX + 2, nextY - 0] = 1;
                    map[nextX + 2, nextY - 1] = 1;
                }
                if (maze.maze[x, y].wallBottom)
                {
                    map[nextX - 1, nextY - 1] = 1;
                    map[nextX - 0, nextY - 1] = 1;
                    map[nextX + 1, nextY - 1] = 1;
                    map[nextX + 2, nextY - 1] = 1;
                }
                if (maze.maze[x, y].wallTop)
                {
                    map[nextX - 1, nextY + 2] = 1;
                    map[nextX - 0, nextY + 2] = 1;
                    map[nextX + 1, nextY + 2] = 1;
                    map[nextX + 2, nextY + 2] = 1;
                }
            }
        }

        return map;
    }

    private void CleanStart(Tilemap tilemap, Vector3Int startingPosition)
    {
        tilemap.SetTile(startingPosition, null);
        tilemap.SetTile(startingPosition + new Vector3Int(0, -1, 0), null);
        tilemap.SetTile(startingPosition + new Vector3Int(-1, -1, 0), null);
        tilemap.SetTile(startingPosition + new Vector3Int(-1, 0, 0), null);

    }

    private void GenerateTilemap(int[,] map, Tilemap tilemap, Tile tile)
    {

        int columns = map.GetUpperBound(0);
        int rows = map.GetUpperBound(1);

        for (int x = 0; x <= columns; x++)
        {
            for (int y = 0; y <= rows; y++)
            {
                Vector3Int position = new Vector3Int(x - 5, y - 5, 0);
                tilemap.SetTile(position, (map[x, y] == 1 ? tile : null));
            }
        }
    }
}
