using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tile;

public class TileMap : MonoBehaviour
{
    Vector3Int gridSize = new Vector3Int(10, 0, 10); // 격자 크기 정의

    void Awake()
    {
        for (int x = 0; x < gridSize.x; ++x)
        {
            for (int z = 0; z < gridSize.z; ++z)
            {
                //Vector3Int position = new Vector3Int(x, gridSize.y, z);
                //GameManager.Instance.nodeMap[position] = new TileNode(position, null, int.MaxValue, int.MaxValue);
            }
        }

        //GameManager.Instance.nodeMap[new Vector3Int(6, 0, 2)].isWalkable = false; // 예시로 (2,2) 위치에 벽 추가
    }

    [SerializeField]    public List<Transform> tileList;

    public void Init()
    {
        foreach(Transform transform in tileList)
        {
            Vector3Int position = Vector3Int.FloorToInt(new Vector3(transform.position.x,0,transform.position.z));
            GameManager.Instance.nodeMap[position] = new TileNode(position, null, int.MaxValue, int.MaxValue);
        }
    }
}
