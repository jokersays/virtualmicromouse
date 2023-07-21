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
        int[,] randomMap = GenerateRandomMap(xSize, ySize);
        Tile blueBlock = Resources.Load<Tile>("block_1");
        tilemap = GetComponent<Tilemap>();

        GenerateTilemap(randomMap, tilemap, blueBlock);
        CleanStart(tilemap, Vector3Int.zero);

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

        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Vector3Int position = new Vector3Int(x - columns/2, y - rows/2, 0);
                tilemap.SetTile(position, (map[x, y] == 1 ? tile : null));
            }
        }
    }
}
