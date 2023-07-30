using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tile;

public class TileMap : MonoBehaviour
{
    Vector3Int gridSize = new Vector3Int(10, 0, 10); // 격자 크기 정의

    void Start()
    {
        for (int x = 0; x < gridSize.x; ++x)
        {
            for (int z = 0; z < gridSize.z; ++z)
            {
                Vector3Int position = new Vector3Int(x, gridSize.y, z);
                GameManager.Instance.nodeMap[position] = new TileNode(position, null, int.MaxValue, int.MaxValue);
                Debug.Log("Position : " + position);
                Debug.Log(GameManager.Instance.nodeMap[position]);
            }
        }

        GameManager.Instance.nodeMap[new Vector3Int(6, 0, 2)].isWalkable = false; // 예시로 (2,2) 위치에 벽 추가
    }
}
