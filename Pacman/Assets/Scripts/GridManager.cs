using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Dictionary<Vector2Int, GameObject> _tiles;
    private int _width;
    private int _height;

    public GridManager(int width, int height, GameObject TilePrefab)
    { 
        _tiles = new Dictionary<Vector2Int, GameObject>();
        _width = width;
        _height = height;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                //Position of the tile - taking care of grid offset
                Vector3 pos = new Vector3(x - (width / 2) + 1, y - (height / 2) + 1);
                 // Instantiating a new tile
                GameObject tile = Instantiate(TilePrefab,pos , Quaternion.identity);
                //Set is an obstacle or not
                tile.GetComponent<Tile>().setObstacle(Random.Range(1, 10) < 3);
                //Storing the tile in the dictionary
                _tiles[new Vector2Int((int)pos.x, (int)pos.y)] = tile;
            }
        }
    }

    public bool isTileAvailable(Vector3 pos)
    {
        //Converting a vector3 to vector2Int
        Vector2Int tilePos = new Vector2Int((int)pos.x, (int)pos.y);
        //Check if the tile exists in our dictionary
        if (_tiles.ContainsKey(tilePos))
        {
            //If it exists, we check if it is an obstacle
            if (_tiles[tilePos].GetComponent<Tile>().isObstacle())
            {
                //If it is an obstacle, we return false
                return false;
            }
            else
            {
                //If it is not an obstacle, we return true
                return true;
            }
        }
        else
        {
            //Does not exist
            return false;
        }
    }


    public Vector3 getSpawnLocation()
    {
        while (true)
        {
            Vector3 randomPos = new Vector3(Random.Range(0, _width - 1), Random.Range(0, _height - 1));
            if (isTileAvailable(randomPos))
            {
                return randomPos;
            }
        }
    }
}
