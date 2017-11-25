using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour {

    public Sprite[] floorTiles = new Sprite[0];
    public GameObject tilePrefab;

    public int numRows;
    public int numColumns;

    protected Transform[,] tiles;

	// Use this for initialization
	void Start () {
        GenerateMap();
	}
	
    protected virtual void GenerateMap()
    {
        if (floorTiles.Length == 0)
            return;

        GenerateMap(0, numColumns, 0, numRows);
    }
    protected void GenerateMap(int minX, int maxX, int minY, int maxY)
    {
        for(int row = minY; row < maxY; row++)
        {
            for (int col = minX; col < maxX; col++)
            {
                GameObject toInstantiate = Instantiate(tilePrefab, new Vector3(col, row, 0), Quaternion.identity, transform);
                toInstantiate.GetComponent<SpriteRenderer>().sprite = RandomSprite();
                toInstantiate.name = string.Format("tile_{0}_{1}", col, row);
            }
        }
    }

    protected Sprite RandomSprite()
    {
        return floorTiles[Random.Range(0, floorTiles.Length)];
    }
    protected Sprite RandomSprite(Sprite[] sprites)
    {
        return sprites[Random.Range(0, sprites.Length)];
    }

    
}
