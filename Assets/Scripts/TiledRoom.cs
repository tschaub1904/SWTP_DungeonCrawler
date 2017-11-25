using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledRoom : TileMap {

    public Sprite wallSprite;
    public Sprite wallCornerSprite;

    public GameObject wallTilePrefab;

	// Use this for initialization
	void Start () {
        GenerateMap();
	}

    protected override void GenerateMap()
    {
        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numColumns; col++)
            {
                if (row == 0 || row == numRows-1 || col == 0 || col == numColumns-1)
                {
                    bool isCornerTile = (row == 0 && col == 0) || (row == 0 && col == numColumns - 1) || (row == numRows - 1 && col == 0) || (row == numRows - 1 && col == numColumns - 1);
                    float rotation = (col == 0) ? 90f : (col == numColumns - 1) ? -90f : (row == numRows-1) ? 0: 180f;
                    GameObject toInstantiate = Instantiate(wallTilePrefab, new Vector3(col, row, 0), Quaternion.Euler(0,0,rotation), transform);

                    Sprite sprite = isCornerTile ? wallCornerSprite : wallSprite;
                    toInstantiate.GetComponent<SpriteRenderer>().sprite = sprite;
                }
            }
        }

        GenerateMap(1, numColumns - 1, 1, numRows - 1);
    }
}
