using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    [SerializeField]
    public Tile[,] tileList = new Tile[13,7];
    [SerializeField]
    Tile[] tileObjects;

    void Start()
    {
        AssignTilesToTileList();
    }

    void AssignTilesToTileList()
    {
        foreach (Tile tileObject in tileObjects)
        {
            // Tile 오브젝트 위치를 기반으로 행과 열 인덱스를 계산
            Vector3 objectPosition = tileObject.transform.position;
            int columnIndex = (int)(objectPosition.x);
            int rowIndex = (int)(objectPosition.z);
            Debug.Log("Column Index: " + columnIndex + ", Row Index: " + rowIndex);
            // 계산한 인덱스에 Tile 오브젝트를 tileList 배열에 할당
            tileObject.IsEmpty = true;
            tileList[columnIndex, rowIndex] = tileObject;
        }
    }
}
