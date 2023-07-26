using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    Tile[,] tileList = new Tile[13,7];
    [SerializeField]    Tile[] tileObjects;

    void Start()
    {
        AssignTilesToTileList();
        GameManager.Instance.Player.tiles = tileList;
    }

    void AssignTilesToTileList()
    {
        foreach (Tile tileObject in tileObjects)
        {
            tileList[(int)tileObject.transform.position.x, (int)tileObject.transform.position.y] = tileObject;
            tileObject.IsEmpty = true;
        }
    }
}
