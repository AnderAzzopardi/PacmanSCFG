using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    // Start is called before the first frame update
    private int _width;
    private int _height;
    public Dictionary<Vector2Int, GameObject> _tiles;

    public Grid(int width, int height, GameObject TilePrefab)
    {
        _tiles = new Dictionary<Vector2Int, GameObject>();
        _width = width;
        _height = height;



        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                //Position of the tile - taking care of grid offset
                Vector3 pos = new Vector3(x - (width / 2) + 0.5f, y - (height / 2) + 0.5f);
                // Instantiating a new tile
                Debug.DrawLine(pos, pos);
                GameObject tile = Instantiate(TilePrefab, pos, Quaternion.identity);

                _tiles[new Vector2Int((int)pos.x, (int)pos.y)] = tile;
            }
        }

    }


    public Vector3 getSpawnLocation()
    {
        while (true)
        {
            Vector3 randomPos = new Vector3(Random.Range(-15, -5), Random.Range(15, 13));


        }
    }
}