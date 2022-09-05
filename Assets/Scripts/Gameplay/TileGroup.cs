using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Match.PubSub;
using Agate.MVC.Core;

public class TileGroup : MonoBehaviour
{
    public TileObject tileObj;
    public int xSize, ySize;

    
    GameObject[] tile;

    float xOffset, yOffset;

    void Start()
    {
        tile = new GameObject[tileObj.tilePref.Length];
        for(int i=0;i < tileObj.tilePref.Length;  i++)
        {
            tile[i] = tileObj.tilePref[i];
        }
        Vector2 offset = tile[0].GetComponent<SpriteRenderer>().bounds.size;
        xOffset = offset.x;
        yOffset = offset.y;
        CreateBoard();
    }
    private void Update()
    {
        if(transform.childCount == 0)
        {
            PublishSubscribe.Instance.Publish<TilesCleared>(new TilesCleared());
        }
    }

    void CreateBoard()
    {
        float startX = transform.position.x - (xSize*xOffset/2); 
        float startY = transform.position.y - (ySize*yOffset/2);

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                int rand = Random.Range(0, tile.Length);
                GameObject newTile = Instantiate(tile[rand], new Vector3(startX + (xOffset * x)
                    , startY + (yOffset * y), 0), tile[rand].transform.rotation);
                newTile.name = x + "," + y;
                newTile.transform.parent = this.transform;
                tileObj.tiles[x, y] = newTile;
                
            }
        }
    }
}
